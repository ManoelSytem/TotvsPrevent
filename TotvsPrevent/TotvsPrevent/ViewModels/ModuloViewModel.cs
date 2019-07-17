using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TotvsPrevent.Models;
using TotvsPrevent.Services;

namespace TotvsPrevent.ViewModels
{
    public class ModuloViewModel : NotificarBase
    {
        public ModuloService ModuloService;
        public ObservableCollection<Modulo> Modulo { get; set; }

        public ModuloViewModel()
        {
            ModuloService = new ModuloService();

            Modulo = new ObservableCollection<Modulo>
            {
            };
            Modulo = ModuloService.GetAll();
        }


        public Type ObterTypoPage(string modulo)
        {
            Type tipo = null;
            foreach (Modulo mod in ModuloService.GetAll())
            {
                if (mod.Nome == modulo)
                 return mod.TargetType;
            }

            return tipo;
        }

    }
}
