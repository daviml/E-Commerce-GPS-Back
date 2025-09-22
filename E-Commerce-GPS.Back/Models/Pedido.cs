namespace EcommerceBackend.Models
{
	public enum StatusPedido
	{
		Criado,
		Pago,
		Cancelado
	}

	public class Pedido
	{
		public int Id { get; set; }
		public Cliente Cliente { get; set; }
		public List<Produto> Produtos { get; set; } = new List<Produto>();
		public DateTime DataDoPedido { get; set; }
		public StatusPedido Status { get; set; }
		public decimal ValorTotal => Produtos.Sum(p => p.Preco);
	}
}