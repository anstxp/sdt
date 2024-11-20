using lab6.Data;
using lab6.Factories.Methologies;
using lab6.Handlers;
using lab6.Handlers.ProjectHandler;
using lab6.Models.Domain.IdentityEntities;
using lab6.Repositories;
using lab6.Repositories.Implementation;
using lab6.Repositories.Interfaces;
using lab6.Repositories.Proxies;
using lab6.Services.Implementations;
using lab6.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectProxy>();
builder.Services.AddScoped<ProjectRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IMethodologyRepository, MethodologyRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<MethodologyProvider>();

builder.Services.AddScoped<IRequestHandler, AccessControlHandler>();
builder.Services.AddScoped<IRequestHandler, UniqueProjectCheckHandler>();
builder.Services.AddScoped<IRequestHandler, ProjectDataValidationHandler>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddIdentity<AppUser, UserRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();