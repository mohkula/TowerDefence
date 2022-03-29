
using UnityEngine;

public class Shop : MonoBehaviour{

public TurretBlueprint standardTurret;
public TurretBlueprint missileLauncher;
public TurretBlueprint standardTower;

BuildManager buildManager;


    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher ()
    {
                buildManager.SelectTurretToBuild(missileLauncher);

    }
    public void SelectTower ()
    {
                buildManager.SelectTurretToBuild(standardTower);

    }
    
}
