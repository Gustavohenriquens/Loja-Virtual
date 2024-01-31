using System.ComponentModel.DataAnnotations;

namespace LojaVirtualEstagio.Api.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        public int CategoriaId { get; set; }

        [MaxLength(int.MaxValue)]
        public string Nome { get; set; }

        [MaxLength(int.MaxValue)]
        public string Url { get; set; }

        public int Quantidade { get; set; }

        public bool Ativo { get; set; }

        public bool Excluido { get; set; }

        public virtual Categoria Categoria { get; set; }

        public ICollection<PedidoItem> Itens { get; set; }
            = new List<PedidoItem>();

    }
}
