using System;
using BattleGame.Models;

public class Game
{
    private Heros hero;
    private Enemy enemy;

    public Game(Heros hero, Enemy enemy)
    {
        this.hero = hero;
        this.enemy = enemy;
    }

    public void Start()
    {
        Console.WriteLine($"Un {enemy.Name} apparaît avec {enemy.Health} PV !");

        while (hero.Health > 0 && enemy.Health > 0)
        {
            Console.WriteLine("\nQue veux-tu faire ?");
            Console.WriteLine("1 - Attaquer");
            Console.WriteLine("2 - Se soigner");
            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    enemy.Health -= hero.Attack;
                    Console.WriteLine($"{hero.Name} attaque et inflige {hero.Attack} dégâts. PV ennemi = {enemy.Health}");
                    break;
                case "2":
                    hero.Health += 20;
                    Console.WriteLine($"{hero.Name} se soigne. PV = {hero.Health}");
                    break;
                default:
                    Console.WriteLine("Choix invalide !");
                    break;
            }

            if (enemy.Health > 0)
            {
                hero.Health -= enemy.Attack;
                Console.WriteLine($"{enemy.Name} attaque et inflige {enemy.Attack} dégâts. PV héros = {hero.Health}");
            }
        }

        if (hero.Health <= 0)
            Console.WriteLine("?? Tu es mort !");
        else
            Console.WriteLine($"?? Tu as vaincu {enemy.Name} !");
    }
}
