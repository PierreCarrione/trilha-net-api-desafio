﻿using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.InputViewModels
{
    public class TarefaInputModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }
    }
}
