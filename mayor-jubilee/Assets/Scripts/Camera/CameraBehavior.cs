using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam;
    public void SwitchToTown()
    {
        cam.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void SwitchToGacha()
    {
        cam.transform.eulerAngles = new Vector3(0, 180, 0);
    }
}
