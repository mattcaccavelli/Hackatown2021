using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmManager : MonoBehaviour
{

    public static GameTile[,] gameTiles;
    public int mapSize;

    public static Player player;
    public static Tilemap floorTilemap;
    public static Tilemap mainTilemap;
    public static TileSet tileset;

    public TileSet tileSetAsset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameTiles = new GameTile[mapSize, mapSize];
        floorTilemap = transform.GetChild(0).GetComponent<Tilemap>();
        mainTilemap = transform.GetChild(1).GetComponent<Tilemap>();
        tileset = tileSetAsset;

        for(int x = 0; x < mapSize; x++)
        {
            for (int y = 0; y < mapSize; y++)
            {
                gameTiles[x, y] = new GameTile(x, y);
                SetFloorTile(x, y, tileset.grassTiles[Random.Range(0, tileset.grassTiles.Length)]);
            }
        }

    }

    public static void SetFloorTile(int x, int y, Tile tile)
    {
        floorTilemap.SetTile(new Vector3Int(x, y, 0), tile);
    }

    public static void SetMainTile(int x, int y, Tile tile)
    {
        mainTilemap.SetTile(new Vector3Int(x, y, 0), tile);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameTile g in gameTiles)
        {
            g.UpdateTile();
        }
    }
}


[System.Serializable]
public class TileSet
{
    public Tile[] grassTiles;
    public Tile plotTile;
}
