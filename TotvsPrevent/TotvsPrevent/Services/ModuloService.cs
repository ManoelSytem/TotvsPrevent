using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TotvsPrevent.Models;
using TotvsPrevent.Views;
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
                Servico = "Protheus",
                Nome = "Financeiro",
                Descricao = "Finaceiro",
                TargetType = typeof(FinaceiraViewPage)
            });

            ListModulo.Add(new Modulo()
            {
                Servico = "Protheus",
                Nome = "Fiscal",
                Descricao = "Fiscal",
                TargetType = typeof(ConstrucaoView)
                
            });

            ListModulo.Add(new Modulo()
            {
                Servico = "Protheus",
                Nome = "Faturamento",
                Descricao = "Faturamento",
                TargetType = typeof(ConstrucaoView)
            });

            return ListModulo;
        }
    }
}
