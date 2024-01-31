using LojaVirtualEstagio.Api.Entities;

namespace LojaVirtualEstagio.Repository
{
    public class UsuarioRepository  : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }



        public bool UsuarioExistente(string login)
        {
            return _context.Usuarios.Any(u => u.Login.ToLower() == login.ToLower());
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario ObterUsuarioPorEmailEChave(string email, string chaveVerificacao)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.Email == email && u.ChaveVerificacao == chaveVerificacao);
        }

        public void SalvarAlteracoes()
        {
            _context.SaveChanges();
        }



        public Usuario ObterUsuarioPorCredenciais(string username, string password)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Login == username && u.Senha == password);
        }

        public void AtualizarToken(Usuario usuario, string token)
        {
            usuario.LastToken = token;
            _context.SaveChanges();
        }


        public object ObterUsuarioPorId(int usuarioId)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
        }

    }
}
