using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SheetCodes;
using System;

public class UnlockPack : MonoBehaviour
{

    public TextMeshProUGUI unlockButton;

    public void UnlockPackage()
    {
        //Gets characters sheet row enums as an array
        CharactersIdentifier[] Indexes = Enum.GetValues(typeof(CharactersIdentifier)) as CharactersIdentifier[];

        //picks a array element at random
        int randomCharacter = UnityEngine.Random.Range(1, Indexes.Length);

        //gets a random row from the list based on random number
        string name = ModelManager.CharactersModel.GetRecord(Indexes[randomCharacter]).Name;s

        //displays name
        Debug.Log(name);
    }
}
