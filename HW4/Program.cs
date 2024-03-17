using HW4.DataAccess;
using HW4.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Attach additional configiguration files.
builder.Configuration.AddJsonFile("secret/appsettings.secret.json", true);
builder.Configuration.AddJsonFile("config/appsettings.json", true, true);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<UsersDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("Users")));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
