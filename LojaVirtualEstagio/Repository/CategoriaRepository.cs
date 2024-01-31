using LojaVirtualEstagio.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace LojaVirtualEstagio.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Categoria> ObterCategoriasComProdutosAtivos()
        {
            return _context.Categorias
            .Include(c => c.Produtos)
            .Where(c => c.Produtos.Any(p => p.Ativo && p.Quantidade > 0))
            .ToList();
        }

        public Categoria ObterCategoriaPorUrl(string url)
        {
            //return _context.Categorias.SingleOrDefault(c => c.Url.ToLower() == url.ToLower());
            return _context.Categorias
            .Include(c => c.Produtos)
            .SingleOrDefault(c => c.Url.ToLower() == url.ToLower());
        }   

        public List<Produto> ObterProdutosPorCategoria(string url)
        {
            return _context.Produtos
               .Where(p => p.Url.ToLower() == url.ToLower())
               .ToList();   
        }



    }
}
