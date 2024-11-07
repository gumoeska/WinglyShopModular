using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Authentication.Profile.Response;
using WinglyShop.Application.Extensions;
using WinglyShop.Application.Users.DTOs;
using WinglyShop.Domain.Entities.Users;
using WinglyShop.Shared;

namespace WinglyShop.Application.Users.GetUserProfile;

internal sealed class GetUserFullProfileQueryHandler : IQueryHandler<GetUserFullProfileQuery, UserFullProfileDTO>
{
    private readonly IDatabaseContext _context;

    public GetUserFullProfileQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<UserFullProfileDTO>> Handle(GetUserFullProfileQuery query, CancellationToken cancellationToken)
    {
        // Validate
        if (query is null)
        {
            return Result.Failure<UserFullProfileDTO>(new Error("Error", "Ocorreu um erro ao buscar as informações do usuário."));
        }

        // Getting the user information
        var user = await _context.Users
            .Where(x => x.Login == query.Login)
            .FirstOrDefaultAsync();

        // Validate if the user data exists
        if (user is null)
        {
            return Result.Failure<UserFullProfileDTO>(new Error("Error", "Usuário não encontrado."));
        }

        // Get the user role
        var userRoleName = await _context.Roles
            .Where(x => x.Id == user.IdRole)
            .Select(x => x.Access)
            .FirstOrDefaultAsync();

        // Building the response
        var userResponse = new UserFullProfileDTO
        {
            Id = user.Id,
            Login = user.Login,
            Password = user.Password,
            Email = user.Email,
            Name = user.Name,
            Surname = user.Surname,
            Image = user.Image,
            Phone = user.Phone,
            RoleDescription = userRoleName.DescriptionAttr(),
            IsActive = user.IsActive,
        };

        return Result.Success(userResponse);
    }
}
