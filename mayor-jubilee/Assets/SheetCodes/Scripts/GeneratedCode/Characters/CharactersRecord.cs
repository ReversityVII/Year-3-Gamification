using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SheetCodes
{
	//Generated code, do not edit!

	[Serializable]
	public class CharactersRecord : BaseRecord<CharactersIdentifier>
	{
		[ColumnName("Name")] [SerializeField] private string _name = default;
		public string Name { get { return _name; } set { if(!CheckEdit()) return; _name = value; }}

		//Does this type no longer exist? Delete from here..
		[ColumnName("Icon")] [SerializeField] private UnityEngine.Texture _icon = default;
		public UnityEngine.Texture Icon 
		{ 
			get { return _icon; } 
            set
            {
                if (!CheckEdit())
                    return;
#if UNITY_EDITOR
                if (value != null)
                {
                    string assetPath = AssetDatabase.GetAssetPath(value);
                    if(string.IsNullOrEmpty(assetPath))
                    {
                        Debug.LogError("SheetCodes: Reference Objects must be a direct reference from your project folder.");
                        return;
                    }
                }
                _icon = value;
#endif
            }
        }
		//..To here

		//Does this type no longer exist? Delete from here..
		[ColumnName("Sprite")] [SerializeField] private UnityEngine.Texture _sprite = default;
		public UnityEngine.Texture Sprite 
		{ 
			get { return _sprite; } 
            set
            {
                if (!CheckEdit())
                    return;
#if UNITY_EDITOR
                if (value != null)
                {
                    string assetPath = AssetDatabase.GetAssetPath(value);
                    if(string.IsNullOrEmpty(assetPath))
                    {
                        Debug.LogError("SheetCodes: Reference Objects must be a direct reference from your project folder.");
                        return;
                    }
                }
                _sprite = value;
#endif
            }
        }
		//..To here

		[ColumnName("UnlockChance")] [SerializeField] private float _unlockchance = default;
		public float Unlockchance { get { return _unlockchance; } set { if(!CheckEdit()) return; _unlockchance = value; }}

		//Does this type no longer exist? Delete from here..
		[ColumnName("Rarity")] [SerializeField] private Enumerators.characterRarity _rarity = default;
		public Enumerators.characterRarity Rarity { get { return _rarity; } set { if(!CheckEdit()) return; _rarity = value; }}
		//..To here

		[ColumnName("NodeNumber")] [SerializeField] private int _nodenumber = default;
		public int Nodenumber { get { return _nodenumber; } set { if(!CheckEdit()) return; _nodenumber = value; }}

		[ColumnName("PercentageEarningBoost")] [SerializeField] private float _percentageearningboost = default;
		public float Percentageearningboost { get { return _percentageearningboost; } set { if(!CheckEdit()) return; _percentageearningboost = value; }}

		[ColumnName("Building Slot Affected")] [SerializeField] private int _buildingSlotAffected = default;
		public int BuildingSlotAffected { get { return _buildingSlotAffected; } set { if(!CheckEdit()) return; _buildingSlotAffected = value; }}

		[ColumnName("Flavour text")] [SerializeField] private string _flavourText = default;
		public string FlavourText { get { return _flavourText; } set { if(!CheckEdit()) return; _flavourText = value; }}

		[ColumnName("UsedSprite")] [SerializeField] private int _usedsprite = default;
		public int Usedsprite { get { return _usedsprite; } set { if(!CheckEdit()) return; _usedsprite = value; }}

        protected bool runtimeEditingEnabled { get { return originalRecord != null; } }
        public CharactersModel model { get { return ModelManager.CharactersModel; } }
        private CharactersRecord originalRecord = default;

        public override void CreateEditableCopy()
        {
#if UNITY_EDITOR
            if (runtimeEditingEnabled)
                return;

            CharactersRecord editableCopy = new CharactersRecord();
            editableCopy.Identifier = Identifier;
            editableCopy.originalRecord = this;
            CopyData(editableCopy);
            model.SetEditableCopy(editableCopy);
#else
            Debug.LogError("SheetCodes: Creating an editable record does not work in buolds. See documentation 'Editing your data at runtime' for more information.");
#endif
        }

        public override void SaveToScriptableObject()
        {
#if UNITY_EDITOR
            if (!runtimeEditingEnabled)
            {
                Debug.LogWarning("SheetCodes: Runtime Editing is not enabled for this object. Either you are not using the editable copy or you're trying to edit in a build.");
                return;
            }
            CopyData(originalRecord);
            model.SaveModel();
#else
            Debug.LogError("SheetCodes: Saving to ScriptableObject does not work in builds. See documentation 'Editing your data at runtime' for more information.");
#endif
        }

        private void CopyData(CharactersRecord record)
        {
            record._name = _name;
            record._icon = _icon;
            record._sprite = _sprite;
            record._unlockchance = _unlockchance;
            record._rarity = _rarity;
            record._nodenumber = _nodenumber;
            record._percentageearningboost = _percentageearningboost;
            record._buildingSlotAffected = _buildingSlotAffected;
            record._flavourText = _flavourText;
            record._usedsprite = _usedsprite;
        }

        private bool CheckEdit()
        {
            if (runtimeEditingEnabled)
                return true;

            Debug.LogWarning("SheetCodes: Runtime Editing is not enabled for this object. Either you are not using the editable copy or you're trying to edit in a build.");
            return false;
        }
    }
}
