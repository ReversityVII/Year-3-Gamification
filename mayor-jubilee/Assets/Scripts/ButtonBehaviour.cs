using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    SwitchScreen switchScreen;

    private void Start()
    {
        //find the SwitchScreen script in scene
        switchScreen = FindObjectOfType<SwitchScreen>();
    }

    public void OnClick()
    {
        Debug.Log("ifjhosjhw");
    }
}
