using Microsoft.EntityFrameworkCore;
using JWTAuthAPI.Data;

var builder = WebApplication.CreateBuilder(args); // Create a builder for the web application

builder.Services.AddControllers(); // Add support for controllers
builder.Services.AddEndpointsApiExplorer(); // Add support for API endpoint exploration
builder.Services.AddSwaggerGen(); // Add Swagger generation

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // Configure the database context with PostgreSQL

var app = builder.Build(); // Build the web application

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Shows Swagger in Development
}

app.UseHttpsRedirection();


app.Run();