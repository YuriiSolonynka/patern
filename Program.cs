using Microsoft.EntityFrameworkCore;
using patern.Models;
using patern.Repositories;
using patern.Repositories.Interface;
using patern.Services;
using patern.Services.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .EnableSensitiveDataLogging());


builder.Services.AddScoped<IHubRepository, HubRepository>();
builder.Services.AddScoped<IHubService, HubService>();

builder.Services.AddScoped<IMotionSensorRepository, MotionSensorRepository>();
builder.Services.AddScoped<IMotionSensorService, MotionSensorService>();

builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddScoped<ISecurityServiceRepository, SecurityServiceRepository>();
builder.Services.AddScoped<ISecurityServiceService, SecurityServiceService>();

builder.Services.AddScoped<ISmokeSensorRepository, SmokeSensorRepository>();
builder.Services.AddScoped<ISmokeSensorService, SmokeSensorService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICsvImportService, CsvImportService>();

builder.Services.AddControllersWithViews();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hub}/{action=Index}/{id?}");

app.Run();
