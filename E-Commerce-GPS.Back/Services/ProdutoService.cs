using EcommerceBackend.Models;
using EcommerceBackend.Services.Interfaces;

namespace EcommerceBackend.Services
{
	public class ProdutoService : IProdutoService
	{
		private static List<Produto> _produtos = new List<Produto>();
		private static int _nextId = 1;

		public ProdutoService()
		{
			if (_produtos.Count == 0)
			{
				_produtos.Add(new Produto { Id = _nextId++, Nome = "Notebook", Preco = 5000.00m });
				_produtos.Add(new Produto { Id = _nextId++, Nome = "Mouse", Preco = 150.00m });
				_produtos.Add(new Produto { Id = _nextId++, Nome = "Teclado Mecânico", Preco = 400.00m });
			}
		}

		public List<Produto> GetProdutos()
		{
			return _produtos;
		}

		public Produto AdicionarProduto(Produto produto)
		{
			produto.Id = _nextId++;
			_produtos.Add(produto);
			return produto;
		}

		public Produto GetById(int id)
		{
			return _produtos.FirstOrDefault(p => p.Id == id);
		}
	}
}