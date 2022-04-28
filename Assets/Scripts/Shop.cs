
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour{

public TurretBlueprint mageTower;

public TurretBlueprint cannon;
public TurretBlueprint standardTower;

public Text mageTowerCost;
public Text cannonCost;
public Text standardTowerCost;

private TurretBlueprint selectedTurret;
    public GameObject ui;

BuildManager buildManager;


    void Start ()
    {
        buildManager = BuildManager.instance;
        mageTowerCost.text = "$ " + mageTower.cost; 
        standardTowerCost.text = "$ " + standardTower.cost; 
        cannonCost.text =  "$ " +   cannon.cost;
        
    }

    public void SelectMageTower ()
    {
 buildManager.showBuildableNodes(true);   
      selectedTurret = mageTower;
    }

    public void SelectCannon ()
    {
                buildManager.showBuildableNodes(true);
                        selectedTurret = cannon;


    }
    public void SelectTower ()
    {
 buildManager.showBuildableNodes(true);
                         selectedTurret = standardTower;


    }

    public void Toggle(bool b)
    {
            ui.SetActive(b);
            

    }

    public TurretBlueprint getSelectedTurret()
    {
return selectedTurret;
    }

    public TurretBlueprint getBluePrintByType(string type)
    {
        switch (type)
        {
            case "Cannon" :
            return cannon;

            case "StandardTower":
            return standardTower;

            case "MageTower":
            return mageTower;

            
        }

        return null;
    }
    
}
