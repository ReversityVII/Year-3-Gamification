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
    public Sprite starCrystalSprite;
    [HideInInspector] public float moneySpent;
    public AudioClip buySfx;
    public AudioClip noMoney;
    AudioSource audioSource;

    public void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        audioSource = FindObjectOfType<AudioSource>();
    }
    public void Update()
    {
        //update current amount of money held
        moneyDisplayText.text = "Money: " + Mathf.RoundToInt(currentMoney).ToString() + "\n\n <sprite index=0>: " + Mathf.RoundToInt(currentGachaMoney).ToString();
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
        audioSource.PlayOneShot(buySfx, 1f);
    }

    public void RemoveGachaMoney(float amount)
    {
        currentGachaMoney -= amount;
    }

    public void ConvertCurrency(float moneyToTake, float crystalsToGive)
    {
        if (moneyToTake <= currentMoney)
        {
            currentGachaMoney += crystalsToGive;
            RemoveMoney(moneyToTake);
            audioSource.PlayOneShot(buySfx, 1f);
        }

        else
        {
            audioSource.PlayOneShot(noMoney, 1f);
        }
    }
}
