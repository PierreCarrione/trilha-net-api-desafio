using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.InputViewModels;
using TrilhaApiDesafio.Interfaces;
using TrilhaApiDesafio.Models;
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

        public async Task<TarefaViewModel> Criar(CreateTarefaInputModel model)
        {
            var entity = new Tarefa
            {
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                Data = model.Data,
                Status = model.Status,
            };

            await _context.Tarefas.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new TarefaViewModel {
                Id = entity.Id,
                Titulo = entity.Titulo,
                Descricao = entity.Descricao,
                Data = entity.Data,
                Status = entity.Status,
            };
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
