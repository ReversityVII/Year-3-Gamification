using SheetCodes;
using TMPro;
using UnityEngine;

/*
 * Handles instantiating and intializing a character (or figure, the terminology is interchangeable) when the player buys a pack.
 * puts the character where they need to go, and reimburses the player if they already have this character. 
 */

public class FigureBehaviour : MonoBehaviour
{
    //player-facing display logic
    private GameObject positionNode; 
    private MoneyManagement moneyManagement;
    private TextMeshProUGUI flavourText;

    //building and script for the building that gets affected by the character
    private GameObject affectedBuildingSlot;
    private BuildingBehaviour affectedBuilding;

    //character data inherited from UnlockPack when Initialize is called
    CharactersIdentifier character;

    //script to change the sprite for the character as appropriate
    CharacterSpriteChoice characterSpriteChoice;

    //called by UnlockPack, handles displaying the character that was earned in the pack
    public void Initialize(CharactersIdentifier temp, float packCost)
    {
        character = temp;

        //find its listed position node according to the sheet
        positionNode = GameObject.Find("Character Slot " + character.GetRecord(false).Nodenumber);
        gameObject.transform.position = positionNode.transform.position;
        gameObject.transform.SetParent(positionNode.transform, true);

        //check if this figure already exists
        if(GameObject.Find(character.GetRecord(false).Name))
            {
            //if so, add money instead and then delete the object
            moneyManagement = GameObject.FindObjectOfType<MoneyManagement>();
            moneyManagement.AddMoney(packCost / 5); //reimburse 20 percent of what it cost

            print("Already exists, destroying!");
            Destroy(this.gameObject);
            }

        gameObject.name = character.GetRecord(false).Name;

        //reference the building that this figure influences
        affectedBuildingSlot = GameObject.Find("Building Slot " + character.GetRecord(false).BuildingSlotAffected);
        affectedBuilding = affectedBuildingSlot.GetComponentInChildren<BuildingBehaviour>();

        //influence the building money production
        affectedBuilding.buildingInfluence += character.GetRecord(false).Percentageearningboost;

        //find and update text
        flavourText = (TextMeshProUGUI) gameObject.GetComponentInChildren(typeof(TextMeshProUGUI));
        flavourText.text = character.GetRecord(false).FlavourText;

        //call script to update character sprite to preference
        int spriteChoice = character.GetRecord(false).Usedsprite;
        characterSpriteChoice = gameObject.GetComponent<CharacterSpriteChoice>();
        characterSpriteChoice.ImageInitialization(spriteChoice);

    }
}
