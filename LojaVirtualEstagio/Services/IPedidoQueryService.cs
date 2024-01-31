namespace LojaVirtualEstagio.Services
{
    public interface IPedidoQueryService
    {
        IEnumerable<object> ListarPedidosEQuantidadeProdutos();
    }
}
