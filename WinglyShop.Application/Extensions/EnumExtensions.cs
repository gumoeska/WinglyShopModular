using System.ComponentModel;
using System.Reflection;

namespace WinglyShop.Application.Extensions;

public static class EnumExtensions
{
	public static string StringValueOfEnum(Enum value)
	{
		FieldInfo fi = value.GetType().GetField(value.ToString());
		DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

		if (attributes.Length > 0)
		{
			return attributes[0].Description;
		}
		else
		{
			return value.ToString();
		}
	}

    public static string DescriptionAttr<T>(this T source)
    {
        FieldInfo fi = source.GetType().GetField(source.ToString());

        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0) return attributes[0].Description;
        else return source.ToString();
    }
}
