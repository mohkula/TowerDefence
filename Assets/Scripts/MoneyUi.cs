using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class MoneyUi : MonoBehaviour
{

    public Text moneyText;
    
    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
