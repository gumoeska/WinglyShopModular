using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.Infrastructure.Abstractions.Data;
using WinglyShop.Infrastructure.Abstractions.Dispatcher;

namespace WinglyShop.API.Abstractions;

[ApiController]
public class ApiController : ControllerBase
{
	protected readonly IDispatcher _dispatcher;
	protected readonly IDbConnection _dbConnection;
	protected readonly IDatabaseContextBase _databaseContext;
	protected readonly IUserAccessor _userAccessor;

	protected ApiController(
        IDatabaseContextBase databaseContext, 
		IDbConnection dbConnection, 
		IDispatcher dispatcher,
		IUserAccessor userAccessor)
	{
		_databaseContext = databaseContext;
		_dbConnection = dbConnection;
		_dispatcher = dispatcher;
		_userAccessor = userAccessor;
	}
}
