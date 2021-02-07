using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile
{
    public Vector2Int position;
    public TileType tiletype = TileType.Grass;
    public Crop currentCrop;

    public float timer = 0;

    public int stage = 0;
    float stepTime = 0;

    public GameTile(int _x, int _y)
    {
        position.x = _x;
        position.y = _y;
    }

    public void Plant(Crop crop)
    {
        currentCrop = crop;
        timer = 0;
        stage = 0;
        stepTime = crop.GetStepTime();
        FarmManager.SetMainTile(position.x, position.y, currentCrop.tiles[0]);
        tiletype = TileType.Crop;
        FarmManager.player.score -= currentCrop.pointCost;
    }

    public void Harvest()
    {
        timer = 0;
        currentCrop = null;
        tiletype = TileType.Plot;
        FarmManager.SetMainTile(position.x, position.y, null);
        FarmManager.player.currCapacity++;
        FarmManager.player.pointReserve += currentCrop.pointReward;
    }

    public void Till()
    {
        tiletype = TileType.Plot;
        FarmManager.SetFloorTile(position.x, position.y, FarmManager.tileset.plotTile);
    }

    public void HarvestTooSoon()
    {
        timer = 0;
        currentCrop = null;
        tiletype = TileType.Plot;
        FarmManager.SetMainTile(position.x, position.y, null);
    }

    public void UpdateTile()
    {
        if (currentCrop == null) return;

        timer += Time.deltaTime;

        if(timer >= currentCrop.growthTime)
        {
            tiletype = TileType.GrownCrop;
            return;
        }

        int step = (int)(timer / stepTime);
        if(stage != step)
        {
            stage = step;
            FarmManager.SetMainTile(position.x, position.y, currentCrop.tiles[stage]);

        }
    }

}

public enum TileType { Grass, Plot, Crop, GrownCrop, PointDeposit}
