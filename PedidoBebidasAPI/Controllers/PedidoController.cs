using Microsoft.AspNetCore.Mvc;
using PedidoBebidas.Aplicacao.DTOs;
using PedidoBebidas.Aplicacao.Interfaces;

namespace PedidoBebidasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController(IPedidoService _pedidoService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<PedidoDTO_Out>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PedidoDTO_In>>> ListarTodas()
        {
            var pedidos = await _pedidoService.ListarTodasAsync();
            return Ok(pedidos);
        }

        [HttpGet]
        [Route("naoEmitidos")]
        [ProducesResponseType(typeof(List<PedidoDTO_Out>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PedidoDTO_In>>> ListarNaoEmitidos()
        {
            var pedidos = await _pedidoService.ListarNaoEmitidosAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PedidoDTO_Out), StatusCodes.Status200OK)]
        public async Task<ActionResult<PedidoDTO_In>> ObterPorId(Guid id)
        {
            var pedido = await _pedidoService.ObterPorIdAsync(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<PedidoDTO_Out>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Criar([FromBody] PedidoDTO_In pedidoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _pedidoService.CriarAsync(pedidoDto);
            return CreatedAtAction(nameof(ObterPorId), new { result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(Guid id, [FromBody] PedidoDTO_In pedidoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var atualizado = await _pedidoService.AtualizarAsync(id, pedidoDto);
            if (atualizado == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remover(Guid id)
        {
            var removido = await _pedidoService.RemoverAsync(id);

            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}