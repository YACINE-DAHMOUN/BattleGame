using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleGame.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        // Foreign keys
        public int? HeroId { get; set; }
        public int? EnemyId { get; set; }

        // Propriétés publiques pour l'accès depuis le contrôleur
        [ForeignKey("HeroId")]
        public virtual Hero? Hero { get; set; }
        
        [ForeignKey("EnemyId")]
        public virtual Enemy? Enemy { get; set; }

        // Pour stocker les résultats du jeu
        public bool? PlayerWon { get; set; }
        public int TurnCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        // Constructeur par défaut pour Entity Framework
        public Game()
        {
        }

        // Constructeur pour le jeu
        public Game(Hero hero, Enemy enemy)
        {
            this.Hero = hero;
            this.Enemy = enemy;
            HeroId = hero.Id;
            EnemyId = enemy.Id;
            TurnCount = 0;
            CreatedAt = DateTime.Now;
        }

        // Méthode pour l'attaque du héros
        public void HeroAttack()
        {
            if (Enemy != null && Enemy.Health > 0)
            {
                TurnCount++;
                int damage = Math.Max(5, Hero.Attack - Enemy.Defense);
                Enemy.Health = Math.Max(0, Enemy.Health - damage); // Empêche négatif
                
                if (Enemy.Health <= 0)
                {
                    // Gérer la victoire
                    PlayerWon = true;
                    if (Hero != null)
                    {
                        Hero.TotalWins++;
                        Hero.Experience += 50;
                    }
                }
            }
        }

        // Méthode pour le soin du héros
        public void HeroHeal()
        {
            if (Hero != null)
            {
                TurnCount++;
                int healAmount = 20;
                Hero.CurrentHealth = Math.Min(Hero.MaxHealth, Hero.CurrentHealth + healAmount);
                
                // L'ennemi attaque après le soin
                if (Enemy != null && Enemy.Health > 0)
                {
                    EnemyAttack();
                }
            }
        }
        
        // Attaque de l'ennemi (privée)
        private void EnemyAttack()
        {
            if (Hero != null && Enemy != null && Hero.CurrentHealth > 0 && Enemy.Health > 0)
            {
                int damage = Math.Max(1, Enemy.Attack - Hero.Defense);
                Hero.CurrentHealth = Math.Max(0, Hero.CurrentHealth - damage);
                
                if (Hero.CurrentHealth <= 0)
                {
                    // Gérer la défaite
                    PlayerWon = false;
                    Hero.TotalLosses++;
                }
            }
        }
    }
}