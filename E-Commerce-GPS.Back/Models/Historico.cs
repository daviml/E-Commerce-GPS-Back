namespace EcommerceBackend.Models
{
	public class Historico
	{
		public int Id { get; set; }
		public int PedidoId { get; set; }
		public StatusPedido StatusAnterior { get; set; }
		public StatusPedido StatusAtual { get; set; }
		public DateTime DataAlteracao { get; set; }
		public string Descricao { get; set; }
	}
}