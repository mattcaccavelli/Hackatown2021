using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile
{
    public Vector2 position;
    public TileType tiletype;

    public float timer = 0;

    public int stage = 0;
    int stepTime = 0;

    public void Plant()
    {

    }

    public void Harvest()
    {

    }



}

public enum TileType { Grass, Plot, Crop}
