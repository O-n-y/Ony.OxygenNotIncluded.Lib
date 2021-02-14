namespace Ony.OxygenNotIncluded.Lib
{
	public class LocalizeText
	{
		public string NAME;
		public string DESCRIPTION;

		public LocalizeText()
		{
			NAME = "";
			DESCRIPTION = "";
		}
		public LocalizeText(string name, string description)
		{
			NAME        = name;
			DESCRIPTION = description;
		}
	}
}