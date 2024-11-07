using System.ComponentModel;

namespace WinglyShop.API.Extensions.Common;

public static class EnumExtension
{
	public static T GetEnumValueFromDescription<T>(string description) where T : Enum
	{
		Type type = typeof(T);
		if (!type.IsEnum)
		{
			throw new ArgumentException("T must be an enumerated type");
		}

		foreach (var field in type.GetFields())
		{
			if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
			{
				if (attribute.Description == description)
				{
					return (T)field.GetValue(null);
				}
			}
			else
			{
				if (field.Name == description)
				{
					return (T)field.GetValue(null);
				}
			}
		}

		throw new ArgumentException($"No enum value with description '{description}' found.");
	}

	public static T GetEnumValueFromName<T>(this string name) where T : Enum
	{
		Type type = typeof(T);
		if (!type.IsEnum)
		{
			throw new ArgumentException("T must be an enumerated type");
		}

		foreach (var field in type.GetFields())
		{
			if (field.Name == name)
			{
				return (T)field.GetValue(null);
			}
		}

		throw new ArgumentException($"No enum value with name '{name}' found.");
	}
}
