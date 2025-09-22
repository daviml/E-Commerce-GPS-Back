using Xunit;
using EcommerceBackend.Models;
using EcommerceBackend.Services;
using EcommerceBackend.Services.Interfaces;
using System.Collections.Generic;

public class MockHistoricoService : IHistoricoService
{
	public void AdicionarHistorico(Historico historico)
	{
	}

	public List<Historico> GetHistoricoByPedidoId(int pedidoId)
	{
		return new List<Historico>();
	}
}

public class PedidoServiceTests
{
	[Fact]
	public void CancelarPedido_AlteraStatusParaCancelado()
	{
		// Prepara
		var historicoService = new MockHistoricoService();
		var pedidoService = new PedidoService(historicoService);

		var pedido = new Pedido
		{
			Id = 1,
			Cliente = new Cliente(),
			Produtos = new List<Produto>(),
			Status = StatusPedido.Criado
		};

		// Adiciona o pedido
		typeof(PedidoService).GetField("_pedidos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
							 .SetValue(null, new List<Pedido> { pedido });

		// Executar
		var resultado = pedidoService.CancelarPedido(1);

		// Verificar
		Assert.NotNull(resultado);
		Assert.Equal(StatusPedido.Cancelado, resultado.Status);
	}

	[Fact]
	public void CancelarPedido_NaoDeveAlterarStatus_QuandoEstiverPago()
	{
		// Preparar
		var historicoService = new MockHistoricoService();
		var pedidoService = new PedidoService(historicoService);

		var pedido = new Pedido
		{
			Id = 2,
			Cliente = new Cliente(),
			Produtos = new List<Produto>(),
			Status = StatusPedido.Pago
		};

		typeof(PedidoService).GetField("_pedidos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
							 .SetValue(null, new List<Pedido> { pedido });

		// Executar
		var resultado = pedidoService.CancelarPedido(2);

		// Verificar
		Assert.NotNull(resultado);
		Assert.Equal(StatusPedido.Pago, resultado.Status);
	}

	[Fact]
	public void CriaPedido()
	{
		// Prepara
		var historicoService = new MockHistoricoService();
		var pedidoService = new PedidoService(historicoService);
		var novoPedido = new Pedido
		{
			Cliente = new Cliente(),
			Produtos = new List<Produto>()
		};

		// Executa
		var resultado = pedidoService.CriarPedido(novoPedido);

		// Verifica
		Assert.NotNull(resultado);
		Assert.True(resultado.Id > 0);
		Assert.Equal(StatusPedido.Criado, resultado.Status);
	}

	[Fact]
	public void PagaPedido()
	{
		// Prepara
		var historicoService = new MockHistoricoService();
		var pedidoService = new PedidoService(historicoService);

		var pedido = new Pedido
		{
			Id = 3,
			Cliente = new Cliente(),
			Produtos = new List<Produto>(),
			Status = StatusPedido.Criado
		};

		typeof(PedidoService).GetField("_pedidos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
							 .SetValue(null, new List<Pedido> { pedido });

		// Executa
		var resultado = pedidoService.PagarPedido(3);

		// Verifica
		Assert.NotNull(resultado);
		Assert.Equal(StatusPedido.Pago, resultado.Status);
	}
}