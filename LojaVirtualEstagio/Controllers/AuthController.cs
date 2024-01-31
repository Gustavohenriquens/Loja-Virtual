using LojaVirtualEstagio.Api.Entities;
using LojaVirtualEstagio.Models.DTOs;
using LojaVirtualEstagio.Repository;
using LojaVirtualEstagio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LojaVirtualEstagio.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public AuthController(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        //7.
        [HttpPost]
        public IActionResult Auth([FromBody] TokenDto tokenDto)
        {
            var tokenAuth = _usuarioRepository.ObterUsuarioPorCredenciais(tokenDto.Login, tokenDto.Senha);

            if (tokenAuth != null)
            {
                var token = _tokenService.GenerateToken(tokenAuth);
                return Ok(token);
            }

            return BadRequest("Usuário ou senha inválidos");
        }

    }
}
