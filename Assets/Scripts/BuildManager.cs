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
    private Node selectedNode;

    public NodeUi nodeUi;

    public bool CanBuild { get { return turretToBuild != null;} }

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost;} }

  

    public void SelectNode (Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUi.SetTarget(node);

    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void DeselectNode ()
    {
        selectedNode = null;
        nodeUi.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        Debug.Log(turretToBuild);
        return turretToBuild;
    }
    

}
