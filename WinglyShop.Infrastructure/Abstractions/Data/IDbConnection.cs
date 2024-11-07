using Microsoft.Data.SqlClient;

namespace WinglyShop.Infrastructure.Abstractions.Data;

public interface IDbConnection
{
	SqlConnection CreateConnection();
}

