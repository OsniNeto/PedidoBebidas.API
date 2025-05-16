using Microsoft.AspNetCore.Mvc;
using PedidoBebidas.Aplicacao.DTOs;
using PedidoBebidas.Aplicacao.Interfaces;

namespace PedidoBebidasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmissaoController(IEmissaoService _emissaoService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<EmissaoDTO_Out>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EmissaoDTO_In>>> ListarTodas()
        {
            var emissoes = await _emissaoService.ListarTodasAsync();
            return Ok(emissoes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmissaoDTO_Out), StatusCodes.Status200OK)]
        public async Task<ActionResult<EmissaoDTO_In>> ObterPorId(Guid id)
        {
            var emissao = await _emissaoService.ObterPorIdAsync(id);

            if (emissao == null)
                return NotFound();

            return Ok(emissao);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<EmissaoDTO_Out>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Criar([FromBody] EmissaoDTO_In emissaoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _emissaoService.CriarAsync(emissaoDto);
            return CreatedAtAction(nameof(ObterPorId), new { result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(Guid id, [FromBody] EmissaoDTO_In emissaoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var atualizado = await _emissaoService.AtualizarAsync(id, emissaoDto);
            if (atualizado == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remover(Guid id)
        {
            var removido = await _emissaoService.RemoverAsync(id);

            if (!removido)
                return NotFound();

            return NoContent();
        }

        [HttpPost("{id}/enviar")]
        [ProducesResponseType(typeof(List<EmissaoDTO_Out>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Enviar(Guid id)
        {
            var result = await _emissaoService.EnviarAsync(id);
            return CreatedAtAction(nameof(ObterPorId), new { result.Id }, result);
        }

    }
}