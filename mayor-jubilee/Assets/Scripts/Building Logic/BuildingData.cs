using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * All of the relevant aspects to each individual building prefab.
 * To create a new building, reference the list in BuildingManager, attached to the GameObject "AllScreens"
 */
[Serializable]
public class BuildingData
{
    public string name;

    public GameObject positionNode;

    public Image icon;

    public float flatEarningRate;

    public float earningMultiplierPerLevel;

    public float flatUpgradeCost;

    public float upgradeCostMultiplierPerLevel;

    public int buildingNumber;
}
