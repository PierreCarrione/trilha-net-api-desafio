using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.InputViewModels;
using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.ViewModels;

namespace TrilhaApiDesafio.Interfaces
{
    public interface ITarefaService
    {
        Task<TarefaViewModel> ObterPorId(int id);
        Task<IList<TarefaViewModel>> ObterTodos();
        Task<IList<TarefaViewModel>> ObterPorTitulo(string titulo);
        Task<IList<TarefaViewModel>> ObterPorData(DateTime data);
        Task<IList<TarefaViewModel>> ObterPorStatus(EnumStatusTarefa status);
        Task<TarefaViewModel> Criar(TarefaInputModel model);
        Task<TarefaViewModel> Atualizar(int id, TarefaInputModel model);
        Task<string> Deletar(int id);
    }
}
