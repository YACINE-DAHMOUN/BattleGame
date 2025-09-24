using System;
using BattleGame.Models;

namespace BattleGame.Models
{
    public class Game
    {
        // Propri�t�s publiques pour l'acc�s depuis le contr�leur
        public Heros Hero { get; private set; }
        public Enemy Enemy { get; private set; }

        public Game(Heros hero, Enemy enemy)
        {
            this.Hero = hero;
            this.Enemy = enemy;
        }

        // M�thode pour l'attaque du h�ros
        public void HeroAttack()
        {
            if (Enemy.Health > 0)
            {
                int damage = Math.Max(1, Hero.Attack - Enemy.Defense); // Au minimum 1 d�g�t
                Enemy.Health -= damage;
                Console.WriteLine($"{Hero.Name} attaque et inflige {damage} d�g�ts. PV ennemi = {Enemy.Health}");

                // L'ennemi contre-attaque s'il est encore vivant
                if (Enemy.Health > 0)
                {
                    EnemyAttack();
                }
            }
        }

        // M�thode pour le soin du h�ros
        public void HeroHeal()
        {
            int healAmount = 20;
            Hero.Health += healAmount;
            Console.WriteLine($"{Hero.Name} se soigne de {healAmount} PV. PV = {Hero.Health}");

            // L'ennemi attaque apr�s le soin
            if (Enemy.Health > 0)
            {
                EnemyAttack();
            }
        }

        // Attaque de l'ennemi (priv�e)
        private void EnemyAttack()
        {
            if (Hero.Health > 0 && Enemy.Health > 0)
            {
                int damage = Math.Max(1, Enemy.Attack - Hero.Defense); // Au minimum 1 d�g�t
                Hero.Health -= damage;
                Console.WriteLine($"{Enemy.Name} attaque et inflige {damage} d�g�ts. PV h�ros = {Hero.Health}");
            }
        }

        // M�thode pour v�rifier l'�tat du jeu
        public string GetGameState()
        {
            if (Hero.Health <= 0)
                return "D�faite ! Le h�ros est mort.";
            else if (Enemy.Health <= 0)
                return $"Victoire ! {Enemy.Name} a �t� vaincu !";
            else
                return "Combat en cours...";
        }

        // Version console du jeu (m�thode originale)
        public void Start()
        {
            Console.WriteLine($"Un {Enemy.Name} appara�t avec {Enemy.Health} PV !");

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