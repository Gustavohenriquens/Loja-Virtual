using LojaVirtualEstagio.Api.Entities;
using LojaVirtualEstagio.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtualEstagio.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult BuscarProdutoPorUrl(string url)
        {
            var produtos = _produtoRepository.ObterProdutosPorUrl(url);

            if (produtos == null || produtos.Count == 0)
            {
                return new NotFoundObjectResult(new { Mensagem = "Nenhum produto encontrado para a URL especificada." });
            }

            var produtosDto = produtos
                .Select(p => new ProdutoDto
                {
                    CategoriaId = p.CategoriaId,
                    Nome = p.Nome,
                    Url = p.Url,
                    Quantidade = p.Quantidade
                })
                .ToList();

            return new OkObjectResult(produtosDto);
        }
    }
}
