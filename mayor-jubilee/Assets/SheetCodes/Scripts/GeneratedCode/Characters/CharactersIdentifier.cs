namespace SheetCodes
{
	//Generated code, do not edit!

	public enum CharactersIdentifier
	{
		[Identifier("None")] None = 0,
		[Identifier("Comet")] Comet = 1,
		[Identifier("Earth")] Earth = 2,
		[Identifier("Moon")] Moon = 3,
		[Identifier("BlackHole")] Blackhole = 5,
		[Identifier("Sun")] Sun = 4,
		[Identifier("Fodder1")] Fodder1 = 6,
		[Identifier("Fodder2")] Fodder2 = 7,
		[Identifier("Fodder3")] Fodder3 = 8,
		[Identifier("Fodder4")] Fodder4 = 9,
		[Identifier("Fodder5")] Fodder5 = 10,
	}

	public static class CharactersIdentifierExtension
	{
		public static CharactersRecord GetRecord(this CharactersIdentifier identifier, bool editableRecord = false)
		{
			return ModelManager.CharactersModel.GetRecord(identifier, editableRecord);
		}
	}
}
