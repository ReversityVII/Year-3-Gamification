using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
