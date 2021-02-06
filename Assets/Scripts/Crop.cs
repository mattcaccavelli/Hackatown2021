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
    public Tile[] tiles;

    public float reward;

}
