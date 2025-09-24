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

		// D�marrage du jeu
		[HttpGet("start")]
		public IActionResult StartGame()
		{
			Heros hero = new Heros(1, "Archer");   // Stats al�atoires
			Enemy enemy = new Enemy(1, "Goblin");  // Stats al�atoires

			currentGame = new Game(hero, enemy);

			return Ok(new
			{
				Hero = hero,
				Enemy = enemy
			});
		}

		// R�cup�rer les stats du h�ros
		[HttpGet("hero")]
		public IActionResult GetHero()
		{
			if (currentGame == null)
				return BadRequest("Le jeu n'a pas �t� d�marr�. Veuillez appeler /game/start d'abord.");

			return Ok(currentGame.Hero);
		}

		// R�cup�rer les stats de l'ennemi
		[HttpGet("enemy")]
		public IActionResult GetEnemy()
		{
			if (currentGame == null)
				return BadRequest("Le jeu n'a pas �t� d�marr�. Veuillez appeler /game/start d'abord.");

			return Ok(currentGame.Enemy);
		}

		// Attaque du h�ros
		[HttpGet("attack")]
		public IActionResult Attack()
		{
			if (currentGame == null)
				return BadRequest("Le jeu n'a pas �t� d�marr�. Veuillez appeler /game/start d'abord.");

			currentGame.HeroAttack();

			return Ok(new
			{
				Hero = currentGame.Hero,
				Enemy = currentGame.Enemy
			});
		}

		// Soin du h�ros
		[HttpGet("heal")]
		public IActionResult Heal()
		{
			if (currentGame == null)
				return BadRequest("Le jeu n'a pas �t� d�marr�. Veuillez appeler /game/start d'abord.");

			currentGame.HeroHeal();

			return Ok(new
			{
				Hero = currentGame.Hero,
				Enemy = currentGame.Enemy
			});
		}
	}
}