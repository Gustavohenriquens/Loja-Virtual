using LojaVirtual.Models.DTOs;
using LojaVirtualEstagio.Api.Entities;

namespace LojaVirtualEstagio.Repository
{
    public interface IPedidoRepository
    {
        void AdicionarPedido(Pedido pedido);

        //
        List<PedidoComQuantidadeProdutosDto> ObterPedidosComQuantidadeProdutos();

        List<Pedido> ObterTodosPedidos();
        List<Pedido> ObterPedidosComItens();

    }
}
