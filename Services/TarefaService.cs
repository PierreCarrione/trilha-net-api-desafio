using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<TarefaViewModel> Criar(TarefaInputModel model)
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

        public async Task<TarefaViewModel> Atualizar(int id, TarefaInputModel model)
        {
            var entity = await _context.Tarefas.FindAsync(id)
            ?? throw new KeyNotFoundException("Tarefa não encontrada para atualizar.");

            entity.Titulo = model.Titulo;
            entity.Descricao = model.Descricao;
            entity.Data = model.Data;
            entity.Status = model.Status;

            _context.Tarefas.Update(entity);
            await _context.SaveChangesAsync();

            return new TarefaViewModel
            {
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

        public async Task<IList<TarefaViewModel>> ObterTodos()
        {
            var tarefas = await _context.Tarefas.ToListAsync();

            return tarefas.Select(tarefa => new TarefaViewModel
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Data = tarefa.Data,
                Status = tarefa.Status
            }).ToList();
        }

        public async Task<TarefaViewModel> ObterPorTitulo(string titulo)
        {
            var tarefa = await _context.Tarefas.Where(t => t.Titulo == titulo).FirstOrDefaultAsync()
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

        public async Task<string> Deletar(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id)
            ?? throw new KeyNotFoundException("Tarefa não encontrada.");

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return "Tarefa excluída com sucesso!";
        }


    }
}
