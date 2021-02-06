using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmManager : MonoBehaviour
{

    public static GameTile[,] gameTiles;
    public int mapSize;

    public static Player player;
    public Tilemap tilemap;


    // Start is called before the first frame update
    void Start()
    {
        gameTiles = new GameTile[mapSize, mapSize];
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
