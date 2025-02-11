using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using SheetCodes;

public class HoverFlavorText : MonoBehaviour
{
    private TextMeshProUGUI flavourText;
    private SpriteRenderer backgroundImage;

    private bool isHorizontal;

    //CharacterData character;


    // Start is called before the first frame update
    public void Initialize(CharacterData temp)
    {
        flavourText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        backgroundImage = gameObject.GetComponentInChildren<SpriteRenderer>();
        
        flavourText.enabled = false;
        backgroundImage.enabled = false;

        isHorizontal = temp.isHorizontal;
    }

    private void OnMouseEnter()
    {
        if(isHorizontal)
            //increase size by 2
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x * 2.5f, gameObject.GetComponent<RectTransform>().sizeDelta.y * 2.5f);
        else
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x * 2f, gameObject.GetComponent<RectTransform>().sizeDelta.y * 2f);

        flavourText.enabled = true;
        backgroundImage.enabled = true;
    }

    private void OnMouseExit()
    {
        if (isHorizontal)
            //decrease size by 2
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x / 2.5f, gameObject.GetComponent<RectTransform>().sizeDelta.y / 2.5f);
        else
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x / 2f, gameObject.GetComponent<RectTransform>().sizeDelta.y / 2f);

        flavourText.enabled = false;
        backgroundImage.enabled = false;
    }
}
