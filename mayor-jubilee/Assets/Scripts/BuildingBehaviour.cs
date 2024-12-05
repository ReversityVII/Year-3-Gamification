using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour
{

    private BuildingData thisBuildingData;
    private MoneyManagement moneyManagement;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI moneyPerSecondText;
    public GameObject upgradeButton;
    public TextMeshProUGUI upgradeButtonText;

    private int level = 0;
    private float flatUpgradeCost;
    private float upgradeMultiplier;
    private float flatEarningRate;
    private float earningMultiplier;

    //calculations as displayed in update
    [HideInInspector] public float moneyPerSecond;
    [HideInInspector] public float upgradeCost;

    private Transform positionNode;

    private float timer = 0;
    public int buildingNumber;


    //take in the data
    public void Initialize(BuildingData buildingData)
    {
        //initial display
        thisBuildingData = buildingData;
        nameText.text = thisBuildingData.name;
        
        positionNode = thisBuildingData.positionNode.transform;
        gameObject.transform.position = positionNode.position;


        //for calculations
        flatEarningRate = thisBuildingData.flatEarningRate;
        earningMultiplier = thisBuildingData.earningMultiplierPerLevel;
        
        flatUpgradeCost = thisBuildingData.flatUpgradeCost;
        upgradeMultiplier = thisBuildingData.upgradeCostMultiplierPerLevel;

        buildingNumber = thisBuildingData.buildingNumber;


        //make sure scale is correct
        gameObject.transform.localScale = Vector3.one;
        gameObject.transform.position = new Vector3(positionNode.transform.position.x, positionNode.transform.position.y, 0);

        //prefabs cant reference scene objects so referencing has to be done manually
        moneyManagement = GameObject.FindObjectOfType<MoneyManagement>();
    }

    public void Update()
    {
        //display level
        levelText.text = "Level: " + level.ToString();

        //calculate money per second
        moneyPerSecond = (flatEarningRate * (earningMultiplier * level));

        //calculate upgrade cost
        upgradeCost = (flatUpgradeCost * (upgradeMultiplier * (level + 1)));


        //display
        moneyPerSecondText.text = "$/s: " + moneyPerSecond.ToString();
        upgradeButtonText.text = "Upgrade: " + upgradeCost.ToString() + "$";


        //MONEY EARNING
        timer += Time.deltaTime;

        if(timer >= 1)
        {
            moneyManagement.AddMoney(moneyPerSecond);
            timer = 0;
        }    
    }

    public void PurchaseUpgrade() //called by button 
    {
        //check if player has enough money
        if(upgradeCost <= moneyManagement.currentMoney) 
        {
            level++;
            moneyManagement.RemoveMoney(upgradeCost);
        }
    }


}
