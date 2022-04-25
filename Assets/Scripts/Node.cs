using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{

    public Color hoverColor;


    

    private bool selected = false;

    private GameObject hover;


   [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;

    private Color startColor;

    public Color selectColor;

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

      
if(EventSystem.current.IsPointerOverGameObject()){
           return;
       }
       buildManager.tui.Toggle(false);
       
        if (turret != null)
        {
           
           return;
        }

        if(buildManager.getSelectedNode() != null)
        {
            buildManager.DeselectNode();
        }


  rend.material.color = selectColor;
      buildManager.SelectNode(this);
      selected = true;
             



    }

    


    public void SellTurret ()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        

        Destroy(turret);
        turretBlueprint = null;
    }

  

   void OnMouseEnter()
   {
       Debug.Log("entered");






   rend.enabled = true;

       if(EventSystem.current.IsPointerOverGameObject()){
           return;
       }

              if(buildManager.shop.getSelectedTurret() != null)
{
             hover = (GameObject)Instantiate(buildManager.shop.getSelectedTurret().hoverPrefab, transform.position , Quaternion.identity);

}
if (turret != null)
        {
           
           return;
        }
      

       if (!buildManager.CanBuild)
        {
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
       Debug.Log("exited");
       if(hover != null)
       {
       Destroy(hover.gameObject);

       }
         if(!selected){

         rend.enabled = false;
rend.material.color = startColor;
         } 
       
   }


public void Deselect ()
{
    selected  = false;
     rend.enabled = false;

}

   
}
