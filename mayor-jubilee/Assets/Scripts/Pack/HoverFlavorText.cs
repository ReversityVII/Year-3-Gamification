using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class HoverFlavorText : MonoBehaviour
{
    private TextMeshProUGUI flavourText;
    private SpriteRenderer backgroundImage;
  
    // Start is called before the first frame update
    void Start()
    {
        flavourText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        backgroundImage = gameObject.GetComponentInChildren<SpriteRenderer>();
        
        flavourText.enabled = false;
        backgroundImage.enabled = false;
    }

    private void OnMouseEnter()
    {
        print("firing");
        flavourText.enabled = true;
        backgroundImage.enabled = true;
    }

    private void OnMouseExit()
    {
        flavourText.enabled = false;
        backgroundImage.enabled = false;
    }
}
