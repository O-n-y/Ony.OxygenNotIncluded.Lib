using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ony.OxygenNotIncluded.Lib.Extensions
{
	public static class Assembly_Extensions
	{
		public static Type[] GetLoadableTypes(this Assembly assembly)
		{
			if (assembly == null) throw new ArgumentNullException(nameof(assembly));
			try
			{
				return assembly.GetTypes();
			}
			catch (ReflectionTypeLoadException e)
			{
				return e.Types.Where(t => t != null).ToArray();
			}
		}

		public static IEnumerable<Type> GetTypesWithAttribute<T>(this Assembly assembly) => assembly.GetLoadableTypes().Where(type => type.GetCustomAttributes(typeof(T), true).Length > 0);

	}
}
