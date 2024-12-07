namespace SheetCodes
{
	//Generated code, do not edit!

	public enum CharactersIdentifier
	{
		[Identifier("None")] None = 0,
		[Identifier("TestCharacter")] Testcharacter = 1,
		[Identifier("test guy 2 ")] TestGuy2 = 2,
	}

	public static class CharactersIdentifierExtension
	{
		public static CharactersRecord GetRecord(this CharactersIdentifier identifier, bool editableRecord = false)
		{
			return ModelManager.CharactersModel.GetRecord(identifier, editableRecord);
		}
	}
}
