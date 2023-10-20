using Microsoft.EntityFrameworkCore;
using UserManagement.Api.Application;
using UserManagement.Api.Application.Services;
using UserManagement.Api.Domain.Core.Interfaces;
using UserManagement.Api.Domain.Repositories;
using UserManagement.Api.Infrastructure;
using UserManagement.Api.Infrastructure.Data;
using UserManagement.Api.Infrastructure.Repositories;
using UserManagement.Api.Presentation.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserManagementContext>(
    options => options.UseInMemoryDatabase("UserManagementDb"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

UserEndpoints.Map(app);

app.Run();