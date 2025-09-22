using EcommerceBackend.Models;
using EcommerceBackend.Services.Interfaces;

namespace EcommerceBackend.Services
{
	public class ClienteService : IClienteService
	{
		// Simula um banco de dados em memória
		private static List<Cliente> _clientes = new List<Cliente>();
		private static int _nextId = 1;

		public List<Cliente> GetClientes()
		{
			return _clientes;
		}

		public Cliente AdicionarCliente(Cliente cliente)
		{
			cliente.Id = _nextId++;
			_clientes.Add(cliente);
			return cliente;
		}

		public Cliente GetById(int id)
		{
			return _clientes.FirstOrDefault(c => c.Id == id);
		}
	}
}