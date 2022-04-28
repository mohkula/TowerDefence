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

    public void Show (TurretBlueprint turret)
    {
ui.SetActive(true);
sellAmount.text = turret.GetSellAmount().ToString();
upgradeCost.text = turret.GetUpgradeCost().ToString();

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

    public void Toggle(bool b)
    {
        ui.SetActive(b);
        

    }


}
