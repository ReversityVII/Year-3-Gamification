using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScreen : MonoBehaviour
{
    //reference every screen as a gameobject, use CamelCase (i.e. TownScreen)
    public GameObject[] screenReferences; 

    public void EnableTownScreen()
    {
        print("called");

        for (int i = 0; i < screenReferences.Length; i++) 
        {
            if (screenReferences[i].name == "TownScreen")
            {
                print("found");
                screenReferences[i].SetActive(true);
            } 
            else
                screenReferences[i].SetActive(false);
        }
    }

    public void EnableGachaScreen()
    {
        print("called");

        for (int i = 0; i < screenReferences.Length; i++)
        {
            if (screenReferences[i].name == "GachaScreen")
            {
                print("found");
                screenReferences[i].SetActive(true);
            }
            else
                screenReferences[i].SetActive(false);
        }
    }
}
