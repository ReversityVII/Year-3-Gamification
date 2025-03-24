using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam;
    public Vector3 townLoc;
    public Vector3 gatchaLoc;
    public float cameraSpeed = 1;

    private Vector3 targetRot;
    private Vector3 targetLoc;
    public void SwitchToTown()
    {
        targetRot = new Vector3(0, 0, 0);
        targetLoc = townLoc;
    }

    public void SwitchToGacha()
    {
        //cam.transform.eulerAngles
        targetRot = new Vector3(0, 180, 0);
        targetLoc = gatchaLoc;
    }

    private void Update()
    {
        cam.transform.eulerAngles = Vector3.Lerp(cam.transform.eulerAngles, targetRot, Time.deltaTime*cameraSpeed);
        cam.transform.position = Vector3.Lerp(cam.transform.position, targetLoc, Time.deltaTime * cameraSpeed);
;    }
}
