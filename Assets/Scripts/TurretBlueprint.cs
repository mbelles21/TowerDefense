using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// not part of a game object, but still needs to be accessible
[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
