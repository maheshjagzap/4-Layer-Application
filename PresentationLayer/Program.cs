using ApplicationLayer.Services;
using CoreLayer.Interfaces;
using InfrastructureLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register ProductRepository
builder.Services.AddScoped<IProduct>(provider => new ProductRepository(connectionString));
builder.Services.AddScoped<ProductService>();

// Register UserRepository
builder.Services.AddScoped<IUser>(provider => new UserRepository(connectionString));
builder.Services.AddScoped<UserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
