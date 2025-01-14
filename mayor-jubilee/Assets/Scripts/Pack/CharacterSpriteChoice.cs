using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Handles setting an image to the character that is unlocked.
 * Gets called when the character is initialized.
 */

public class CharacterSpriteChoice : MonoBehaviour
{
    public List<Texture> possibleSprites;
    public RawImage spriteImage; 

    //choose an image to represent the character
    public Texture ImageInitialization(int imageChoice)
    {
        //set an image for the sprite in child
        spriteImage = GetComponent<RawImage>();
        spriteImage.texture = possibleSprites[imageChoice];
        return possibleSprites[imageChoice];
    }
}
