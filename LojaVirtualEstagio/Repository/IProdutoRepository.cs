using LojaVirtualEstagio.Api.Entities;

namespace LojaVirtualEstagio.Repository
{
    public interface IProdutoRepository
    {
        object ObterProdutoPorId(int produtoId);
        List<Produto> ObterProdutosPorUrl(string url);
    }
}
