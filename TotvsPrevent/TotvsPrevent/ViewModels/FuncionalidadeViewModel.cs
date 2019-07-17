using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TotvsPrevent.Models;
using TotvsPrevent.Services;

namespace TotvsPrevent.ViewModels
{
    public class FuncionalidadeViewModel : NotificarBase
    {

        public FuncionalidadeService FuncionalidadeService;
        public ObservableCollection<Funcionalidade> Funcionalidade { get; set; }

        public FuncionalidadeViewModel()
        {
            FuncionalidadeService = new FuncionalidadeService();

            Funcionalidade = new ObservableCollection<Funcionalidade>
            {
            };

            Funcionalidade = FuncionalidadeService.GetAll();
        }

    }
}
