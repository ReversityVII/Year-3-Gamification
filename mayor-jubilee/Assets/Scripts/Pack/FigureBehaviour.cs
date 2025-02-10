using SheetCodes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    public RectTransform imageTransform;
    public float XSize;
    public float YSize;

    [SerializeField] private GameObject overlayScreen;

    //building and script for the building that gets affected by the character
    private GameObject affectedBuildingSlot;
    private BuildingBehaviour affectedBuilding;

    //character data inherited from UnlockPack when Initialize is called
    //CharactersIdentifier character;
    CharacterData character;

    //script to change the sprite for the character as appropriate
    CharacterSpriteChoice characterSpriteChoice;

    //called by UnlockPack, handles displaying the character that was earned in the pack
    public void Initialize(CharacterData temp, float packCost)
    {
        character = temp;

        //find its listed position node according to the sheet
        positionNode = GameObject.Find("Character Slot " + character.NodeNumber);
        gameObject.transform.position = positionNode.transform.position;
        gameObject.transform.SetParent(positionNode.transform, true);

        //check if this figure already exists
        if(GameObject.Find(character.Name))
            {
            //if so, add money instead and then delete the object
            //moneyManagement = GameObject.FindObjectOfType<MoneyManagement>();
            //moneyManagement.AddMoney(packCost / 5); //reimburse 20 percent of what it cost
            Destroy(this.gameObject);
            }

        gameObject.name = character.Name;

        //INFLUENCE BUILDING
        //reference the building that this figure influences
        //affectedBuildingSlot = GameObject.Find("Building Slot " + character.GetRecord(false).BuildingSlotAffected);
        //affectedBuilding = affectedBuildingSlot.GetComponentInChildren<BuildingBehaviour>();

        //influence the building money production
        //affectedBuilding.buildingInfluence += character.GetRecord(false).Percentageearningboost;


        //find and update text
        flavourText = (TextMeshProUGUI) gameObject.GetComponentInChildren(typeof(TextMeshProUGUI));
        string grabbedFlavourText = character.FlavourText;
        flavourText.text = grabbedFlavourText;

        //call script to update character sprite to preference
        //int spriteChoice = character.Usedsprite;
        characterSpriteChoice = gameObject.GetComponent<CharacterSpriteChoice>();
        Texture charImage = character.SpriteTexture;
        characterSpriteChoice.SetTexture(character.SpriteTexture);

        if(character.isHorizontal)
        {
            imageTransform.sizeDelta = new Vector2(XSize, YSize);
            flavourText.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0f, -2.723f);
        } else
        {
            imageTransform.sizeDelta = new Vector2(YSize, XSize);
            flavourText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -4.101013f);
        }

        //instantiate overlay prefab
        GameObject overlay = GameObject.Instantiate(overlayScreen, Vector3.zero, Quaternion.identity);
        overlay.GetComponent<CollectedOverlayScript>().SetImage(character);
    }
}
