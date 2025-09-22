using EcommerceBackend.Models;
using EcommerceBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EcommerceBackend.DTOs;

namespace EcommerceBackend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProdutosController : ControllerBase
	{
		private readonly IProdutoService _produtoService;

		public ProdutosController(IProdutoService produtoService)
		{
			_produtoService = produtoService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<List<Produto>> Get()
		{
			return Ok(_produtoService.GetProdutos());
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<Produto> Post([FromBody] ProdutoDTO produtoDto)
		{
			var produto = new Produto
			{
				Nome = produtoDto.Nome,
				Preco = produtoDto.Preco
			};

			var novoProduto = _produtoService.AdicionarProduto(produto);
			return CreatedAtAction(nameof(Get), new { id = novoProduto.Id }, novoProduto);
		}
	}
}