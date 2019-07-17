using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TotvsPrevent.Models;
using TotvsPrevent.Views.Finaceiro;

namespace TotvsPrevent.Services
{
    public class ModuloService
    {
        private static ObservableCollection<Modulo> ListModulo { get; set; }

        public ModuloService()
        {
           
        }

        public ObservableCollection<Modulo> GetAll()
        {
            ListModulo = new ObservableCollection<Modulo>();

            ListModulo.Add(new Modulo()
            {
                Servico = "Prothues",
                Nome = "Finaceiro",
                Descricao = "Finaceiro",
                TargetType = typeof(FinaceiraViewPage)
            });

            ListModulo.Add(new Modulo()
            {
                Servico = "Prothues",
                Nome = "Fiscal",
                Descricao = "Fiscal",
            });

            ListModulo.Add(new Modulo()
            {
                Servico = "Prothues",
                Nome = "Faturamento",
                Descricao = "Faturamento",
            });

            return ListModulo;
        }
    }
}
