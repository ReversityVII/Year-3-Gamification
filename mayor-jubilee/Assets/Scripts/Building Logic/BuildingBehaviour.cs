using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/*
 * The specific behaviour for each individual buildig - each building has a copy of this script. 
 * handles setting of necessary starting values, and logic relating to upgrading and money production.
 */
public class BuildingBehaviour : MonoBehaviour
{
    private BuildingData thisBuildingData;
    private MoneyManagement moneyManagement;

    //for prefab gameobjects
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI moneyPerSecondText;
    public GameObject upgradeButton;
    public TextMeshProUGUI upgradeButtonText;

    //other building variables needed
    private int level = 0;
    private float flatUpgradeCost;
    private float upgradeMultiplier;
    private float flatEarningRate;
    private float earningMultiplier;

    //calculations as displayed in update
    [HideInInspector] public float moneyPerSecond;
    [HideInInspector] public float upgradeCost;
    [HideInInspector] public float buildingInfluence;

    //position on the screen, assigned to a node (gameobject)
    private Transform positionNode;

    private float timer = 0;


    //take in the data
    public void Initialize(BuildingData buildingData)
    {
        //initial display
        thisBuildingData = buildingData;
        nameText.text = thisBuildingData.name;
        
        //place prefab appropriately
        positionNode = thisBuildingData.positionNode.transform;
        //gameObject.transform.position = positionNode.position;
        gameObject.transform.SetParent(positionNode.transform, true);

        //reference params passed from list
        flatEarningRate = thisBuildingData.flatEarningRate;
        earningMultiplier = thisBuildingData.earningMultiplierPerLevel;
        flatUpgradeCost = thisBuildingData.flatUpgradeCost;
        upgradeMultiplier = thisBuildingData.upgradeCostMultiplierPerLevel;

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
        //moneyPerSecond = moneyPerSecond * (1 + buildingInfluence/100);

        //calculate upgrade cost
        upgradeCost = (flatUpgradeCost * (upgradeMultiplier * (level + 1))); //scales linearly. move to purchaseUpgrade and fix equation to make it work properly. (upgradeCost = upgradeCost * upgradeMultiplier)


        //display
        moneyPerSecondText.text = "$/s: " + moneyPerSecond.ToString();
        upgradeButtonText.text = "Upgrade: " + upgradeCost.ToString() + "$";


        //limit income to 1 time per second
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            moneyManagement.AddMoney(moneyPerSecond);
            timer = 0;
        }    
    }

    //is called by pressing the prefab's upgrade button
    public void PurchaseUpgrade() 
    {
        //check if player has enough money
        if(upgradeCost <= moneyManagement.currentMoney) 
        {
            level++;
            moneyManagement.RemoveMoney(upgradeCost);
        }
    }


}
