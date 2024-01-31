using LojaVirtualEstagio.Api.Entities;
using LojaVirtualEstagio.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtualEstagio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public UsuarioService(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }




        //Criação de usuários
        public IActionResult CriarUsuario(UsuarioDto criandoUsuarioDto)
        {
                if (_usuarioRepository.UsuarioExistente(criandoUsuarioDto.Login))
                {
                    return new BadRequestObjectResult(new { Mensagem = "Usuário com o mesmo login já existe." });
                }

                var novoUsuario = new Usuario
                {
                    Nome = criandoUsuarioDto.Nome,
                    Login = criandoUsuarioDto.Login,
                    Email = criandoUsuarioDto.Email,
                    Senha = criandoUsuarioDto.Senha,
                    Ativo = true,
                    Excluido = false,
                    ChaveVerificacao = Guid.NewGuid().ToString(),
                    LastToken = _tokenService.GenerateToken(new Usuario()).ToString() //Tópico 7 = Armazenando JWT no LastToken do usuario.
                };

                _usuarioRepository.AdicionarUsuario(novoUsuario);

                return new OkObjectResult(new { Mensagem = "Usuário criado com sucesso." });
            }



        public ActionResult InserirEmailEChave(UsuarioDto usuarioDto)
        {
            var usuarioExistenteNoBancoDeDados = _usuarioRepository.ObterUsuarioPorEmailEChave(usuarioDto.Email, usuarioDto.ChaveVerificacao);

            if (usuarioExistenteNoBancoDeDados != null)
            {
              
                usuarioExistenteNoBancoDeDados.IsVerificado = true;
           
                _usuarioRepository.SalvarAlteracoes();

                return new OkObjectResult(new { Mensagem = "Usuário foi verificado ou encontrado com sucesso!" });
            }
            else
            {            
                return new BadRequestObjectResult(new { Mensagem = "Usuário não encontrado ou a ChaveVerificacao está errada!" });
            }
        }
    }

}

