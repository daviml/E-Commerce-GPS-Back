using EcommerceBackend.Models;
using EcommerceBackend.Services.Interfaces;

namespace EcommerceBackend.Services
{
	public class HistoricoService : IHistoricoService
	{
		private static List<Historico> _historico = new List<Historico>();
		private static int _nextId = 1;

		public void AdicionarHistorico(Historico historico)
		{
			historico.Id = _nextId++;
			_historico.Add(historico);
		}

		public List<Historico> GetHistoricoByPedidoId(int pedidoId)
		{
			return _historico.Where(h => h.PedidoId == pedidoId).ToList();
		}
	}
}