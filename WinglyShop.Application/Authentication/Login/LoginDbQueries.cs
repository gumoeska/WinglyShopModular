using System.Text;

namespace WinglyShop.Application.Authentication.Login;

public static class LoginDbQueries
{
	/// <summary>
	/// Database query that returns a User object
	/// </summary>
	/// <returns>Database query string</returns>
	public static string LogInQuery()
	{
		var query = new StringBuilder();

		query.AppendLine($"SELECT *")
			 .AppendLine($"    FROM [User]")

			 .AppendLine($"WHERE ")
			 .AppendLine($"    [login] = @Login ")
			 .AppendLine($"AND ")
			 .AppendLine($"    [password] = @Password ");

		return query.ToString();
	}

	/// <summary>
	/// Database query that returns a Role object
	/// </summary>
	/// <returns>Database query string</returns>
	public static string UserRoleQuery()
	{
		var query = new StringBuilder();

		query.AppendLine($"SELECT *")
			 .AppendLine($"    FROM [Roles]")
			 .AppendLine($"WHERE [id] = @RoleId ");

		return query.ToString();
	}
}
