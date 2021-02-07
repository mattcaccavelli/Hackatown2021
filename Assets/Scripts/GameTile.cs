using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile
{
    public Vector2Int position;
    public TileType tiletype = TileType.Grass;
    public Crop currentCrop;
    public float cropHealth;

    public float timer = 0;

    public int stage = 0;
    float stepTime = 0;

    public GameObject sparkle;

    public GameTile(int _x, int _y)
    {
        position.x = _x;
        position.y = _y;
    }

    public void Plant(Crop crop)
    {
        if (FarmManager.player.score >= crop.pointCost)
        {
            currentCrop = crop;
            timer = 0;
            stage = 0;
            cropHealth = currentCrop.witherTime;
            stepTime = crop.GetStepTime();
            FarmManager.SetMainTile(position.x, position.y, currentCrop.tiles[0]);
            tiletype = TileType.Crop;
            FarmManager.player.score -= currentCrop.pointCost;
        }
    }

    public void Harvest()
    {
        timer = 0;
        if(tiletype == TileType.GrownCrop) FarmManager.player.score += currentCrop.pointReward;
        tiletype = TileType.Plot;
        FarmManager.SetMainTile(position.x, position.y, null);
        FarmManager.player.currCapacity++;
        FarmManager.player.pointReserve += currentCrop.pointReward;
        currentCrop = null;
        if (sparkle != null) GameObject.Destroy(sparkle);
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

        if(timer >= currentCrop.growthTime && tiletype == TileType.Crop)
        {
            tiletype = TileType.GrownCrop;
            sparkle = GameObject.Instantiate(FarmManager.tileset.sparkles, new Vector3(position.x + 0.5f, position.y + 0.6f, 0), Quaternion.identity);
            timer = 0;
            return;
        }

        if(tiletype == TileType.GrownCrop)
        {
            if (currentCrop != null) cropHealth -= Time.deltaTime;
            if (cropHealth <= 0)
            {
                currentCrop = null;
                tiletype = TileType.Plot;
                FarmManager.SetMainTile(position.x, position.y, null);
            }
        }

        if (tiletype == TileType.Crop)
        {
            int step = (int)(timer / stepTime);
            if (stage != step)
            {
                stage = step;
                FarmManager.SetMainTile(position.x, position.y, currentCrop.tiles[stage]);

            }
        }
    }

}

public enum TileType { Grass, Road, Fence, Plot, Crop, GrownCrop, PointDeposit}
