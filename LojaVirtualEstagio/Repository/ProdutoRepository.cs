using LojaVirtualEstagio.Api.Entities;

namespace LojaVirtualEstagio.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public object ObterProdutoPorId(int produtoId)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ObterProdutosPorUrl(string url)
        {
            return _context.Produtos
                .Where(p => p.Url == url)
                .ToList();
        }
    }
}
