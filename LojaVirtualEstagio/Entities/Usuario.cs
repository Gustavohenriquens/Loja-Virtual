    using System.ComponentModel.DataAnnotations;

    namespace LojaVirtualEstagio.Api.Entities
    {
        public class Usuario
        {

            [Key]
            public int Id { get; set; }

            [MaxLength(256)]
            public string Nome { get; set; }

            [MaxLength(256)]
            public string Login { get; set; }

            [MaxLength(256)]
            public string Email { get; set; }

            [MaxLength(256)]
            public string Senha { get; set; }

            [MaxLength(int.MaxValue)]
            public string ChaveVerificacao { get; set; }

            [MaxLength(int.MaxValue)]
            public string LastToken { get; set; }

            public bool IsVerificado { get; set; }
            public bool IsDeleted { get; set; }

            public bool Ativo { get; set; }

            public bool Excluido { get; set; }

            public Pedido? Pedido { get; set; }


    }
    }
