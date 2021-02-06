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

    }

    public void Harvest()
    {

    }

    public void Till()
    {

    }


}

public enum TileType { Grass, Plot, Crop}
