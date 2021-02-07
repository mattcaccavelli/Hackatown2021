using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmManager : MonoBehaviour
{

    public static GameTile[,] gameTiles;
    public Vector2Int mapSize;

    public static Player player;
    public static Tilemap floorTilemap;
    public static Tilemap mainTilemap;
    public static TileSet tileset;

    public TileSet tileSetAsset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameTiles = new GameTile[mapSize.x, mapSize.y];
        floorTilemap = transform.GetChild(0).GetComponent<Tilemap>();
        mainTilemap = transform.GetChild(1).GetComponent<Tilemap>();
        tileset = tileSetAsset;

        for(int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {

                Tile marker = (Tile)floorTilemap.GetTile(new Vector3Int(x, y, 0));
                gameTiles[x, y] = new GameTile(x, y);

                if (marker == tileset.grassMarker)
                    SetFloorTile(x, y, tileset.grassTiles[Random.Range(0, tileset.grassTiles.Length)]);
                else if (marker == tileset.roadMarker)
                {
                    gameTiles[x, y].tiletype = TileType.Road;
                    SetFloorTile(x, y, tileset.roadTiles[Random.Range(0, tileset.roadTiles.Length)]);
                }
                else if (marker == tileset.fenceMarker)
                {
                    gameTiles[x, y].tiletype = TileType.Fence;
                    SetFloorTile(x, y, tileset.grassTiles[0]);

                }
                else if (marker == tileset.dropoffMarker)
                {
                    gameTiles[x, y].tiletype = TileType.PointDeposit;
                    SetFloorTile(x, y, tileset.roadTiles[0]);
                }
            }
        }

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                if(gameTiles[x, y].tiletype == TileType.Fence) SetMainTile(x, y, GetFenceTile(x, y));
            }
        }

        gameTiles[0, 0].tiletype = TileType.PointDeposit;

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

    public Tile GetFenceTile(int x, int y)
    {
        if (x > 0 && x < mapSize.x - 1 &&  gameTiles[x - 1,y].tiletype == TileType.Fence && gameTiles[x + 1, y].tiletype == TileType.Fence)
        {
            return tileset.fenceTiles[0];
        }
        else if (y > 0 && y < mapSize.y - 1 && gameTiles[x, y - 1].tiletype == TileType.Fence && gameTiles[x, y + 1].tiletype == TileType.Fence)
        {
            return tileset.fenceTiles[2];
        }
        else
        {
            return tileset.fenceTiles[1];
        }
    }
}


[System.Serializable]
public class TileSet
{
    public Tile[] grassTiles;
    public Tile[] roadTiles;
    public Tile[] fenceTiles;
    public Tile plotTile;

    public GameObject sparkles;

    public Tile fenceMarker;
    public Tile grassMarker;
    public Tile roadMarker;
    public Tile dropoffMarker;

}
