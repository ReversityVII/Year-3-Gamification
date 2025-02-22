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
    [Tooltip("MUST BE EXACTLY THE SAME NAME AND CASE AS ITS REFERENCE IN THE SHEET")]  public string packName;
    

    //display pack details to player
    public TextMeshProUGUI unlockButton;
    public CharactersModel characterModel;
    public TextMeshProUGUI packText;

    //cost logic for buying packs
    public float baseCost;
    public float costIncreasePerPurchase;
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
        packText.text = (packName +  "\n\n Costs " + currentCost + "<sprite index=0>");

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
        //creates new local list of character chances
        List<CharacterData> characterChances = new List<CharacterData>();

        //goes through all characters and adds them to the list the number of times their rarity chance says
        for (int i = 0; i < characters.Count; i++)
        {
            //adds to list based on unlock chance; higher is more likely to be chosen
            for (int j = 0; j < characters[i].UnlockChance; j++)
            {
                characterChances.Add(characters[i]);
            }
        }

        //picks an random number between 0 and the length of the list
        int rand = UnityEngine.Random.Range(0, characterChances.Count);

        //selects the character from the list based on random value
        chosenChar = characterChances[rand];

        //prefab instantiation and initialization
        GameObject figure = Instantiate(figurePrefab);
        FigureBehaviour figureBehaviour = figure.GetComponent<FigureBehaviour>();
        figureBehaviour.Initialize(chosenChar, currentCost);
        HoverFlavorText hoverTextScript = figure.GetComponentInChildren<HoverFlavorText>();
        hoverTextScript.Initialize(chosenChar);

        //revaluate current cost
        currentCost += costIncreasePerPurchase;
        packText.text = (packName + "\n\n Costs " + currentCost + "<sprite index=0>"); 
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
