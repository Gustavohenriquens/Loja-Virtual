using LojaVirtual.Models.DTOs;
using LojaVirtualEstagio.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtualEstagio.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AdicionarPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public List<Pedido> ObterTodosPedidos()
        {
            return _context.Pedidos.ToList();
        }



        public List<PedidoComQuantidadeProdutosDto> ObterPedidosComQuantidadeProdutos()
        {
            var pedidosComQuantidadeProdutos = _context.Pedidos
                .Include(pedido => pedido.Itens)
                .Select(pedido => new PedidoComQuantidadeProdutosDto
                {
                    PedidoId = pedido.Id,
                    DataPedido = pedido.DataPedido,
                    Produtos = pedido.Itens.Select(item => new ProdutoDto
                    {
                        ProdutoId = item.ProdutoId,
                        Nome = item.Produto.Nome,
                        Quantidade = item.Quantidade
                    }).ToList()
                })
                .ToList();

            return pedidosComQuantidadeProdutos;
        }

        public List<Pedido> ObterPedidosComItens()
        {
            return _context.Pedidos.Include(p => p.Itens).ToList();
        }
    }
}
