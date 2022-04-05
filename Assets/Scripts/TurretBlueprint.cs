using System.Collections;
using UnityEngine;

[System.Serializable] //to show data on the inspector when not extending monobehaviour
public class TurretBlueprint 
{
    public GameObject prefab;
    public int cost;

    public int buildY;

    public GameObject upgradedPrefab;   

    public int upgradeCost;

    


    public int GetSellAmount()
    {
        return cost / 2;
    }

    public int GetUpgradeCost()
    {
        return cost * 2;
    }

    
}
