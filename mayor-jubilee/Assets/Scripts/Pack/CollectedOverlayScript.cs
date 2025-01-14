using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectedOverlayScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI flavourText;
    public Canvas canvas;


    void Start()
    {

    }

    // Start is called before the first frame update
    public void SetImage(Texture texture, string FlavourText)
    {
        this.GetComponentInChildren<RawImage>().texture = texture;
        flavourText.text = FlavourText;
    }

    public void ExitScreen()
    {
        Destroy(this.gameObject);
    }
}
