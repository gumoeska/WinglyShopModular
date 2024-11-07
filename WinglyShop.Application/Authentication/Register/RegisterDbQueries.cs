using System.Text;

namespace WinglyShop.Application.Authentication.Register;

public static class RegisterDbQueries
{
	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	public static string RegisterQuery()
	{
		var query = new StringBuilder();

		query.AppendLine($"INSERT INTO [User] ")
			 .AppendLine($"	( login, ")
			 .AppendLine($"	  email, ")
			 .AppendLine($"	  password, ")
			 .AppendLine($"	  name, ")
			 .AppendLine($"	  surname, ")
			 .AppendLine($"	  image, ")
			 .AppendLine($"	  phone, ")
			 .AppendLine($"	  isActive, ")
			 .AppendLine($"	  idRole) ")

			 .AppendLine($"VALUES ")
			 .AppendLine($"( @login, ")
			 .AppendLine($"  @email, ")
			 .AppendLine($"  @password, ")
			 .AppendLine($"  @name, ")
			 .AppendLine($"  @surname, ")
			 .AppendLine($"  @image, ")
			 .AppendLine($"  @phone, ")
			 .AppendLine($"  @isActive, ")
			 .AppendLine($"  @idRole) ");

		return query.ToString();
	}
}
