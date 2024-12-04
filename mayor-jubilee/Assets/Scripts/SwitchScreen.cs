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
        //adjust hierarchy to show appropriate layer
        for (int i = 0; i < screenReferences.Length; i++)
        {
            if (screenReferences[i].name == "TownScreen")
                screenReferences[i].transform.SetSiblingIndex(1);
            
            else
                screenReferences[i].transform.SetSiblingIndex(0);
        }
    }

    public void EnableGachaScreen()
    {
        for (int i = 0; i < screenReferences.Length; i++)
        {
            if (screenReferences[i].name == "GachaScreen")
                screenReferences[i].transform.SetSiblingIndex(1);

            else
                screenReferences[i].transform.SetSiblingIndex(0);
        }
    }
}
