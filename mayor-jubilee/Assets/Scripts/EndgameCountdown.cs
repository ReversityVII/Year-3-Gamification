using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndgameCountdown : MonoBehaviour
{
    public float totalTimeTilEnd;
    private float timer = 0;
    private float timeInIngameDays;

    public Color[] textColors;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //calculate time in ingame days
        timeInIngameDays = totalTimeTilEnd - timer;
        timeInIngameDays = timeInIngameDays / 60; //each day is a minute

        //update text display
        gameObject.GetComponent<TextMeshProUGUI>().text = Mathf.RoundToInt(timeInIngameDays) + " DAYS";

        //update text color to match general urgency
        if (timer > totalTimeTilEnd * 0.75) //>75% of time elapsed
        {
            gameObject.GetComponent<TextMeshProUGUI>().color = textColors[2]; //RED
        }
        else if (timer > totalTimeTilEnd * 0.50) //>50% of time elapsed
        {
            gameObject.GetComponent<TextMeshProUGUI>().color = textColors[1]; //ORANGE
        }
        else
        {
            gameObject.GetComponent<TextMeshProUGUI>().color = textColors[0]; //GREEN
        }
    }
}
