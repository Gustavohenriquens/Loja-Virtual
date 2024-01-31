using Microsoft.EntityFrameworkCore;

namespace LojaVirtualEstagio.Api.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pedido>? Pedidos { get; set; }
        public DbSet<PedidoItem>? PedidoItems { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }


        //Esse método basicamente cria tabelas no banco de dados já com registros.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Categorias
            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 1,
                Nome = "Sapato",
                Url = "url_sapato",
                Ativo = true,
                Excluido = false
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 2,
                Nome = "Sandalia",
                Url = "url_sandalia",
                Ativo = true,
                Excluido = false
            });

            //Produtos

            ///Produto = Sandalia

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 1,
                Nome = "Sandalia1",
                Url = "url_sandalia",
                Quantidade = 100,
                CategoriaId = 2,
                Ativo = true,
                Excluido = false
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 2,
                Nome = "Sandalia2",
                Url = "url_sandalia",
                Quantidade = 80,
                CategoriaId = 2,
                Ativo = true,
                Excluido = false
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 3,
                Nome = "Sandalia3",
                Url = "url_sandalia",
                Quantidade = 50,
                CategoriaId = 2,
                Ativo = true,
                Excluido = false
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 4,
                Nome = "Sandalia4",
                Url = "url_sandalia",
                Quantidade = 50,
                CategoriaId = 2,
                Ativo = false,
                Excluido = true
            });

            ///Produto = Sapato

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 5,
                Nome = "Sapato1",
                Url = "url_sapato",
                Quantidade = 45,
                CategoriaId = 1,
                Ativo = true,
                Excluido = false
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 6,
                Nome = "Sapato2",
                Url = "url_sapato",
                Quantidade = 10,
                CategoriaId = 1,
                Ativo = true,
                Excluido = false
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 7,
                Nome = "Sapato3",
                Url = "url_sapato",
                Quantidade = 30,
                CategoriaId = 1,
                Ativo = true,
                Excluido = false
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 8,  
                Nome = "Sapato4",
                Url = "url_sapato",
                Quantidade = 10,
                CategoriaId = 1,
                Ativo = false,
                Excluido = true
            });



            //Usuarios
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                Nome = "Gustavo",
                Login = "Guga123",
                Email = "Gustavo@example.com",
                Senha = "senha123",
                ChaveVerificacao = "chave-unico-para-verificacao",
                LastToken = "token-unico",
                IsVerificado = true,
                Ativo = true,
                Excluido = false,
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 2,
                Nome = "Henrique",
                Login = "Henrique123",
                Email = "Henrique@example.com",
                Senha = "senha12345",
                ChaveVerificacao = "outra-chave-unico",
                LastToken = "outro-token-unico",
                IsVerificado = true,
                Ativo = true,
                Excluido = false,
            });


            //Pedidos
            modelBuilder.Entity<Pedido>().HasData(new Pedido
            {
                Id = 1,
                UsuarioId = 1
            });

            modelBuilder.Entity<Pedido>().HasData(new Pedido
            {
                Id = 2,
                UsuarioId = 2
            });
        }

    }
}
