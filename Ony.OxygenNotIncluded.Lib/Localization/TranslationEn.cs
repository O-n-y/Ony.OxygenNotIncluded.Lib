namespace Ony.OxygenNotIncluded.Lib
{
	[Translation(Language = Localization.Language.Unspecified)]
	internal class TranslationEn : TranslationBase
	{
		#region Config

		public override LocalizeText CONFIG => new LocalizeText( "Config", "");
		public override LocalizeText MOD_SETTINGS => new LocalizeText("Mod Settings", "");
		public override LocalizeText SAVE => new LocalizeText("Save", "");
		public override LocalizeText NUMERIC_UP_DOWN => new LocalizeText("", "Hold Shift to alter value for 10 at once\nHold Shift+Ctrl to alter value for 100 at once");
		public override LocalizeText CHANGE_HOTKEY =>  new LocalizeText("Press HotKey combination to change\n{0}", "");
		public override LocalizeText UNBIND =>  new LocalizeText("To Unbind: Press \"Delete\" while on changing HotKey screen", "");
		public override LocalizeText UNBIND_ALL =>  new LocalizeText("Unbind All", "");

		#endregion

		
	}
	
}