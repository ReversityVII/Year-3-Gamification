using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * Keeps track of the player's current money, and updates accordingly. 
 * Other methods will call AddMoney and RemoveMoney when needed.
 */
public class MoneyManagement : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplayText;
    public float currentMoney;

    public void Update()
    {
        //update current amount of money held
        moneyDisplayText.text = "Money: " + Mathf.RoundToInt(currentMoney).ToString() + " $";
    }

    //called by other classes to add money
    public void AddMoney(float amount)
    {
        currentMoney += amount;
    }

    //called by other classes to remove money
    public void RemoveMoney(float amount)
    {
      currentMoney -= amount;
    }
}
