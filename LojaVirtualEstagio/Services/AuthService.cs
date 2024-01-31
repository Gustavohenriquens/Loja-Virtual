using LojaVirtualEstagio.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtualEstagio.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public IActionResult Autenticar(string username, string password)
        {
                var usuario = _usuarioRepository.ObterUsuarioPorCredenciais(username, password);

                if (usuario != null)
                {
                    var token = _tokenService.GenerateToken(usuario);

                    if (token != null)
                    {
                        _usuarioRepository.AtualizarToken(usuario, token.ToString());
                        return new OkObjectResult(new { Token = token, Usuario = usuario });
                    }
                    else
                    {
                        return new BadRequestObjectResult("Falha ao gerar o token.");
                    }
                }

                return new BadRequestObjectResult("Nome de usuário ou senha inválidos");
        }
    }
}

