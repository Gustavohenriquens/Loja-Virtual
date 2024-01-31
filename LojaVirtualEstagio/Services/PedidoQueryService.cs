using LojaVirtualEstagio.Repository;

namespace LojaVirtualEstagio.Services
{
    public class PedidoQueryService : IPedidoQueryService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoQueryService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IEnumerable<object> ListarPedidosEQuantidadeProdutos()
        {
            var pedidos = _pedidoRepository.ObterPedidosComItens();

            return pedidos.Select(p => new
            {
                PedidoId = p.Id,
                DataPedido = p != null ? p.DataPedido : DateTime.MinValue,
                QuantidadeProdutos = p?.Itens?.Sum(item => item.Quantidade) ?? 0
            }).ToList();
        }
    }
}
