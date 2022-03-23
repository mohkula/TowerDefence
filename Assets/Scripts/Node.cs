using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{

    public Color hoverColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;

    private Color startColor;
    public Color notEnoughMoneyColor;

    BuildManager buildManager;

    void Start()
    {

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {

if(EventSystem.current.IsPointerOverGameObject()){
           return;
       }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("already build on this node");
            return;
        }

        buildManager.BuildTurretOn(this);


    }

   void OnMouseEnter()
   {

       if(EventSystem.current.IsPointerOverGameObject()){
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
       rend.material.color = startColor;
   }


   public Vector3 GetBuildPosition ()
   {
       return transform.position + positionOffset;
   }
}
