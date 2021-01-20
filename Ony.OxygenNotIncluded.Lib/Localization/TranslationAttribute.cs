using System;

namespace Ony.OxygenNotIncluded.Lib
{
	public class TranslationAttribute : Attribute
	{
		public Localization.Language Language { get; set; }
	}
}
