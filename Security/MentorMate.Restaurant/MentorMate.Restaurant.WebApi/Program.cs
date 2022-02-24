using MentorMate.Restaurant.Business.Services;
using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data;
using MentorMate.Restaurant.Data.Configurations.Auth;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.WebApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var authOptions = builder.Configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>();
builder.Services.AddSingleton(authOptions);

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<RestaurantDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddDbContext<RestaurantDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<DbInitializer>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MentorMate.Restaurant.WebApi", Version = "v1" });
    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Description = "Please enter JWT with Bearer into field"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        new List<string>()
                    }
                });
});

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(configuration =>
    {
        configuration.RequireHttpsMetadata = false;
        configuration.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(authOptions.SecurityKeyAsBytes),
            ValidateAudience = true,
            ValidAudience = authOptions.Audience,
            ValidateIssuer = true,
            ValidIssuer = authOptions.Issuer,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

using (app)
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    await app.InitializeDbContext();
    await app.RunAsync();
}
