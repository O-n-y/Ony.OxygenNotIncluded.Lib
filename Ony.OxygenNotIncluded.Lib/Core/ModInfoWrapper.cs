using System;
using System.Runtime.InteropServices;
using KMod;
using UnityEngine;

namespace Ony.OxygenNotIncluded.Lib
{
	internal static class ModInfoWrapper 
	{
		
		private static IModInfo _modInfo;
		public static string Id => _modInfo.Id;
		public static string Name=> _modInfo.Name;
		public static string ModDirectory => _modInfo.ModDirectory;
		public static string Version => _modInfo.Version;
		public static Mod ActiveMod => _modInfo.ActiveMod;
		public static bool ConsoleEnabled
		{
			get
			{
				if (Application.platform != RuntimePlatform.WindowsPlayer && Application.platform != RuntimePlatform.WindowsEditor)
				{
					return false;
				}
				return _modInfo.ConsoleEnabled && HaveConsole;
			}
		}
		
		private const uint ATTACH_PARENT_PROCESS = 0x0ffffffff;
		private const int  ERROR_ACCESS_DENIED   = 5;
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool AttachConsole(uint dwProcessId);
		[DllImport("kernel32", SetLastError = true)]
		private static extern bool FreeConsole();

		private static bool _haveConsole = false;
		public static bool HaveConsole
		{
			get
			{
				if (_haveConsole) return true;
				if (Console.Out.GetType().ToString() == "UnityEngine.UnityLogWriter") return false;
				if (AttachConsole(ATTACH_PARENT_PROCESS))
				{
					FreeConsole();
					return false;
				}

				var error = Marshal.GetLastWin32Error();
				return _haveConsole = error == ERROR_ACCESS_DENIED;
			}
		}

		
		public static void Initialize(IModInfo modInfo)
		{
			_modInfo = modInfo;
			Logger.Init(_modInfo.Name);
		}

	}
}