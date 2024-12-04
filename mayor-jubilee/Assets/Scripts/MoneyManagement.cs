using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManagement : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplayText;
    public float currentMoney;

    public void Update()
    {
        moneyDisplayText.text = "Money: " + Mathf.RoundToInt(currentMoney).ToString() + " $";
    }

    public void AddMoney(float amount)
    {
        currentMoney += amount;
    }

    public void RemoveMoney(float amount)
    {
      currentMoney -= amount;
    }
}
