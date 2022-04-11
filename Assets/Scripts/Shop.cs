
using UnityEngine;

public class Shop : MonoBehaviour{

public TurretBlueprint standardTurret;
public TurretBlueprint cannon;
public TurretBlueprint standardTower;


private TurretBlueprint selectedTurret;
    public GameObject ui;

BuildManager buildManager;


    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        buildManager.BuildTurret(standardTurret);
    }

    public void SelectCannon ()
    {
                buildManager.BuildTurret(cannon);

    }
    public void SelectTower ()
    {
                buildManager.BuildTurret(standardTower);

    }

    public void Toggle(bool b)
    {
            ui.SetActive(b);

    }

    public TurretBlueprint getSelectedTurret()
    {
return selectedTurret;
    }
    
}
