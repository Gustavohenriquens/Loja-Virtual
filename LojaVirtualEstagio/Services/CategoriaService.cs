using LojaVirtualEstagio.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LojaVirtualEstagio.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }


        //Esse método lista as categorias com os produtos ativos
        public IActionResult ListarCategoriasComProdutosAtivos()
        {
            var categoriasComProdutosAtivos = _categoriaRepository.ObterCategoriasComProdutosAtivos();

            if (categoriasComProdutosAtivos.Count == 0)
            {
                return new NotFoundObjectResult(new { Mensagem = "Não foram encontradas categorias com produtos ativos." });
            }

            //
            var resultadoFinal = categoriasComProdutosAtivos.Select(categoria => new
            {
                categoria.Id,
                categoria.Nome,
                categoria.Url,
                categoria.Ativo,
                categoria.Excluido,
                Produtos = categoria.Produtos
                    .Where(p => p.Ativo && p.Quantidade > 0)
                    .Select(p => new
                    {
                        p.Id,
                        p.Nome,
                        p.Url,
                        p.Quantidade,
                        p.CategoriaId,
                        p.Ativo,
                        p.Excluido
                    })
                    .ToList()
            }).ToList();

            return new OkObjectResult(resultadoFinal);
        }


        //Esse método busca as categorias pela url  
        public IActionResult BuscarCategoriasPorUrl(string url)
        {
            var categoria = _categoriaRepository.ObterCategoriaPorUrl(url);

            if (categoria == null)
            {
                return new NotFoundObjectResult(new { Mensagem = "Categoria não encontrada." });
            }

            if (!categoria.Ativo)
            {
                return new BadRequestObjectResult(new { Mensagem = "A categoria não está disponível." });
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var categoriaJson = JsonSerializer.Serialize(categoria, options);
            var categoriaObjeto = JsonSerializer.Deserialize<object>(categoriaJson, options);

            return new OkObjectResult(new { Categoria = categoriaObjeto });



        }

    }
}
