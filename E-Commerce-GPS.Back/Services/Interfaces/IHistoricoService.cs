using EcommerceBackend.Models;
using System.Collections.Generic;

namespace EcommerceBackend.Services.Interfaces
{
	public interface IHistoricoService
	{
		void AdicionarHistorico(Historico historico);
		List<Historico> GetHistoricoByPedidoId(int pedidoId);
	}
}