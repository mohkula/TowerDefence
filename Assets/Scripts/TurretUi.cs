using UnityEngine;
using UnityEngine.UI;
public class TurretUi : MonoBehaviour
{

    public GameObject ui;

    

    public Text upgradeCost;
      public Text upgradeText;

    public Text sellAmount;
    public Button upgradeButton;


   private Node target;

    BuildManager buildManager;


    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void Show (TurretBlueprint turret, Turret tur)
    {

      
ui.SetActive(true);
sellAmount.text = turret.GetSellAmount().ToString();
if(tur.isUpgraded)
{
    upgradeText.text = "";
    upgradeCost.text = "Max level";

}
else
{
upgradeCost.text = turret.GetUpgradeCost().ToString();

}
    }

    


    public void Upgrade ()
    
    {

       
   buildManager.UpgradeTurret();
Toggle(false);
buildManager.shop.Toggle(true);
buildManager.drawRange();
    }

    public void Sell()
    {
                
   buildManager.sellTurret();
   Toggle(false);
   buildManager.shop.Toggle(true);
   buildManager.drawRange(); 
       
    }
     
    public void Cancel()
    {
        Toggle(false);
buildManager.shop.Toggle(true);
buildManager.drawRange();
    }

    public void Toggle(bool b)
    {
        ui.SetActive(b);
        

    }


}
