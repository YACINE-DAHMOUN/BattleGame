using System;

namespace BattleGame.Models
{
    public class Heros
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public string SpecialAbility { get; set; }

        // Constructeur complet
        public Heros(int id, string name, int health, int attack, int defense, int speed, string specialAbility)
        {
            Id = id;
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            SpecialAbility = specialAbility;
        }

        // Constructeur aléatoire
        public Heros(int id, string name)
        {
            Id = id;
            Name = name;
            Random rnd = new Random();
            Health = rnd.Next(50, 101);      // PV aléatoires entre 50 et 100
            Attack = rnd.Next(10, 21);       // Attaque aléatoire entre 10 et 20
            Defense = rnd.Next(5, 16);       // Défense aléatoire
            Speed = rnd.Next(1, 11);         // Vitesse aléatoire
            SpecialAbility = "None";         // Aucun pouvoir spécial par défaut

            // Affiche les stats à la création
            Console.WriteLine(this.ToString());
        }

        // Affichage des informations du héros
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Health: {Health}, Attack: {Attack}, Defense: {Defense}, Speed: {Speed}, Special Ability: {SpecialAbility}";
        }
    }
}
