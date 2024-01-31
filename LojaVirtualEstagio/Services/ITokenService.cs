using LojaVirtualEstagio.Api.Entities;

namespace LojaVirtualEstagio.Services
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}