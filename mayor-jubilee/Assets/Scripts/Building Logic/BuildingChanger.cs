using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingChanger : MonoBehaviour
{
    public GameObject School;
    public GameObject SchoolV2;

    public int timesCalledSchool;

    void Start()
    {
        School.SetActive(true);
        SchoolV2.SetActive(false);

    }

    void Update()
    {
        //Debug.Log(timesCalledSchool);
        //Debug.Log("Chilling");

        if (timesCalledSchool == 1)
        {
            //Debug.Log("Disaster");
            School.SetActive(false);
            SchoolV2.SetActive(true);
        }
    }
}
