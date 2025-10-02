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

        // Propri�t�s publiques pour l'acc�s depuis le contr�leur
        [ForeignKey("HeroId")]
        public virtual Hero? Hero { get; set; }
        
        [ForeignKey("EnemyId")]
        public virtual Enemy? Enemy { get; set; }

        // Pour stocker les r�sultats du jeu
        public bool? PlayerWon { get; set; }
        public int TurnCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        // Constructeur par d�faut pour Entity Framework
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

        // M�thode pour l'attaque du h�ros
        public void HeroAttack()
        {
            if (Enemy != null && Enemy.Health > 0)
            {
                TurnCount++;
                int damage = Math.Max(5, Hero.Attack - Enemy.Defense);
                Enemy.Health = Math.Max(0, Enemy.Health - damage); // Emp�che n�gatif
                
                if (Enemy.Health <= 0)
                {
                    // G�rer la victoire
                    PlayerWon = true;
                    if (Hero != null)
                    {
                        Hero.TotalWins++;
                        Hero.Experience += 50;
                    }
                }
            }
        }

        // M�thode pour le soin du h�ros
        public void HeroHeal()
        {
            if (Hero != null)
            {
                TurnCount++;
                int healAmount = 20;
                Hero.CurrentHealth = Math.Min(Hero.MaxHealth, Hero.CurrentHealth + healAmount);
                
                // L'ennemi attaque apr�s le soin
                if (Enemy != null && Enemy.Health > 0)
                {
                    EnemyAttack();
                }
            }
        }
        
        // Attaque de l'ennemi (priv�e)
        private void EnemyAttack()
        {
            if (Hero != null && Enemy != null && Hero.CurrentHealth > 0 && Enemy.Health > 0)
            {
                int damage = Math.Max(1, Enemy.Attack - Hero.Defense);
                Hero.CurrentHealth = Math.Max(0, Hero.CurrentHealth - damage);
                
                if (Hero.CurrentHealth <= 0)
                {
                    // G�rer la d�faite
                    PlayerWon = false;
                    Hero.TotalLosses++;
                }
            }
        }
    }
}