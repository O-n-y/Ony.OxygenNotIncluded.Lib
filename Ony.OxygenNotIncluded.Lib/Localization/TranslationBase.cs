namespace Ony.OxygenNotIncluded.Lib
{
	public abstract class TranslationBase 
	{
		public virtual LocalizeText CONFIG => LanguageSelection<TranslationBase>.Get().CONFIG;
		public virtual LocalizeText MOD_SETTINGS=> LanguageSelection<TranslationBase>.Get().MOD_SETTINGS;
		public virtual LocalizeText SAVE => LanguageSelection<TranslationBase>.Get().SAVE;
		public virtual LocalizeText NUMERIC_UP_DOWN => LanguageSelection<TranslationBase>.Get().NUMERIC_UP_DOWN;
		public virtual LocalizeText CHANGE_HOTKEY => LanguageSelection<TranslationBase>.Get().CHANGE_HOTKEY;
		public virtual LocalizeText UNBIND => LanguageSelection<TranslationBase>.Get().UNBIND;
		public virtual LocalizeText UNBIND_ALL => LanguageSelection<TranslationBase>.Get().UNBIND_ALL;

	}

	
}