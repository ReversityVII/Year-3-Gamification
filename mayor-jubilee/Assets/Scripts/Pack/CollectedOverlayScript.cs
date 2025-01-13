using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CollectedOverlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetImage(Texture texture)
    {
        this.GetComponent<RawImage>().texture = texture;
    }
}
