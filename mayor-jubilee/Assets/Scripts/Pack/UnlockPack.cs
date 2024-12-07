using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SheetCodes;
using System;
using JetBrains.Annotations;
using System.Runtime.InteropServices;

public class UnlockPack : MonoBehaviour
{
    public TextMeshProUGUI unlockButton;
    public CharactersModel characterModel;
    public TextMeshProUGUI packText;

    public float baseCost;
    public float multiplierPerPurchase;
    private float currentCost;

    private float [] rarityArray;
    private CharactersIdentifier chosenChar;

    [SerializeField] private GameObject figurePrefab;

    private MoneyManagement moneyManagement;

    //reference basic figure prefab
    //[SerializeField] private Figure figure; 

    public void Start()
    {
        moneyManagement = GameObject.FindObjectOfType<MoneyManagement>();
        currentCost = baseCost;

        packText.text = ("Pack Name #1 \n cost: $" + currentCost);
    }

    public void PackMoneyCheck()
    {
        if(moneyManagement.currentMoney >= currentCost)
        {
            moneyManagement.RemoveMoney(currentCost);
            UnlockPackage();
        }
    }

    public void UnlockPackage()
    {
        //Gets characters sheet row enums as an array
        CharactersIdentifier[] Indexes = Enum.GetValues(typeof(CharactersIdentifier)) as CharactersIdentifier[];

        rarityArray = new float[Indexes.Length];
        float currentLowestRarity = 100;
        
        //save each rarity into an array of rarities
        for(int i = 1; i < Indexes.Length; i++)
        {
            rarityArray[i] = ModelManager.CharactersModel.GetRecord(Indexes[i]).Unlockchance;
        }

        float rand = UnityEngine.Random.Range(1, 100);

        //compare the random number with the indexed rarities, finds the smallest number that it is still smaller than.
        for(int j = 1; j < rarityArray.Length; j++)  
        {
            if(rand <= (rarityArray[j]) && rand < currentLowestRarity)
            {
                chosenChar = ModelManager.CharactersModel.GetRecord(Indexes[j]).Identifier;
                currentLowestRarity = ModelManager.CharactersModel.GetRecord(Indexes[j]).Unlockchance;   
            }
        }

        GameObject figure = Instantiate(figurePrefab);
        FigureBehaviour figureBehaviour = figure.GetComponent<FigureBehaviour>();
        figureBehaviour.Initialize(chosenChar, currentCost);

        //revaluate current cost
        currentCost = currentCost * multiplierPerPurchase;
        packText.text = ("Pack Name #1 \n cost: $" + currentCost);
    }
}
