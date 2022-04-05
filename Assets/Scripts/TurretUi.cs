using UnityEngine;
using UnityEngine.UI;
public class TurretUi : MonoBehaviour
{

    public GameObject ui;

    public Text upgradeCost;

    public Text sellAmount;
    public Button upgradeButton;


   private Node target;

    BuildManager buildManager;


    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void Show (Turret turret)
    {
ui.SetActive(true);
sellAmount.text = turret.blueprint.GetSellAmount().ToString();
upgradeCost.text = turret.blueprint.GetUpgradeCost().ToString();

    }

    


    public void Upgrade ()
    
    {

       
   buildManager.UpgradeTurret();
    ui.SetActive(false);
    }

    public void Sell()
    {
                
   buildManager.sellTurret();
    ui.SetActive(false);
    
      
       
    }


}
