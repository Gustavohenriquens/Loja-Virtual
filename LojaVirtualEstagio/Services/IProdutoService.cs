using Microsoft.AspNetCore.Mvc;

namespace LojaVirtualEstagio.Services
{
    public interface IProdutoService
    {
        IActionResult BuscarProdutoPorUrl(string url);
    }
}
