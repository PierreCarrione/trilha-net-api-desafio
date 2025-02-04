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
        public IActionResult ObterPorTitulo(string titulo)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData
            return Ok();
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            //var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date);
            //return Ok(tarefa);
            return Ok();
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o status recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData
            //var tarefa = _context.Tarefas.Where(x => x.Status == status);
            //return Ok(tarefa);
            return Ok();
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
