using Microsoft.AspNetCore.Mvc;
using PedidoBebidas.Aplicacao.DTOs;
using PedidoBebidas.Aplicacao.Interfaces;

namespace PedidoBebidasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevendaController(IRevendaService _revendaService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<RevendaDTO_Out>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RevendaDTO_In>>> ListarTodas()
        {
            var revendas = await _revendaService.ListarTodasAsync();

            return Ok(revendas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RevendaDTO_Out), StatusCodes.Status200OK)]
        public async Task<ActionResult<RevendaDTO_In>> ObterPorId(Guid id)
        {
            var revenda = await _revendaService.ObterPorIdAsync(id);

            if (revenda == null)
                return NotFound();

            return Ok(revenda);
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] RevendaDTO_In revendaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _revendaService.CriarAsync(revendaDto);
            return CreatedAtAction(nameof(ObterPorId), new { result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(Guid id, [FromBody] RevendaDTO_In revendaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var atualizado = await _revendaService.AtualizarAsync(id, revendaDto);
            if (atualizado == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remover(Guid id)
        {
            var removido = await _revendaService.RemoverAsync(id);
            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
