using lab5.Data;
using lab5.Handlers;
using lab5.Models.Domain.IdentityEntities;
using lab5.Repositories.Implementation;
using lab5.Repositories.Interfaces;
using lab5.Repositories.Proxies;
using lab5.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectProxy>();
builder.Services.AddScoped<IRequestHandler, AccessControlHandler>();
builder.Services.AddScoped<ProjectRepository>();

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