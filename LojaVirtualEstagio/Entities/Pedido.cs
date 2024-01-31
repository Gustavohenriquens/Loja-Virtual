using System.ComponentModel.DataAnnotations;

namespace LojaVirtualEstagio.Api.Entities
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;


        //É uma coleção de itens relacionados a um pedido.
        public ICollection<PedidoItem> Itens { get; set; }
                = new List<PedidoItem>();
    }
}
