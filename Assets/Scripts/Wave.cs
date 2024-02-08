using UnityEngine;
using System.Collections.Generic;



[System.Serializable]
public class FruitSpawnData
{
    public bool isBomb;
    public float x;
    public float delay;
    public Vector2 velocity;
}

[System.Serializable]
public class Wave
{
    public List<FruitSpawnData> items;
}
