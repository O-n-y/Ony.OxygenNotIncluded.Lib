using System;
using System.IO;
using System.Reflection;
using KMod;

namespace Ony.OxygenNotIncluded.Lib
{
	public abstract class StartUp<O,L> where L : class
	{
		private static IModInfo _modInfo;
		private static object   _instance;
		public static Mod ActiveMod => _modInfo.ActiveMod;
		public static string Id => _modInfo.Id;
		public static string Name=> _modInfo.Name;
		public static string ModDirectory => _modInfo.ModDirectory;
		public static string Version => _modInfo.Version;
		public static bool ConsoleEnabled => _modInfo.ConsoleEnabled;
		public static string GetModsFolder() => Path.Combine(Util.RootFolder(), "mods");
		public static AssemblyName AssemblyName => Assembly.GetExecutingAssembly().GetName();
		public static L Localization => LanguageSelection<L>.Get();

		public static void Print(string message) => Logger.Print(message);
		public static void PrintHeader(string message) => Logger.PrintHeader(message);
		public static void PrintStart(string message) => Logger.PrintStart(message);
		public static void PrintError(string message) => Logger.PrintError(message);
		
		
		public static void Start()
		{
			if(_instance != null) return;

			_instance = Activator.CreateInstance(typeof(O));
			_modInfo = new ModInfo();
			
		}
		
		
	}
}
