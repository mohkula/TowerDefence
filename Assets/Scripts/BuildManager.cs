using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //singleton
    public static BuildManager instance;
    public Vector3 positionOffset;

    public Transform nodes;


        public GameObject rangeShower;

        private GameObject rangeObject;




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
if(rangeObject != null)
{
       Destroy(rangeObject.gameObject);
}
        selectedNode = node;
        turretToBuild = null;

    }

    public void selectTurret (Turret turret)
    {
        if(rangeObject != null)
{
       Destroy(rangeObject.gameObject);
}
        selectedTurret = turret;
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
     //   DeselectNode();
    }

   // public void DeselectNode ()
    //{
     //   selectedNode.Deselect();
      //  selectedNode = null;
        
    //}

    public TurretBlueprint GetTurretToBuild()
    {
        return shop.getSelectedTurret();
    }
    
    public Node getSelectedNode()
    {
        return selectedNode;
    }


public void showBuildableNodes(bool show)
{

      if(rangeObject != null)
{
       Destroy(rangeObject.gameObject);
}

       foreach(Transform child in nodes)
{
   Node script = child.gameObject.GetComponent<Node>(); 
   
   if(show && script.CanBuild)
   {
       script.highLight(show);
   }
   else{
       script.highLight(false);

   }
  
}
}
    public void BuildTurret (Node node)
    {
        
        TurretBlueprint  blueprint = shop.getSelectedTurret();

 
        int offset = 0;
       // if(selectedNode == null)
        //{
          //  return;
        //}


 if(PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
                    
 

Vector3 buildPos = GetBuildPosition(node.transform.position);



        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, buildPos , Quaternion.identity);
       _turret.GetComponent<Turret>().setNode(node);
     //  selectedNode.turret = _turret;
      // selectedNode.Deselect();
      // selectedNode = null;

      node.CanBuild = false;

      showBuildableNodes(false);
       

      


     
    }

    public Vector3 GetBuildPosition (Vector3 node)
   {
      // if(selectedNode == null)
       //{
         //  return selectedTurret.transform.position + positionOffset;
       //}

      
       return node + positionOffset;
   }

   



  public void UpgradeTurret()
    {

        TurretBlueprint bp = shop.getBluePrintByType(selectedTurret.type);

         if(PlayerStats.Money < bp.upgradeCost)
        {
           Debug.Log("Not enough money to upgrade");
           return;
        }

        PlayerStats.Money -= bp.upgradeCost;

        Node nodeTurretWasOn = selectedTurret.getNode();
        Destroy(selectedTurret.gameObject);

                   

        GameObject _turret = Instantiate(bp.upgradedPrefab, GetBuildPosition(nodeTurretWasOn.transform.position), Quaternion.identity);
      
 _turret.GetComponent<Turret>().setNode(nodeTurretWasOn);
    
    nodeTurretWasOn.turret = _turret;

         Debug.Log("Turret upgraded");

    }

    public void sellTurret()
    { 

                TurretBlueprint bp = shop.getBluePrintByType(selectedTurret.type);


        
        PlayerStats.Money += bp.GetSellAmount();
          Destroy(selectedTurret.gameObject);

        Node nodeTurretWasOn = selectedTurret.getNode();

        nodeTurretWasOn.CanBuild = true;
         

    }


    public void drawRange()
    {

if(rangeObject == null)

{
 rangeObject = Instantiate(rangeShower, selectedTurret.transform.position, Quaternion.identity);
        rangeObject.transform.localScale = new Vector3(selectedTurret.range * 2,selectedTurret.range * 2,selectedTurret.range * 2);

}
else{

   

       Destroy(rangeObject.gameObject);

}


       
    }

}
