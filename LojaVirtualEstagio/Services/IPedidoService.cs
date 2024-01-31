using LojaVirtualEstagio.Api.Entities;

namespace LojaVirtualEstagio.Services
{
    public interface IPedidoService
    {
        int AdicionarPedido(Pedido pedido);

        //

        List<Pedido> ObterTodosPedidos();
    }

}
