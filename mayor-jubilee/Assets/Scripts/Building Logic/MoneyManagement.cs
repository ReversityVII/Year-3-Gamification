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
    public float currentGachaMoney = 0;
    [HideInInspector] public float moneySpent;

    public void Update()
    {
        //update current amount of money held
        moneyDisplayText.text = "Money: " + Mathf.RoundToInt(currentMoney).ToString() + " $" + "\nStarCrystals: " + Mathf.RoundToInt(currentGachaMoney).ToString();
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
        moneySpent += amount;
    }

    public void RemoveGachaMoney(float amount)
    {
        currentGachaMoney -= amount;
    }

    public void ConvertCurrency(float moneyAmount)
    {
        if (moneyAmount < currentMoney)
        {
            currentGachaMoney += moneyAmount / 10;
            RemoveMoney(moneyAmount);
        }
    }
}
