using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.ViewModels;

namespace TrilhaApiDesafio.Interfaces
{
    public interface ITarefaService
    {
        Task<TarefaViewModel> ObterPorId(int id);
    }
}
