using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtualEstagio.Api.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(int.MaxValue)]
        public string Nome { get; set; }

        [MaxLength(int.MaxValue)]
        public string Url { get; set; }

        public bool Ativo { get; set; }

        public bool Excluido { get; set; }

        public Collection<Produto> Produtos { get; set; }
                = new Collection<Produto>();
    }
}
