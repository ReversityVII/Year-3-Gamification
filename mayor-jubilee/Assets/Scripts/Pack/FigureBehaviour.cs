using SheetCodes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FigureBehaviour : MonoBehaviour
{
    private GameObject positionNode; 
    private MoneyManagement moneyManagement;
    private TextMeshProUGUI flavourText;

    private GameObject affectedBuildingSlot;
    private BuildingBehaviour affectedBuilding;

    CharactersIdentifier character;

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

    }
}