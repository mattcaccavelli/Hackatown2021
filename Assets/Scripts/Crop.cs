using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewCrop",
    menuName = "ScriptableObjects/Crop", order = 1)]
[System.Serializable]
public class Crop : ScriptableObject
{
    public float growthTime;
    public float witherTime;

    public Sprite icon;
    public float reward;

    public Tile[] tiles;
    public float GetStepTime()
    {
        return growthTime / tiles.Length;
    }
}
