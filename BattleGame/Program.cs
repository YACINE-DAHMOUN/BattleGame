using BattleGame.Models;
using BattleGame.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Ajoute les services nécessaires pour les controllers
builder.Services.AddControllers();

// Configuration de la base de données SQL Server
builder.Services.AddDbContext<BattleGame.Data.BattleGameContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ajoute Swagger pour tester l'API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Sert les fichiers statiques dans wwwroot
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Map les controllers
app.MapControllers();

app.MapFallbackToFile("index.html"); // Pour les applications SPA

app.Run();
