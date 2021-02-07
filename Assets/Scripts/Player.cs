using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float score;
    public float stamina;
    public float maxStamina = 100;
    public float rechargeRate = 5;

    public int tillCost = 20;

    public int maxCapacity = 10;
    public int currCapacity;
    public int pointReserve;

    public Crop crop;

    public Vector2 moveDirection;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
        if (stamina < maxStamina)
        {
            stamina += rechargeRate * Time.deltaTime;
        }

        if (moveDirection.x > 0.4f) animator.SetInteger("walkDir", 2);
        else if (moveDirection.x < -0.4f) animator.SetInteger("walkDir", 4);
        else if (moveDirection.y > 0) animator.SetInteger("walkDir", 3);
        else if (moveDirection.y < 0) animator.SetInteger("walkDir", 1);
        else animator.SetInteger("walkDir", 0);
    }

    public void SetMove(Vector2 dir)
    {
        moveDirection = dir.normalized;
    }

    public void Interact()
    {
        //determine the gametile of the current position vector
        
        
        int xPos = (int)transform.position.x;
        int yPos = (int)transform.position.y; 

        GameTile currentTile = FarmManager.gameTiles[xPos,yPos];

        switch (currentTile.tiletype){

            case TileType.Plot:
                currentTile.Plant(crop);
                break;

            case TileType.Crop:
                currentTile.HarvestTooSoon();
                break;

            case TileType.GrownCrop:
                if (currCapacity < maxCapacity)
                {
                    currentTile.Harvest();
                }
                break;

            case TileType.Grass:
                if (stamina >= tillCost)
                {
                    stamina -= tillCost;
                    currentTile.Till();
                }
                break;

            case TileType.PointDeposit:
                score += pointReserve;
                pointReserve = 0;
                currCapacity = 0;
                break;

            default:
                break;


        }
        
    }

}
