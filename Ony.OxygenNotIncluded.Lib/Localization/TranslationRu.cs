namespace Ony.OxygenNotIncluded.Lib
{
	[Translation(Language = Localization.Language.Russian)]
	internal  class TranslationRu : TranslationBase
	{
		#region Config

		public override LocalizeText CONFIG => new LocalizeText("Конфиг", "");
		public override LocalizeText MOD_SETTINGS => new LocalizeText("Настройки мода", "");
		public override LocalizeText SAVE => new LocalizeText("Сохранить", "");
		public override LocalizeText NUMERIC_UP_DOWN => new LocalizeText("", "Зажмите Shift, чтобы изменить значение на 10 за один клик\nЗажмите Shift+Ctrl, чтобы изменить значение на 100 за один клик");
		public override LocalizeText CHANGE_HOTKEY => new LocalizeText("Нажмите сочетание клавиш на клавиатуре, чтобы изменить\n{0}\n(Нажмите <Delete>, чтобы удалить привязку)", "");
		public override LocalizeText UNBIND => new LocalizeText("Чтобы удалить привязку: нажмите \"Delete\", находясь на экране изменения привязки", "");
		public override LocalizeText UNBIND_ALL  => new LocalizeText("Удалить все привязки", "");

		#endregion
		
	}
}