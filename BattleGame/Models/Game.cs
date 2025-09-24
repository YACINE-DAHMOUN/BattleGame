using System;
using BattleGame.Models;

namespace BattleGame.Models
{
    public class Game
    {
        // Propriétés publiques pour l'accès depuis le contrôleur
        public Heros Hero { get; private set; }
        public Enemy Enemy { get; private set; }

        public Game(Heros hero, Enemy enemy)
        {
            this.Hero = hero;
            this.Enemy = enemy;
        }

        // Méthode pour l'attaque du héros
        public void HeroAttack()
        {
            if (Enemy.Health > 0)
            {
                int damage = Math.Max(1, Hero.Attack - Enemy.Defense); // Au minimum 1 dégât
                Enemy.Health -= damage;
                Console.WriteLine($"{Hero.Name} attaque et inflige {damage} dégâts. PV ennemi = {Enemy.Health}");

                // L'ennemi contre-attaque s'il est encore vivant
                if (Enemy.Health > 0)
                {
                    EnemyAttack();
                }
            }
        }

        // Méthode pour le soin du héros
        public void HeroHeal()
        {
            int healAmount = 20;
            Hero.Health += healAmount;
            Console.WriteLine($"{Hero.Name} se soigne de {healAmount} PV. PV = {Hero.Health}");

            // L'ennemi attaque après le soin
            if (Enemy.Health > 0)
            {
                EnemyAttack();
            }
        }

        // Attaque de l'ennemi (privée)
        private void EnemyAttack()
        {
            if (Hero.Health > 0 && Enemy.Health > 0)
            {
                int damage = Math.Max(1, Enemy.Attack - Hero.Defense); // Au minimum 1 dégât
                Hero.Health -= damage;
                Console.WriteLine($"{Enemy.Name} attaque et inflige {damage} dégâts. PV héros = {Hero.Health}");
            }
        }

        // Méthode pour vérifier l'état du jeu
        public string GetGameState()
        {
            if (Hero.Health <= 0)
                return "Défaite ! Le héros est mort.";
            else if (Enemy.Health <= 0)
                return $"Victoire ! {Enemy.Name} a été vaincu !";
            else
                return "Combat en cours...";
        }

        // Version console du jeu (méthode originale)
        public void Start()
        {
            Console.WriteLine($"Un {Enemy.Name} apparaît avec {Enemy.Health} PV !");

            while (Hero.Health > 0 && Enemy.Health > 0)
            {
                Console.WriteLine("\nQue veux-tu faire ?");
                Console.WriteLine("1 - Attaquer");
                Console.WriteLine("2 - Se soigner");
                Console.Write("> ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        HeroAttack();
                        break;
                    case "2":
                        HeroHeal();
                        break;
                    default:
                        Console.WriteLine("Choix invalide !");
                        break;
                }
            }

            Console.WriteLine(GetGameState());
        }
    }
}