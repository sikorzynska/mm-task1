using MentorMate.DeviceManager.Business.Services;
using MentorMate.DeviceManager.Business.Services.Interfaces;
using MentorMate.DeviceManager.Data;
using MentorMate.DeviceManager.Data.Repositories;
using MentorMate.DeviceManager.Data.Repositories.Interfaces;
using MentorMate.DeviceManager.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DeviceManagerDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DbInitializer>();

builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();

builder.Services.AddScoped<IDeviceService, DeviceService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (app)
{
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
