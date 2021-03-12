using KMod;

namespace Ony.OxygenNotIncluded.Lib
{
	public interface IModInfo
	{
		string Id { get; }
		string Name { get;  }
		string ModDirectory{ get;}
		string Version { get; }
		bool ConsoleEnabled{ get; }

		Mod ActiveMod { get; }
	
	}
}