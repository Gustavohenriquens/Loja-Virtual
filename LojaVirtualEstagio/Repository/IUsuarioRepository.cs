using LojaVirtualEstagio.Api.Entities;

namespace LojaVirtualEstagio.Repository
{
    public interface IUsuarioRepository
    {
        bool UsuarioExistente(string login);
        void AdicionarUsuario(Usuario usuario);

        //

        Usuario ObterUsuarioPorEmailEChave(string email, string chaveVerificacao);
        void SalvarAlteracoes();

        //

        Usuario ObterUsuarioPorCredenciais(string username, string password);
        void AtualizarToken(Usuario usuario, string token);


        object ObterUsuarioPorId(int usuarioId);
    }
}
