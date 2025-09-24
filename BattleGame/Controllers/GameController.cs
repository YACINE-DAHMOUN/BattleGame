using BattleGame.Models;
using System;

namespace BattleGame.Controllers
{
	public class GameController
	{
		private static Game? currentGame;

		// D�marrage du jeu
		public string StartGame()
		{
			try
			{
				Heros hero = new Heros(1, "Archer");   // Stats al�atoires
				Enemy enemy = new Enemy(1, "Goblin");  // Stats al�atoires

				currentGame = new Game(hero, enemy);

				return $"Jeu d�marr� ! H�ros: {hero.Name}, Ennemi: {enemy.Name}";
			}
			catch (Exception ex)
			{
				return $"Erreur lors du d�marrage: {ex.Message}";
			}
		}

		// R�cup�rer les stats du h�ros
		public string GetHero()
		{
			if (currentGame == null)
				return "Le jeu n'a pas �t� d�marr�. Veuillez appeler StartGame() d'abord.";

			var hero = currentGame.Hero;
			return $"H�ros: {hero.Name} - HP: {hero.Health}, ATK: {hero.Attack}, DEF: {hero.Defense}";
		}

		// R�cup�rer les stats de l'ennemi
		public string GetEnemy()
		{
			if (currentGame == null)
				return "Le jeu n'a pas �t� d�marr�. Veuillez appeler StartGame() d'abord.";

			var enemy = currentGame.Enemy;
			return $"Ennemi: {enemy.Name} - HP: {enemy.Health}, ATK: {enemy.Attack}, DEF: {enemy.Defense}";
		}

		// Attaque du h�ros
		public string Attack()
		{
			if (currentGame == null)
				return "Le jeu n'a pas �t� d�marr�. Veuillez appeler StartGame() d'abord.";

			try
			{
				currentGame.HeroAttack();
				return $"Attaque effectu�e ! H�ros HP: {currentGame.Hero.Health}, Ennemi HP: {currentGame.Enemy.Health}";
			}
			catch (Exception ex)
			{
				return $"Erreur lors de l'attaque: {ex.Message}";
			}
		}

		// Soin du h�ros
		public string Heal()
		{
			if (currentGame == null)
				return "Le jeu n'a pas �t� d�marr�. Veuillez appeler StartGame() d'abord.";

			try
			{
				currentGame.HeroHeal();
				return $"Soin effectu� ! H�ros HP: {currentGame.Hero.Health}";
			}
			catch (Exception ex)
			{
				return $"Erreur lors du soin: {ex.Message}";
			}
		}

		// M�thode pour obtenir le statut complet du jeu
		public string GetGameStatus()
		{
			if (currentGame == null)
				return "Aucun jeu en cours.";

			return $"Statut du jeu:\n" +
				   $"H�ros: {currentGame.Hero.Name} - HP: {currentGame.Hero.Health}\n" +
				   $"Ennemi: {currentGame.Enemy.Name} - HP: {currentGame.Enemy.Health}";
		}
	}
}