using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.InputViewModels;
using TrilhaApiDesafio.ViewModels;

namespace TrilhaApiDesafio.Interfaces
{
    public interface ITarefaService
    {
        Task<TarefaViewModel> ObterPorId(int id); 
        Task<TarefaViewModel> Criar(CreateTarefaInputModel model); 
    }
}
