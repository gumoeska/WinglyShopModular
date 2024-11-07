using System.Reflection;

namespace WinglyShop.Application;

public static class AssemblyReference
{
	public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
