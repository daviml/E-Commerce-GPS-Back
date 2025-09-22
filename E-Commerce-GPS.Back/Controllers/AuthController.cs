using Microsoft.AspNetCore.Mvc;
using EcommerceBackend.Models;

namespace EcommerceBackend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private static readonly Usuario user = new Usuario
		{
			Id = 1,
			Nome = "teste",
			Senha = "123"
		};

		[HttpPost("login")]
		public IActionResult Login([FromBody] Usuario loginUser)
		{
			if (loginUser.Nome == user.Nome && loginUser.Senha == user.Senha)
			{
				return Ok(new { message = "Login successful" });
			}

			return Unauthorized(new { message = "Invalid credentials" });
		}
	}
}