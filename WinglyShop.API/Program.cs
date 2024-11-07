using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Configurations;
using WinglyShop.API.Middlewares.Authorization;
using WinglyShop.API.Services.Auth;
using WinglyShop.API.Services.Storage;
using WinglyShop.API.Settings;
using WinglyShop.Application;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Abstractions.Storage;
using WinglyShop.Infrastructure;

namespace WinglyShop.API
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.Build();

            //builder.Services.Configure<SecretKey>(configuration.GetSection("SecretKey")); // Configuring the secret key
            builder.Services.Configure<FileStorageSettings>(configuration.GetSection("FileStorageSettings")); // Configuring the FileStorageSettings

            builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();

			builder.Configuration.AddConfiguration(configuration);

			builder.Services.AddCors(policy =>
			{
				policy.AddPolicy("AllowSpecificOrigin", builder =>
				 builder.WithOrigins("http://localhost:7283/")
				  .SetIsOriginAllowed((host) => true) // localhost
				  .AllowAnyMethod()
				  .AllowAnyHeader()
				  .AllowCredentials());
			});

			builder.Services
				.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo { Title = "WinglyShop.API", Version = "v1" }));

			// EF Core
			builder.Services.AddDbContext<DatabaseContext>(options =>
			{
				var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

				options.UseSqlServer(connectionString, sqlServerAction =>
				{
					sqlServerAction.EnableRetryOnFailure(3);
					sqlServerAction.CommandTimeout(30);
				});

				options.EnableDetailedErrors(true);
				options.EnableSensitiveDataLogging(true);
			});

			builder.Services.AddScoped<IDatabaseContext, DatabaseContext>(); // Database (EF Core)
			builder.Services.AddScoped<IDbConnection, DbConnection>(); // Database (Dapper)
			builder.Services.AddScoped<IDispatcher, Dispatcher>(); // Dispatcher
			builder.Services.AddScoped<ITokenService, TokenService>(); // Token Service
			builder.Services.AddScoped<IUserAccessor, UserAccessor>(); // User Data
			builder.Services.AddScoped<IFileStorageService, FileStorageService>(); // File Storage Service

			builder.Services.AddHandlersFromAssembly(typeof(AssemblyReference).Assembly); // Scan the Handlers

			// Authentication
			builder.Services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKey:Token"])),
					ValidateIssuer = false,
					ValidateAudience = false,
					ClockSkew = TimeSpan.Zero
				};
			});

			builder.Services.AddHttpContextAccessor();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCors("AllowSpecificOrigin");

			app.UseHttpsRedirection();

			app.UseMiddleware<AuthorizationMiddleware>();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
