    using LojaVirtualEstagio.Api.Entities;
    using Microsoft.AspNetCore.Mvc;

    namespace LojaVirtualEstagio.Services
    {
        public interface IUsuarioService
        {
            IActionResult CriarUsuario(UsuarioDto criandoUsuarioDto);

        //

            ActionResult InserirEmailEChave(UsuarioDto usuarioDto);
   
    }
    }
