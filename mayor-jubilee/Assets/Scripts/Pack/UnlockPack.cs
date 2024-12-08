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
    private CharactersIdentifier chosenChar;

    //prefab for initializing the character ingame
    [SerializeField] private GameObject figurePrefab;

    //script for characters to influence money production
    private MoneyManagement moneyManagement;

    public void Start()
    {
        //reference money script and update initial cost
        moneyManagement = GameObject.FindObjectOfType<MoneyManagement>();
        currentCost = baseCost;
        packText.text = ("Pack Name #1 \n cost: $" + currentCost); //method of declaring will need to change when we get more than one pack
    }

    public void PackMoneyCheck()
    {
        //does the player have enough money to purchase the pack?
        if(moneyManagement.currentMoney >= currentCost)
        {
            moneyManagement.RemoveMoney(currentCost);

            //go ahead and unlock it
            UnlockPackage();
        }
    }

    public void UnlockPackage()
    {
        //Gets characters sheet row enums as an array
        CharactersIdentifier[] Indexes = Enum.GetValues(typeof(CharactersIdentifier)) as CharactersIdentifier[];

        //defines array to compile the relevant rarities for characters in the pack
        rarityArray = new float[Indexes.Length];
        float currentLowestRarity = 100; //the lowest rarity that the random number is below
        
        //save each rarity into an array of rarities
        for(int i = 1; i < Indexes.Length; i++)
        {
            rarityArray[i] = ModelManager.CharactersModel.GetRecord(Indexes[i]).Unlockchance;
        }

        //generate random number
        float rand = UnityEngine.Random.Range(1, 100);

        //compare the random number with the indexed rarities, finds the smallest number that it is still smaller than.
        for(int j = 1; j < rarityArray.Length; j++)  
        {
            //if the random number is less than the rarity AND less than the lowest it has found so far
            if(rand <= (rarityArray[j]) && rand < currentLowestRarity)
            {
                //this character is currently what it should earn
                chosenChar = ModelManager.CharactersModel.GetRecord(Indexes[j]).Identifier;
                currentLowestRarity = ModelManager.CharactersModel.GetRecord(Indexes[j]).Unlockchance;   
            }
        }

        //prefab intantiation and initialization
        GameObject figure = Instantiate(figurePrefab);
        FigureBehaviour figureBehaviour = figure.GetComponent<FigureBehaviour>();
        figureBehaviour.Initialize(chosenChar, currentCost);

        //revaluate current cost
        currentCost = currentCost * multiplierPerPurchase;
        packText.text = ("BASIC PACK \n cost: $" + currentCost); //method of declaring will need to change when we get more than one pack
    }
}
