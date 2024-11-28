using System.Reflection.Metadata.Ecma335;
using lab7.Data;
using lab7.Factories.Methologies;
using lab7.Handlers;
using lab7.Handlers.ProjectHandler;
using lab7.Models.Domain.IdentityEntities;
using lab7.Repositories;
using lab7.Repositories.Implementation;
using lab7.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IMethodologyRepository, MethodologyRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<MethodologyProvider>();

builder.Services.AddScoped<IRequestHandler, AccessControlHandler>();
builder.Services.AddScoped<IRequestHandler, UniqueProjectCheckHandler>();
builder.Services.AddScoped<IRequestHandler, ProjectDataValidationHandler>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddIdentity<AppUser, AppRole>(options =>
    {
        options.Password.RequiredLength = 5;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireDigit = false;
        options.Password.RequiredUniqueChars = 3;
        
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddUserStore<UserStore<AppUser, AppRole, AppDbContext, Guid>>()
    .AddRoleStore<RoleStore<AppRole, AppDbContext, Guid>>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); /*enforces authorisation policy 
    (user must be authenticated) for all the action methods*/
    
    options.AddPolicy("NotAuthenticated", policy 
        => policy.RequireAssertion(context =>
        {
            return !
                context.User.Identity.IsAuthenticated;
        }));
});

builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
});

builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();
app.UseHttpLogging();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();