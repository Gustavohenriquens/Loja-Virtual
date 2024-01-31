using LojaVirtual.Models.DTOs;
using LojaVirtualEstagio.Api.Entities;
using LojaVirtualEstagio.Repository;

namespace LojaVirtualEstagio.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;

        }

        public int AdicionarPedido(Pedido pedido)
        {
            _pedidoRepository.AdicionarPedido(pedido);
            return pedido.Id;
        }

    public List<Pedido> ObterTodosPedidos()
    {
        return _pedidoRepository.ObterTodosPedidos();
    }

    public List<PedidoComQuantidadeProdutosDto> ObterPedidosComQuantidadeProdutos()
    {
        var pedidosComQuantidadeProdutos = _pedidoRepository.ObterPedidosComQuantidadeProdutos();
        return pedidosComQuantidadeProdutos;
    }

    }
}
