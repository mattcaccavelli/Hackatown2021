using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile
{
    public Vector2 position;
    public TileType tiletype = TileType.Grass;

    public float timer = 0;

    public int stage = 0;
    int stepTime = 0;

    public GameTile(int _x, int _y)
    {
        position.x = _x;
        position.y = _y;
    }

    public void Plant()
    {
        tiletype = TileType.Crop;
    }

    public void Harvest()
    {
        tiletype = TileType.Plot;
    }

    public void Till()
    {
        tiletype = TileType.Plot;
        FarmManager.SetTile((int)position.x, (int)position.y, FarmManager.tileset.plotTile);
    }


}

public enum TileType { Grass, Plot, Crop}
