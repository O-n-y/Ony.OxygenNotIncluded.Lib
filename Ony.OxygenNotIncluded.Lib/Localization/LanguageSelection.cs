using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Harmony;

namespace Ony.OxygenNotIncluded.Lib
{

	public class LanguageSelection<T> where T: class
	{
		private static          Localization.Locale       _locale;
		private static readonly Dictionary<Localization.Language, T> _cache = new Dictionary<Localization.Language, T>();

		public static T Get()
		{
			if (_locale == null)
			{
				_locale = (Localization.Locale) AccessTools.Field(typeof(Localization), "sLocale").GetValue(null);
				if (_locale != null)
					Logger.PrintAction($"found locale: {_locale.Lang} {_locale.FontName} {_locale.Code}");
			}

			if (_locale == null)
			{
				return GetTranslationCache(Localization.Language.Unspecified);
			}

			var data = GetTranslationCache(_locale.Lang);

			//if(data == null)
			//	Logger.Print($"No Localization found for language: {_locale.Lang}, using default");

			return data ?? GetTranslationCache(Localization.Language.Unspecified);
		}

		private static T GetTranslationCache(Localization.Language lang)
		{
			if (_cache.TryGetValue(lang, out var value))
				return value;
			return _cache[lang] = GetTranslation(lang);
		}

		private static T GetTranslation(Localization.Language lang)
		{
			if (_cache.TryGetValue(lang, out var val))
				return val;

			var baseType = typeof(T);
			foreach (var type in Assembly.GetExecutingAssembly().GetTypesWithAttribute<TranslationAttribute>().Where(u=> u.BaseType == baseType))
			{
				var attribute = type.GetCustomAttributes(typeof(TranslationAttribute), true).Cast<TranslationAttribute>().First();
			
				_cache[attribute.Language] = (T)Activator.CreateInstance(type);
			}
			if (_cache.TryGetValue(lang, out val))
				return val;
			return null;
		}
	}
}
