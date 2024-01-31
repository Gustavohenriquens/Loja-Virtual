using LojaVirtualEstagio.Api.Entities;
using LojaVirtualEstagio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtualEstagio.Controllers
{
    [Route("api/lojaVirtual")]
    [ApiController]
    public class LojaVirtualController : ControllerBase
    {

        //Local onde está a lógica da aplicação.
        private readonly ICategoriaService _categoriaService;
        private readonly IProdutoService _produtoService;
        private readonly IAuthService _authService;
        private readonly IPedidoService _pedidoService;
        private readonly IPedidoQueryService _pedidoQueryService;
        private readonly IUsuarioService _usuarioService;

        private readonly ILogger<LojaVirtualController> _logger;



        public LojaVirtualController(
            IUsuarioService usuarioService,
            ICategoriaService categoriaService,
            IProdutoService produtoService,
            IAuthService authService,
            IPedidoService pedidoService,
            ILogger<LojaVirtualController> logger)
        {
            _usuarioService = usuarioService;
            _categoriaService = categoriaService;
            _produtoService = produtoService;
            _authService = authService;
            _pedidoService = pedidoService;
            _logger = logger;
        }

        //2. = OK
        [AllowAnonymous]
        [HttpPost("criarUsuario")]
        public IActionResult CriarUsuario([FromBody] UsuarioDto criandoUsuarioDto)
        {
            //return _usuarioService.CriarUsuario(criandoUsuarioDto);
            var resultado = _usuarioService.CriarUsuario(criandoUsuarioDto);
            return resultado != null ? Ok(resultado) : BadRequest();
        }

        //3. = OK
        [Authorize]
        [HttpPost("inserirEmailEChave")]
        public ActionResult InserirEmailEChave([FromBody] UsuarioDto usuarioDto)
        {
            return _usuarioService.InserirEmailEChave(usuarioDto);
        }

        //4. = OK
        [Authorize]
        [HttpGet("categoriasComProdutosAtivos")]
        public IActionResult ListarCategoriasComProdutosAtivos()
        {
            return _categoriaService.ListarCategoriasComProdutosAtivos();
        }

        //5. = OK
        [Authorize]
        [HttpGet("buscarCategoriasPorUrl/{url}")]
        public IActionResult BuscarCategoriasPorUrl(string url)
        {
            return _categoriaService.BuscarCategoriasPorUrl(url);
        }

        //6. = OK
        [Authorize]
        [HttpGet("buscarProdutoPorUrl/{url}")]
        public IActionResult BuscarProdutoPorUrl(string url)
        {
            return _produtoService.BuscarProdutoPorUrl(url);
        }


        //8. = OK
        [Authorize]
        [HttpPost("criarPedido")]
        public IActionResult CriarPedido([FromBody] PedidoDto pedidoDto)
        {
            try
            {
                if (pedidoDto == null || pedidoDto.ProdutosIds == null || pedidoDto.ProdutosIds.Count == 0)
                {
                    return BadRequest("Dados inválidos para criar o pedido.");
                }

                var pedido = new Pedido
                {
                    DataPedido = pedidoDto.DataPedido,
                    Itens = pedidoDto.ProdutosIds.Select(produtoId => new PedidoItem
                    {
                        ProdutoId = produtoId,
                        Quantidade = 1
                    }).ToList()
                };

                var pedidoId = _pedidoService.AdicionarPedido(pedido);

                return Ok(new { PedidoId = pedidoId, Mensagem = "Pedido criado com sucesso." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar pedido.");
                return StatusCode(500, "Erro interno ao criar o pedido. Entre em contato com o suporte.");
            }
        }


        //9. = OK
        [Authorize]
        [HttpGet("listarPedidosEQuantidadeProdutos")]
        public IActionResult ListarPedidosComQuantidadeProdutos()
        {
            try
            {
                var pedidos = _pedidoService.ObterTodosPedidos();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}
