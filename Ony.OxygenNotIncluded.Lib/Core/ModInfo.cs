using System;
using System.IO;
using System.Linq;
using System.Reflection;
using KMod;

namespace Ony.OxygenNotIncluded.Lib
{
	public class ModInfo : IModInfo
	{
		public string Id { get; }
		public string Name { get; }
		public string ModDirectory { get; }
		public Mod ActiveMod { get; }
		public string Version { get; }
		public bool ConsoleEnabled => true;


		public ModInfo()
		{
			var version = Assembly.GetExecutingAssembly().GetName().Version;
			Version = version.ToString();

			Name = ((AssemblyTitleAttribute) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute), false)).Title;
			Id   = ((AssemblyConfigurationAttribute) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyConfigurationAttribute), false)).Configuration;

			ModDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			var info = new DirectoryInfo(ModDirectory).FullName;

			var local = !ModDirectory.ToLower().Contains("steam");
			ActiveMod = Global.Instance.modManager.mods.FirstOrDefault(mod => new DirectoryInfo(mod.ContentPath).FullName == info || mod.ContentPath.Contains(Id) && !local);

			ModInfoWrapper.Initialize(this);
			
			Logger.Start($"Version: {Version} initialized");
		}
	}
}