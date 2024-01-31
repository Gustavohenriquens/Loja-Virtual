using LojaVirtualEstagio.Api.Entities;

namespace LojaVirtual.Models.DTOs
{
    public class PedidoComQuantidadeProdutosDto
    {
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public List<ProdutoDto>? Produtos { get; set; }
    }
}
