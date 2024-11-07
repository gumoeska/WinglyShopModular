﻿using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Domain.Entities.Users;
using WinglyShop.Shared;

namespace WinglyShop.Users.Application.Commands.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, bool>
{
	private readonly IDatabaseContext _context;
    private readonly IDbConnection _dbConnection;

    public RegisterCommandHandler(IDatabaseContext context, IDbConnection dbConnection)
    {
		_context = context;
        _dbConnection = dbConnection;
    }

	public async Task<Result<bool>> Handle(RegisterCommand command, CancellationToken cancellationToken)
	{
		// Validate
		if (command is null)
			throw new ArgumentNullException(nameof(command));

		// Creating a new User based on UserDTO
		var user = new User(command.User);

		// Inserting data
		try
		{
			// Checking if the user already exists
			var userExists = await _context.Users
				.AnyAsync(x => x.Login == user.Login);

			// Setting the user role
			var customerRole = await _context.Roles
				.Where(x => x.Access == RoleAccess.Customer)
				.FirstOrDefaultAsync();

			if (customerRole is { Id: > 0 })
			{
				user.IdRole = customerRole.Id;
			}

			// Setting the name as the login
			user.Name = user.Login;

			// Activating the user
			user.IsActive = true;

			// Validate if user already exists
			if (userExists is true)
				return Result.Failure<bool>(new Error("Error", "Esta conta já existe."));

			// Insert data into database
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			return Result.Failure<bool>(new Error("Error", "Ocorreu um erro."));
		}

		return Result.Success(true);
	}
}
