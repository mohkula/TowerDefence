using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //singleton
    public static BuildManager instance;

    void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("More than one manager!!");
            return;
        }
        instance = this;
    }


    public GameObject standardTurretPrefab;
    public GameObject missileLauncher;


    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null;} }

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost;} }

    public void BuildTurretOn (Node node)
    {

        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
                    Debug.Log("Turret built");

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
    

}
