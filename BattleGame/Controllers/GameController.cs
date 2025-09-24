using Microsoft.AspNetCore.Mvc;
using BattleGame.Models;
using System;

namespace BattleGame.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GameController : ControllerBase
	{
		private static Game currentGame;

		// Démarrage du jeu
		[HttpGet("start")]
		public IActionResult StartGame()
		{
			Heros hero = new Heros(1, "Archer");   // Stats aléatoires
			Enemy enemy = new Enemy(1, "Goblin");  // Stats aléatoires

			currentGame = new Game(hero, enemy);

			return Ok(new
			{
				Hero = hero,
				Enemy = enemy
			});
		}

		// Récupérer les stats du héros
		[HttpGet("hero")]
		public IActionResult GetHero()
		{
			if (currentGame == null)
				return BadRequest("Le jeu n'a pas été démarré. Veuillez appeler /game/start d'abord.");

			return Ok(currentGame.Hero);
		}

		// Récupérer les stats de l'ennemi
		[HttpGet("enemy")]
		public IActionResult GetEnemy()
		{
			if (currentGame == null)
				return BadRequest("Le jeu n'a pas été démarré. Veuillez appeler /game/start d'abord.");

			return Ok(currentGame.Enemy);
		}

		// Attaque du héros
		[HttpGet("attack")]
		public IActionResult Attack()
		{
			if (currentGame == null)
				return BadRequest("Le jeu n'a pas été démarré. Veuillez appeler /game/start d'abord.");

			currentGame.HeroAttack();

			return Ok(new
			{
				Hero = currentGame.Hero,
				Enemy = currentGame.Enemy
			});
		}

		// Soin du héros
		[HttpGet("heal")]
		public IActionResult Heal()
		{
			if (currentGame == null)
				return BadRequest("Le jeu n'a pas été démarré. Veuillez appeler /game/start d'abord.");

			currentGame.HeroHeal();

			return Ok(new
			{
				Hero = currentGame.Hero,
				Enemy = currentGame.Enemy
			});
		}
	}
}