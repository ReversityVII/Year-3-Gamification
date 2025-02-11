using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SheetCodes;
using System;


/*
 * Logic related to unlocking the packs.
 * checks if the player has enough money, displays and updates cost for each sequential purchase. 
 * references a sheet that holds the cameras. 
 * for future note: might need a solution for referecning different sheets of characters. 
 */

public class UnlockPack : MonoBehaviour
{

    private List<CharacterData> characters = new List<CharacterData>();
    public string packName;

    //display pack details to player
    public TextMeshProUGUI unlockButton;
    public CharactersModel characterModel;
    public TextMeshProUGUI packText;

    //cost logic for buying packs
    public float baseCost;
    public float multiplierPerPurchase;
    private float currentCost;

    //array for evaluating rarities and choosing a character that fits.
    private float [] rarityArray;
    private CharacterData chosenChar;

    //prefab for initializing the character ingame
    [SerializeField] private GameObject figurePrefab;

    //script for characters to influence money production
    private MoneyManagement moneyManagement;

    public void Start()
    {
        //reference money script and update initial cost
        moneyManagement = GameObject.FindObjectOfType<MoneyManagement>();
        currentCost = baseCost;
        packText.text = ("Pack Name #1 \n cost: SC$" + currentCost); //method of declaring will need to change when we get more than one pack

        GetRelevantCharacters();


    }

    public void PackMoneyCheck()
    {
        //does the player have enough money to purchase the pack?
        if(moneyManagement.currentGachaMoney >= currentCost)
        {
            moneyManagement.RemoveGachaMoney(currentCost);

            //go ahead and unlock it
            UnlockPackage();
        }
    }

    public void UnlockPackage()
    {

        float currentLowestRarity = 100; //the lowest rarity that the random number is below
        rarityArray = new float[characters.Count];
        for (int i = 0; i < characters.Count; i++)
        {
            rarityArray[i] = characters[i].UnlockChance;
        }

        //generate random number
        float rand = UnityEngine.Random.Range(1, 100);

        //compare the random number with the indexed rarities, finds the smallest number that it is still smaller than.
        for(int j = 0; j < rarityArray.Length; j++)  
        {
            //if the random number is less than the rarity AND less than the lowest it has found so far
            if(rand <= (rarityArray[j]) && rand < currentLowestRarity)
            {
                //this character is currently what it should earn
                chosenChar = characters[j];
                currentLowestRarity = characters[j].UnlockChance;
                //Debug.Log(currentLowestRarity);
            }
        }

        //prefab instantiation and initialization
        GameObject figure = Instantiate(figurePrefab);
        FigureBehaviour figureBehaviour = figure.GetComponent<FigureBehaviour>();
        figureBehaviour.Initialize(chosenChar, currentCost);
        HoverFlavorText hoverTextScript = figure.GetComponentInChildren<HoverFlavorText>();
        hoverTextScript.Initialize(chosenChar);

        //revaluate current cost
        currentCost = Mathf.RoundToInt(currentCost * multiplierPerPurchase);
        packText.text = ("BASIC PACK \n cost: SC$" + currentCost); //method of declaring will need to change when we get more than one pack
    }

    public void GetRelevantCharacters()
    {
        CharactersIdentifier[] Indexes = Enum.GetValues(typeof(CharactersIdentifier)) as CharactersIdentifier[];
        for (int i = 1; i < Indexes.Length; i++)
        {
            string[] relevantPacks = ModelManager.CharactersModel.GetRecord(Indexes[i]).Packs;
            bool canSave = true;

            if (relevantPacks.Length == 0)
            {
                canSave = false;
            }

            for (int j = 0; j < relevantPacks.Length; j++)
            {
                if (relevantPacks[j] != packName)
                {
                    canSave = false;
                } else
                {
                    break;
                }
            }

            if (canSave)
            {
                CharacterData newChar = new CharacterData();
                newChar.Name = ModelManager.CharactersModel.GetRecord(Indexes[i]).Name;
                newChar.IconTexture = ModelManager.CharactersModel.GetRecord(Indexes[i]).Icon;
                newChar.SpriteTexture = ModelManager.CharactersModel.GetRecord(Indexes[i]).Sprite;
                newChar.UnlockChance = ModelManager.CharactersModel.GetRecord(Indexes[i]).UnlockChance;
                //newChar.CharacterRarity = ModelManager.CharactersModel.GetRecord(Indexes[i]).Rarity;
                newChar.NodeNumber = ModelManager.CharactersModel.GetRecord(Indexes[i]).NodeNumber;
                newChar.PercentageEarningBoost = ModelManager.CharactersModel.GetRecord(Indexes[i]).PercentageEarningBoost;
                newChar.BuildingSlotAffected = ModelManager.CharactersModel.GetRecord(Indexes[i]).BuildingSlotAffected;
                newChar.FlavourText = ModelManager.CharactersModel.GetRecord(Indexes[i]).FlavourText;
                newChar.isHorizontal = ModelManager.CharactersModel.GetRecord(Indexes[i]).IsHorizontal;
                characters.Add(newChar);
            }
        }
    }
}
