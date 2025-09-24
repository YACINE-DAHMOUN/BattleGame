using BattleGame.Models;

var builder = WebApplication.CreateBuilder(args);

// Ajoute les services nécessaires pour les controllers
builder.Services.AddControllers();

var app = builder.Build();

// Sert les fichiers statiques dans wwwroot
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();

// Map les controllers
app.MapControllers();

app.MapFallbackToFile("index.html"); // Pour les applications SPA

app.Run();
