using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Interfaces;
using TrilhaApiDesafio.ViewModels;

namespace TrilhaApiDesafio.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly OrganizadorContext _context;

        public TarefaService(OrganizadorContext context)
        {
            _context = context;
        }

        public async Task<TarefaViewModel> ObterPorId(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id)
            ?? throw new KeyNotFoundException("Tarefa não encontrada.");

            return new TarefaViewModel
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Data = tarefa.Data,
                Status = tarefa.Status,
            };
        }
    }
}
