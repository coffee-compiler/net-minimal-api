using Microsoft.AspNetCore.Mvc;
using UserManagement.Api.Application.Models;
using UserManagement.Api.Application.Services;
using UserManagement.Api.Presentation.Routes;

namespace UserManagement.Api.Presentation.Endpoints;

internal static class UserEndpoints
{
    private const string BaseTag = "Users";
    
    public static void Map(WebApplication app)
    {
        app.MapPost(UserRoutes.Create, CreateUser)
            .Produces<UserDto?>(StatusCodes.Status201Created)
            .WithTags(BaseTag);

        app.MapDelete(UserRoutes.Delete, DeleteUser)
            .Produces(StatusCodes.Status200OK)
            .WithTags(BaseTag);

        app.MapGet(UserRoutes.Get,GetUser)
            .Produces<UserDto?>(StatusCodes.Status200OK)
            .WithTags(BaseTag);

        app.MapGet(UserRoutes.GetAll,GetAllUsers)
            .Produces<IEnumerable<UserDto?>>()
            .WithTags(BaseTag);
    }

    public static async Task<IResult> CreateUser(
        [FromBody] CreateUserDto user,
        CancellationToken cancellationToken,
        IUserService userService)
    {
        var createdUser = await userService.CreateAsync(user, cancellationToken);

        return Results.Created(
            UserRoutes.Get
                .Replace(
                    "{id:guid}",
                    createdUser?.Id.ToString("D")),
            createdUser);
    }

    public static async Task<IResult> DeleteUser(
        [FromRoute] Guid id,
        CancellationToken cancellationToken,
        IUserService userService)
    {
        await userService.DeleteAsync(id, cancellationToken);
        return Results.Ok();
    }

    public static async Task<IResult> GetUser(
        [FromRoute] Guid id,
        CancellationToken cancellationToken,
        IUserService userService)
    {
        var user = await userService.GetAsync(id, cancellationToken);

        return Results.Ok(user);
    }

    public static async Task<IResult> GetAllUsers(
        CancellationToken cancellationToken,
        IUserService userService)
    {
        var users = await userService.GetAllAsync(cancellationToken);

        return Results.Ok(users);
    }
}