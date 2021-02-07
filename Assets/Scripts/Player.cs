using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float score;

    public Crop crop;

    public Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
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
            case TileType.GrownCrop:
                currentTile.Harvest();
                break;

            case TileType.Grass:
                currentTile.Till();
                break;

            default:
                break;


        }
        
    }

}
