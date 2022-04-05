using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //singleton
    public static BuildManager instance;
    public Vector3 positionOffset;

    public Shop shop;

    public TurretUi tui;
    void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("More than one manager!!");
            return;
        }
        instance = this;
    }



    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    private Turret selectedTurret;

    

    public bool CanBuild { get { return turretToBuild != null;} }

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost;} }

  

    public void SelectNode (Node node)
    {
        shop.Toggle(true);

       
        selectedNode = node;
        turretToBuild = null;

    }

    public void selectTurret (Turret turret)
    {
        selectedTurret = turret;
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void DeselectNode ()
    {
        selectedNode.Deselect();
        selectedNode = null;
        
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return shop.getSelectedTurret();
    }
    
    public Node getSelectedNode()
    {
        return selectedNode;
    }

    public void BuildTurret (TurretBlueprint blueprint)
    {
        int offset = 0;
        if(selectedNode == null)
        {
            return;
        }

        Debug.Log(blueprint.buildY);

 if(PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
                    
    if(blueprint.buildY > 0)
    {
        Debug.Log("yes");
offset = blueprint.buildY;
    }

Vector3 buildPos = GetBuildPosition();
buildPos.y += offset;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, buildPos , Quaternion.identity);
       _turret.GetComponent<Turret>().setNode(selectedNode);
       selectedNode.turret = _turret;
       selectedNode.Deselect();
       selectedNode = null;
       shop.Toggle(false);

      


     
    }

    public Vector3 GetBuildPosition ()
   {
       if(selectedNode == null)
       {
           return selectedTurret.transform.position + positionOffset;
       }

      
       return selectedNode.transform.position + positionOffset;
   }

   



  public void UpgradeTurret()
    {
         if(PlayerStats.Money < selectedTurret.blueprint.upgradeCost)
        {
           Debug.Log("Not enough money to upgrade");
           return;
        }

        PlayerStats.Money -= selectedTurret.blueprint.upgradeCost;

        Node nodeTurretWasOn = selectedTurret.getNode();
        Destroy(selectedTurret.gameObject);

                   

        GameObject _turret = Instantiate(selectedTurret.blueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
      
 _turret.GetComponent<Turret>().setNode(nodeTurretWasOn);
    
    nodeTurretWasOn.turret = _turret;

         Debug.Log("Turret upgraded");

    }

    public void sellTurret()
    { 
        
        PlayerStats.Money += selectedTurret.blueprint.GetSellAmount();
          Destroy(selectedTurret.gameObject);
         

    }

}
