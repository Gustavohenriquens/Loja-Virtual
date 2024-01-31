using Microsoft.AspNetCore.Mvc;

namespace LojaVirtualEstagio.Services
{
    public interface ICategoriaService
    {
        IActionResult ListarCategoriasComProdutosAtivos();

        //

        IActionResult BuscarCategoriasPorUrl(string url);

        //

    }
}
