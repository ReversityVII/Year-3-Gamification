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
        }
        else if (happinessLevel <= 7) //mid happiness
        {
            happinessSpriteChosen = 1;
        }
        else //high happiness
        {
            happinessSpriteChosen = 2;
        }

        //gameObject.GetComponent<SpriteRenderer>().sprite = happinessSprites[happinessSpriteChosen];
        gameObject.GetComponent<Image>().sprite = happinessSprites[happinessSpriteChosen];
    }

}
