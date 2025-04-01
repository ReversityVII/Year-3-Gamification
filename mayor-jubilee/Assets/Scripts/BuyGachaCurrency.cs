using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGachaCurrency : MonoBehaviour
{
    public float moneyToTake; //money taken to convert to gacha currency
    public float crystalsToGive;
    public MoneyManagement moneyManagement;
    public GameObject purchaseScreenPrefab;
    public GameObject gachaCanvas;

    // Start is called before the first frame update
    void Start()
    {
        moneyManagement = GameObject.FindObjectOfType<MoneyManagement>();
    }

    public void CompletePurchase()
    {
        if (moneyManagement.currentMoney > moneyToTake)
        StartCoroutine(test());
    }

    public IEnumerator test()
    {
        //spawn a purchase screen prefab
        Instantiate(purchaseScreenPrefab, gachaCanvas.transform);

        yield return new WaitForSeconds(purchaseScreenPrefab.GetComponent<DestroySelfAfterTime>().timeInSeconds); //wait for the same amount of time as the screen takes to destroy itself

        moneyManagement.ConvertCurrency(moneyToTake, crystalsToGive);

        //yield return null;
    }
}
