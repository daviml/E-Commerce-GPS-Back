using Microsoft.AspNetCore.Mvc;
using EcommerceBackend.Models;
using EcommerceBackend.Services.Interfaces;
using EcommerceBackend.DTOs;
using System.Collections.Generic;

namespace EcommerceBackend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClientesController : ControllerBase
	{
		private readonly IClienteService _clienteService;

		public ClientesController(IClienteService clienteService)
		{
			_clienteService = clienteService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)] 
		public ActionResult<List<Cliente>> Get()
		{
			return Ok(_clienteService.GetClientes());
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)] 
		[ProducesResponseType(StatusCodes.Status400BadRequest)] 
		public ActionResult<Cliente> Post([FromBody] ClienteDTO clienteDto)
		{
			var cliente = new Cliente { Nome = clienteDto.Nome, CPF = clienteDto.CPF };
			var novoCliente = _clienteService.AdicionarCliente(cliente);
			return CreatedAtAction(nameof(Get), new { id = novoCliente.Id }, novoCliente);
		}
	}
}