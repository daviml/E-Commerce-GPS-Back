using EcommerceBackend.Models;
using EcommerceBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PedidosController : ControllerBase
	{
		private readonly IPedidoService _pedidoService;
		private readonly IClienteService _clienteService;
		private readonly IProdutoService _produtoService;

		private readonly IHistoricoService _historicoService;

		public PedidosController(IPedidoService pedidoService,
								 IClienteService clienteService,
								 IProdutoService produtoService,
								 IHistoricoService historicoService)
		{
			_pedidoService = pedidoService;
			_clienteService = clienteService;
			_produtoService = produtoService;
			_historicoService = historicoService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<List<Pedido>> Get([FromQuery] StatusPedido? status = null)
		{
			if (status.HasValue)
			{
				return Ok(_pedidoService.GetPedidosByStatus(status.Value));
			}
			return Ok(_pedidoService.GetPedidos());
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<Pedido> Post([FromBody] Pedido pedido)
		{
			var cliente = _clienteService.GetById(pedido.Cliente.Id);
			var produtos = new List<Produto>();

			foreach (var p in pedido.Produtos)
			{
				var produto = _produtoService.GetById(p.Id);
				if (produto != null)
				{
					produtos.Add(produto);
				}
			}

			pedido.Cliente = cliente;
			pedido.Produtos = produtos;

			if (cliente == null || !produtos.Any())
			{
				return BadRequest("Cliente ou produtos inválidos.");
			}

			var novoPedido = _pedidoService.CriarPedido(pedido);
			return CreatedAtAction(nameof(Get), new { id = novoPedido.Id }, novoPedido);
		}

		[HttpPut("{id}/pagar")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Pagar(int id)
		{
			var pedido = _pedidoService.PagarPedido(id);
			if (pedido == null)
			{
				return NotFound();
			}
			return Ok(pedido);
		}

		[HttpPut("{id}/cancelar")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Cancelar(int id)
		{
			var pedido = _pedidoService.CancelarPedido(id);
			if (pedido == null)
			{
				return NotFound();
			}
			return Ok(pedido);
		}
	}
}