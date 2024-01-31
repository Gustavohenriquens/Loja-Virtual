using System.ComponentModel.DataAnnotations;

namespace LojaVirtualEstagio.Api.Entities
{
    public class PedidoDto
    {
        public int UsuarioId { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public List<int> ProdutosIds { get; set; } = new List<int>();

    }
}
