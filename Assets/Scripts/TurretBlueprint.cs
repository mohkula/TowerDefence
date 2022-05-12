using System.Collections;
using UnityEngine;

[System.Serializable] //to show data on the inspector when not extending monobehaviour
public class TurretBlueprint 
{
    public GameObject prefab;
    public int cost;

    

    public GameObject upgradedPrefab;   

    public GameObject hoverPrefab;

    public int upgradeCost;

    private float range;


    


    public int GetSellAmount()
    {
        return cost / 2;
    }

    public int GetUpgradeCost()
    {
        return cost * 2;
    }

    public float getRange()
    {
        return prefab.gameObject.GetComponent<Turret>().range;
    }

    public bool isUpgraded()
    {
                return upgradedPrefab.gameObject.GetComponent<Turret>().isUpgraded;

    }

    
}
