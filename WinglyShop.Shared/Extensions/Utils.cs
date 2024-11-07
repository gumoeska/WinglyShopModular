namespace WinglyShop.Shared.Extensions;

public static class Utils
{
	public static bool IsNullOrEmpty<T>(List<T> list)
	{
		return list == null || list.Count == 0;
	}

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable == null)
        {
            return true;
        }

        var collection = enumerable as ICollection<T>;
        if (collection != null)
        {
            return collection.Count < 1;
        }
        return !enumerable.Any();
    }

    public static async Task ForEachAsync<T>(this List<T> list, Func<T, Task> func)
	{
		foreach (var value in list)
		{
			await func(value);
		}
	}
}
