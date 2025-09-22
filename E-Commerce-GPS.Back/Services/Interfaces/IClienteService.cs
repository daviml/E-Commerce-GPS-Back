using EcommerceBackend.Models;

namespace EcommerceBackend.Services.Interfaces
{
	public interface IClienteService
	{
		List<Cliente> GetClientes();
		Cliente AdicionarCliente(Cliente cliente);
		Cliente GetById(int id);
	}
}