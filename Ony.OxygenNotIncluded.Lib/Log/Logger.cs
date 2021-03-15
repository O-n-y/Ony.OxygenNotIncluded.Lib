using System;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace Ony.OxygenNotIncluded.Lib
{
	public class Logger
	{
		private static string _prefix;
		private static bool _isConsoleEnabled => ModInfoWrapper.ConsoleEnabled;

		public static void Init(string prefix)
		{
			_prefix           = prefix;
		}

		private static string Prefix => $"[{_prefix}][{Thread.CurrentThread.ManagedThreadId}]";
		public static void Print(string message)
		{
			if(!_isConsoleEnabled) return;

			Console.WriteLine($"\x1b[48;5;23m  {Prefix}: {message} \x1b[48;5;0m");
			
		}
		public static void Print(Component component)
		{
			if(!_isConsoleEnabled) return;

			Console.WriteLine($"\x1b[48;5;23m  {Prefix}: {component.name}: {component.GetType()}  \x1b[48;5;0m");
		}

		public static void PrintHeader(string message)
		{
			if(!_isConsoleEnabled) return;
			Console.WriteLine($"\x1b[48;5;24m  {Prefix}: {message} \x1b[48;5;0m");
			
		}

		public static void PrintStart(string message)
		{
			if (Console.Out.GetType().ToString() == "UnityEngine.UnityLogWriter")
			{
				Console.WriteLine($"{Prefix}: {message}");
				return;
			}

			Console.WriteLine($"\x1b[48;5;21m  {Prefix}: {message} \x1b[48;5;0m");
			
		}

		public static void Print(Exception message)
		{
			if(!_isConsoleEnabled) return;

			Console.WriteLine($"\x1b[48;5;1m  {Prefix}: {message} \x1b[48;5;0m");
		}


		public static void PrintError(string msg, string stackTrace)
		{
			if(!_isConsoleEnabled) return;

			Console.WriteLine($"\x1b[48;5;1m  {Prefix}: {msg}\n{stackTrace} \x1b[48;5;0m");
		}

		public static void PrintError(string msg)
		{
			if(!_isConsoleEnabled) return;

			var stackFrames = Environment.StackTrace.Split('\n').Skip(1).ToArray();
			var stackTrace  = string.Join("\n", stackFrames);

			Console.WriteLine($"\x1b[48;5;1m  {Prefix}: {msg}\n{stackTrace} \x1b[48;5;0m");
		}

		public static void PrintAction(string msg)
		{
			if(!_isConsoleEnabled) return;
			
			Console.WriteLine($"\x1b[48;5;3m  {Prefix}: {msg} \x1b[48;5;0m");
		}
	
	}

}
