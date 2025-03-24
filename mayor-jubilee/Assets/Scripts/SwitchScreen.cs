using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Logic for switching between both screens.
 * Methods are called by clicking the button at the side of either screen (left for gacha, right for town).
 */
public class SwitchScreen : MonoBehaviour
{
    public enum availableScreens { Town, Gacha }
    public availableScreens currentScreen;
    public GameObject happinessSprite; //for some goddamn reason, the happiness sprite needs to be MANUALLY disabled if we don't want it showing on the gacha screen too.

    //reference every screen as a gameobject, use CamelCase (i.e. TownScreen)
    public GameObject[] screenReferences;

    //called by navigational buttons when the town screen should be visible
    public void EnableTownScreen()
    {
        //enable appropriate screen in array
        for (int i = 0; i < screenReferences.Length; i++)
        {
            if (screenReferences[i].name == "TownScreen")
            {
                //move the screen lower in hierarchy to make it appear above the others
                screenReferences[i].transform.SetSiblingIndex(1);
                //happinessSprite.GetComponent<SpriteRenderer>().enabled = true;
            }
                
            else
                screenReferences[i].transform.SetSiblingIndex(0);
        }
        currentScreen = availableScreens.Town;
    }

    //called by navigational buttons when the town screen should be visible
    public void EnableGachaScreen()
    {
        //enable appropriate screen in array
        for (int i = 0; i < screenReferences.Length; i++)
        {
            if (screenReferences[i].name == "GachaScreen")
            {
                //move the screen lower in hierarchy to make it appear above the others
                screenReferences[i].transform.SetSiblingIndex(1);
                //happinessSprite.GetComponent<SpriteRenderer>().enabled = false;
            }

            else
                screenReferences[i].transform.SetSiblingIndex(0);
        }

        currentScreen = availableScreens.Gacha;
    }
}
