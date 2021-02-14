# Ony.OxygenNotIncluded.Lib
Library for creating Mods for Oxygen Not Included 


Will help to create mods more easily.

## Provides:
0. Mod auto-loading
1. Localization module
2. Settings module
3. Utility functions


# Localization usage example:

Create **TranslationMod** sub-class from **TranslationBase** with desire set of strings to localize:

```csharp
public abstract  class TranslationMod : TranslationBase 
	{
		public abstract LocalizeText MAX_DUPES_TO_PRINT {get; }
		public abstract LocalizeText TITLE {get; }
		public abstract LocalizeText ATTRIBUTES {get; }
		public abstract LocalizeText CHANGE_BUTTON {get; }
  }

```
Create desire languages sub-classes from **TranslationMod**:

English:
```csharp
[Translation(Language = Localization.Language.Unspecified)]
	public class TranslationEn : TranslationMod
	{
		public override LocalizeText MAX_DUPES_TO_PRINT => new LocalizeText("Print only care packages, when have alive Duplicants count", "No Duplicants will be proposed to be printed, if you already have at least this amount. Instead all options will be proposed as care packages");
		public override LocalizeText TITLE => new LocalizeText("Duplicant configuration", "");
		public override LocalizeText ATTRIBUTES => new LocalizeText("\n<b>ATTRIBUTES</b>", "Select attributes of your choice");
		public override LocalizeText CHANGE_BUTTON => new LocalizeText("CHANGE", "Skip to next");
	}
```

Russian:
```csharp
	[Translation(Language = Localization.Language.Russian)]
	public class TranslationRu : TranslationMod
	{
		
		public override LocalizeText MAX_DUPES_TO_PRINT => new LocalizeText("Предлагать к печати Дупликантов, если живых менее", "Биопринтер более не будет предлагать к печати Дупликантов, если уже есть заданное количество живых. Вместо этого к печати будут предложены только пакеты гуманитарной помощи.");
		public override LocalizeText TITLE => new LocalizeText("Настройка черт Дупликанта", "");
		public override LocalizeText ATTRIBUTES => new LocalizeText("\n<b>ХАРАКТЕРИСТИКИ</b>", "Выберите, какими характеристиками должен обладать Дупликант");
		public override LocalizeText CHANGE_BUTTON => new LocalizeText("ИЗМЕНИТЬ", "Выбрать следующий");
    
    }
```
Each class should have **TranslationAttribute** set to language it provide. 
Unspecified - for english (default language).

## Usage:
```
public static L Localization => LanguageSelection<L>.Get();

....

var titleName = Localization.TITLE.NAME;
```




