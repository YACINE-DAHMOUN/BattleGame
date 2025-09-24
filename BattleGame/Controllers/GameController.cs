using BattleGame.Models;
using System;

namespace BattleGame.Controllers
{
	public class GameController
	{
		private static Game? currentGame;

		// Démarrage du jeu
		public string StartGame()
		{
			try
			{
				Heros hero = new Heros(1, "Archer");   // Stats aléatoires
				Enemy enemy = new Enemy(1, "Goblin");  // Stats aléatoires

				currentGame = new Game(hero, enemy);

				return $"Jeu démarré ! Héros: {hero.Name}, Ennemi: {enemy.Name}";
			}
			catch (Exception ex)
			{
				return $"Erreur lors du démarrage: {ex.Message}";
			}
		}

		// Récupérer les stats du héros
		public string GetHero()
		{
			if (currentGame == null)
				return "Le jeu n'a pas été démarré. Veuillez appeler StartGame() d'abord.";

			var hero = currentGame.Hero;
			return $"Héros: {hero.Name} - HP: {hero.Health}, ATK: {hero.Attack}, DEF: {hero.Defense}";
		}

		// Récupérer les stats de l'ennemi
		public string GetEnemy()
		{
			if (currentGame == null)
				return "Le jeu n'a pas été démarré. Veuillez appeler StartGame() d'abord.";

			var enemy = currentGame.Enemy;
			return $"Ennemi: {enemy.Name} - HP: {enemy.Health}, ATK: {enemy.Attack}, DEF: {enemy.Defense}";
		}

		// Attaque du héros
		public string Attack()
		{
			if (currentGame == null)
				return "Le jeu n'a pas été démarré. Veuillez appeler StartGame() d'abord.";

			try
			{
				currentGame.HeroAttack();
				return $"Attaque effectuée ! Héros HP: {currentGame.Hero.Health}, Ennemi HP: {currentGame.Enemy.Health}";
			}
			catch (Exception ex)
			{
				return $"Erreur lors de l'attaque: {ex.Message}";
			}
		}

		// Soin du héros
		public string Heal()
		{
			if (currentGame == null)
				return "Le jeu n'a pas été démarré. Veuillez appeler StartGame() d'abord.";

			try
			{
				currentGame.HeroHeal();
				return $"Soin effectué ! Héros HP: {currentGame.Hero.Health}";
			}
			catch (Exception ex)
			{
				return $"Erreur lors du soin: {ex.Message}";
			}
		}

		// Méthode pour obtenir le statut complet du jeu
		public string GetGameStatus()
		{
			if (currentGame == null)
				return "Aucun jeu en cours.";

			return $"Statut du jeu:\n" +
				   $"Héros: {currentGame.Hero.Name} - HP: {currentGame.Hero.Health}\n" +
				   $"Ennemi: {currentGame.Enemy.Name} - HP: {currentGame.Enemy.Health}";
		}
	}
}