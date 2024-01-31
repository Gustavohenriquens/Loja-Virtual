using Microsoft.AspNetCore.Mvc;

namespace LojaVirtualEstagio.Services
{
    public interface IAuthService
    {
        IActionResult Autenticar(string username, string password);
    }
}
