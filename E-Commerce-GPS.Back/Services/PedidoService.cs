using EcommerceBackend.Models;
using EcommerceBackend.Services.Interfaces;

namespace EcommerceBackend.Services
{
	public class PedidoService : IPedidoService
	{
		private readonly IHistoricoService _historicoService;
		private static List<Pedido> _pedidos = new List<Pedido>();
		private static int _nextId = 1;

		public PedidoService(IHistoricoService historicoService)
		{
			_historicoService = historicoService;
		}

		public List<Pedido> GetPedidos()
		{
			return _pedidos;
		}

		public List<Pedido> GetPedidosByStatus(StatusPedido status)
		{
			return _pedidos.Where(p => p.Status == status).ToList();
		}

		public Pedido CriarPedido(Pedido pedido)
		{
			pedido.Id = _nextId++;
			pedido.DataDoPedido = DateTime.Now;
			pedido.Status = StatusPedido.Criado;
			_pedidos.Add(pedido);
			return pedido;
		}

		public Pedido PagarPedido(int id)
		{
			var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
			if (pedido != null)
			{
				pedido.Status = StatusPedido.Pago;
			}
			return pedido;
		}

		public Pedido CancelarPedido(int id)
		{
			var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
			if (pedido != null && pedido.Status != StatusPedido.Pago)
			{
				pedido.Status = StatusPedido.Cancelado;
			}
			return pedido;
		}
	}
}