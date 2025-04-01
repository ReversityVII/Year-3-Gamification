using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HappinessDisplay : MonoBehaviour
{
    public float happinessLevel;
    public Sprite[] happinessSprites;
    //public GameObject happinessDisplayObject;

    //Used for changing the sprites
    //public BuildingBehaviour buildingBehaviour;

    public float buildingLevel;
    // Start is called before the first frame update
    void Start()
    {
        happinessLevel = 10; 
    }

    public void changeHappiness(float value) //increase or decrease
    {
        happinessLevel += value;
        updateHappinessSprite();
    }

    void Update()
    {
        //clamp happiness level between 0-10
        Mathf.Clamp(happinessLevel, 0, 10);
       
    }

    void updateHappinessSprite()
    {
        int happinessSpriteChosen;

        if (happinessLevel <= 5) //low happiness
        {
            happinessSpriteChosen = 0;

            buildingLevel = 0;

            //Enables low building Sprite
            //buildingBehaviour.lowBuilding = true;
            //buildingBehaviour.midBuilding = false;
            //buildingBehaviour.highBuilding= false;

        }
        else if (happinessLevel <= 7) //mid happiness
        {
            happinessSpriteChosen = 1;

            buildingLevel = 1;

            //Enables Mid building Sprite
            //buildingBehaviour.lowBuilding = false;
            //buildingBehaviour.midBuilding = true;
            //buildingBehaviour.highBuilding = false;
        }
        else //high happiness
        {
            happinessSpriteChosen = 2;

            buildingLevel = 2;

            //Enables High Building Sprite
            //buildingBehaviour.lowBuilding = false;
            //buildingBehaviour.midBuilding = false;
            //buildingBehaviour.highBuilding = true;

        }

        //gameObject.GetComponent<SpriteRenderer>().sprite = happinessSprites[happinessSpriteChosen];
        gameObject.GetComponent<Image>().sprite = happinessSprites[happinessSpriteChosen];
    }

}
