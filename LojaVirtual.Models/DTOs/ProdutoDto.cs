namespace LojaVirtualEstagio.Api.Entities
{
    public class ProdutoDto
    {
        public int ProdutoId { get; set; }
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Url { get; set; }
        public int Quantidade { get; set; }
    }
}
