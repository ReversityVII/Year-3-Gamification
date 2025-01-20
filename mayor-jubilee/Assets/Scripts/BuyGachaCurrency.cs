using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGachaCurrency : MonoBehaviour
{
    public float moneyToConvert; //money taken to convert to gacha currency
    public MoneyManagement moneyManagement;

    // Start is called before the first frame update
    void Start()
    {
        moneyManagement = GameObject.FindObjectOfType<MoneyManagement>();
    }

    public void CompletePurchase()
    {
        moneyManagement.ConvertCurrency(moneyToConvert);
    }
}
