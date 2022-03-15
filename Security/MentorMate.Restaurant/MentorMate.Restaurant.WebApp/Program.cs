using MentorMate.Restaurant.Business.Services;
using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Configurations.Auth;
using MentorMate.Restaurant.WebApp.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

var authOptions = builder.Configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>();
builder.Services.AddSingleton(authOptions);

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<RestaurantDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddDbContext<RestaurantDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DbInitializer>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<ITableService, TableService>();

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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (app)
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    await app.InitializeDbContext();
    await app.RunAsync();
}