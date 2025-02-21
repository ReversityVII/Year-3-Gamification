using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfAfterTime : MonoBehaviour
{
    public float timeInSeconds;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeInSeconds)
        {
            Destroy(gameObject);
        }
    }
}
