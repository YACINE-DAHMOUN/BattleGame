using System;
using BattleGame.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Battle Game ===");
        Console.Write("Entre le nom de ton héros: ");
        string name = Console.ReadLine();

        Heros hero = new Heros(1, name);
        Enemy enemy = new Enemy(1, "Goblin");

        Game game = new Game(hero, enemy);
        game.Start();
    }
}
