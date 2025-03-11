using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectedOverlayScript : MonoBehaviour
{
    [SerializeField]
    public GameObject image;
    public GameObject background;
    public TextMeshProUGUI flavourText;
    public Canvas canvas;
    public float XSize;
    public float YSize;

    void Start()
    {

    }

    // Start is called before the first frame update
    public void SetImage(CharacterData temp)
    {
        CharacterData character = temp;
        image.GetComponent<RawImage>().texture = character.SpriteTexture;
        background.GetComponent<RawImage>().texture = character.backgroundUsed;
        flavourText.text = character.FlavourText;

        if(character.isHorizontal)
        {
            image.GetComponent<RectTransform>().sizeDelta = new Vector2(XSize, YSize);
        } else
        {
            image.GetComponent<RectTransform>().sizeDelta = new Vector2(YSize, XSize);
        }
    }

    public void ExitScreen()
    {
        Destroy(this.gameObject);
    }
}
