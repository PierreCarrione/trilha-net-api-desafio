using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.InputViewModels;
using TrilhaApiDesafio.Interfaces;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var result = await _tarefaService.ObterPorId(id);

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            var result = await _tarefaService.ObterTodos();

            return Ok(result);
        }

        [HttpGet("ObterPorTitulo")]
        public async Task<IActionResult> ObterPorTitulo(string titulo)
        {
            var result = await _tarefaService.ObterPorTitulo(titulo);

            return Ok(result);
        }

        [HttpGet("ObterPorData")]
        public async Task<IActionResult> ObterPorData(DateTime data)
        {
            var result = await _tarefaService.ObterPorData(data);

            return Ok(result);
        }

        [HttpGet("ObterPorStatus")]
        public async Task<IActionResult> ObterPorStatus(EnumStatusTarefa status)
        {
            var result = await _tarefaService.ObterPorStatus(status);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] TarefaInputModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Data == DateTime.MinValue)
                    return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

                var result = await _tarefaService.Criar(model);

                return CreatedAtAction(nameof(ObterPorId), new { id = result.Id }, result);
            }

            return BadRequest("Verifique as informações digitadas."); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] TarefaInputModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _tarefaService.Atualizar(id, model);

                    return CreatedAtAction(nameof(ObterPorId), new { id = result.Id }, result);
                }
                catch (KeyNotFoundException ex)
                {
                    return NotFound(new { mensagem = ex.Message });
                }
            }

            return BadRequest("Verifique as informações digitadas.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var result = await _tarefaService.Deletar(id);

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
    }
}
