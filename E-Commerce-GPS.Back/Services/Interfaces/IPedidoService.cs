using EcommerceBackend.Models;

namespace EcommerceBackend.Services.Interfaces
{
	public interface IPedidoService
	{
		List<Pedido> GetPedidos();
		List<Pedido> GetPedidosByStatus(StatusPedido status);
		Pedido CriarPedido(Pedido pedido);
		Pedido PagarPedido(int id);
		Pedido CancelarPedido(int id);
	}
}