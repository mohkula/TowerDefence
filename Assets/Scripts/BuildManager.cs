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

    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }
    

}
