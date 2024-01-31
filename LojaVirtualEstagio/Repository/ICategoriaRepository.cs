using LojaVirtualEstagio.Api.Entities;

namespace LojaVirtualEstagio.Repository
{
    public interface ICategoriaRepository
    {
        List<Categoria> ObterCategoriasComProdutosAtivos();

        //

        Categoria ObterCategoriaPorUrl(string url);
        List<Produto> ObterProdutosPorCategoria(string url);
    }
}
