using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.InputViewModels;
using TrilhaApiDesafio.ViewModels;

namespace TrilhaApiDesafio.Interfaces
{
    public interface ITarefaService
    {
        Task<TarefaViewModel> ObterPorId(int id); 
        Task<TarefaViewModel> Criar(TarefaInputModel model);
        Task<string> Deletar(int id);
        Task<TarefaViewModel> Atualizar(int id, TarefaInputModel model);
        Task<IList<TarefaViewModel>> ObterTodos();
    }
}
