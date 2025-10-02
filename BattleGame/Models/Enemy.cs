using System;

namespace BattleGame.Models
{
    public class Enemy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public string SpecialAbility { get; set; }

        public Enemy(int id, string name, int health, int attack, int defense, int speed, string specialAbility)

        {
            Id = id;
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            SpecialAbility = specialAbility;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Health: {Health}, Attack: {Attack}, Defense: {Defense}, Speed: {Speed}, Special Ability: {SpecialAbility}";
        }

        public Enemy(int id, string name)
        {
            Id = id;
            Name = name;
            Random rnd = new Random();
            Health = rnd.Next(50, 101);
            Attack = rnd.Next(10, 21);
            Defense = rnd.Next(5, 16);
            Speed = rnd.Next(1, 11);
            SpecialAbility = "None";

            // Affiche les stats de l'ennemi
            Console.WriteLine(this.ToString());
        }

    }
}