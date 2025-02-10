namespace SheetCodes
{
	//Generated code, do not edit!

	public enum CharactersIdentifier
	{
		[Identifier("None")] None = 0,
		[Identifier("TestCharacter")] Testcharacter = 1,
		[Identifier("test guy 2 ")] TestGuy2 = 2,
		[Identifier("test char 3")] TestChar3 = 3,
		[Identifier("Character 5")] Character5 = 5,
		[Identifier("test character 4")] TestCharacter4 = 4,
	}

	public static class CharactersIdentifierExtension
	{
		public static CharactersRecord GetRecord(this CharactersIdentifier identifier, bool editableRecord = false)
		{
			return ModelManager.CharactersModel.GetRecord(identifier, editableRecord);
		}
	}
}
