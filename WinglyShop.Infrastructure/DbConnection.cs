using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WinglyShop.Application.Abstractions.Data;

namespace WinglyShop.Infrastructure;

public class DbConnection : IDbConnection
{
	private readonly IConfiguration _configuration;

	public DbConnection(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public SqlConnection CreateConnection() =>
		new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
}
