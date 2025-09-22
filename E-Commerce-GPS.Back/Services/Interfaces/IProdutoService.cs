using EcommerceBackend.Models;

namespace EcommerceBackend.Services.Interfaces
{
	public interface IProdutoService
	{
		List<Produto> GetProdutos();
		Produto AdicionarProduto(Produto produto);
		Produto GetById(int id);
	}
}