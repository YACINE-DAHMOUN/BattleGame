using System;
using System.ComponentModel.DataAnnotations;

namespace BattleGame.Models
{
    public class Hero
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Propriétés de base
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Attack { get; set; }

        [Required]
        public int Defense { get; set; }

        [Required]
        public int Speed { get; set; }

        [MaxLength(100)]
        public string? SpecialAbility { get; set; }

        // Stats de progression
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;

        // Stats de santé
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }

        // Statistiques
        public int TotalWins { get; set; } = 0;
        public int TotalLosses { get; set; } = 0;

        // Dates
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastPlayedAt { get; set; } = DateTime.Now;

        // Constructeur par défaut (OBLIGATOIRE pour Entity Framework)
        public Hero()
        {
        }

        // Constructeur pour créer un nouveau héros niveau 1
        public Hero(string name, int baseAttack = 15, int baseDefense = 10, int baseSpeed = 5)
        {
            Name = name;
            Attack = baseAttack;
            Defense = baseDefense;
            Speed = baseSpeed;
            Level = 1;
            Experience = 0;
            MaxHealth = 100; // PV de départ
            CurrentHealth = MaxHealth;
            SpecialAbility = "None";
            TotalWins = 0;
            TotalLosses = 0;
            CreatedAt = DateTime.Now;
            LastPlayedAt = DateTime.Now;
        }

        // Constructeur complet (pour charger depuis la DB)
        public Hero(int id, string name, int attack, int defense, int speed, int maxHealth, int currentHealth, int level, int experience, string specialAbility)
        {
            Id = id;
            Name = name;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            Level = level;
            Experience = experience;
            SpecialAbility = specialAbility;
        }

        // Affichage des informations du héros
        public override string ToString()
        {
            return $"[{Id}] {Name} - Lvl {Level} | HP: {CurrentHealth}/{MaxHealth} | " +
                   $"ATK: {Attack} | DEF: {Defense} | SPD: {Speed} | " +
                   $"XP: {Experience} | W/L: {TotalWins}/{TotalLosses}";
        }
    }
}