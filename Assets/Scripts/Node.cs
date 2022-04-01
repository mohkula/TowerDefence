using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{

    public Color hoverColor;
    public Vector3 positionOffset;

    public bool buildableOn = true;

   [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;

    private Color startColor;
    public Color notEnoughMoneyColor;
    public Color cannotBuildHere;

    BuildManager buildManager;

    void Start()
    {


        rend = GetComponent<Renderer>();
        rend.enabled = false;
        startColor = rend.material.color;
        
        buildManager = BuildManager.instance;
        
        
    }

    void OnMouseDown()
    {

        if(!buildableOn)
        {
            return;
        }

if(EventSystem.current.IsPointerOverGameObject()){
           return;
       }
       
        if (turret != null)
        {
            buildManager.SelectNode(this);
                return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

BuildTurret(buildManager.GetTurretToBuild());

    }

    void BuildTurret (TurretBlueprint blueprint)
    {
 if(PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
                    

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;


        Debug.Log("Turret built");
    }


    public void SellTurret ()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        

        Destroy(turret);
        turretBlueprint = null;
    }

    public void UpgradeTurret()
    {
         if(PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);

                   

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

    isUpgraded = true;

         Debug.Log("Turret upgraded");

    }

   void OnMouseEnter()
   {
   rend.enabled = true;

       if(EventSystem.current.IsPointerOverGameObject()){
           return;
       }

      

       if (!buildManager.CanBuild)
        {
            return;
        }

 if(!buildableOn)
       {
                              rend.material.color = cannotBuildHere;
                              return;

       }

        if(buildManager.HasMoney)
        {
       rend.material.color = hoverColor;

        }

        else
        {
                   rend.material.color = notEnoughMoneyColor;

        }
   }

   void OnMouseExit()
   {
          rend.gameObject.GetComponent<Renderer>().enabled = false;

       rend.material.color = startColor;
   }


   public Vector3 GetBuildPosition ()
   {
       return transform.position + positionOffset;
   }
}
