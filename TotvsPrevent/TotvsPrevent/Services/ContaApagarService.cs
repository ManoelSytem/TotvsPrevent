using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TotvsPrevent.Models;

namespace TotvsPrevent.Services
{
    public class ContaApagarService
    {
        private static ObservableCollection<ContaAPaga> ListModulo { get; set; }

        public ContaApagarService()
        {

        }

        public ObservableCollection<ContaAPaga> GetAll()
        {
            ListModulo = new ObservableCollection<ContaAPaga>();

            List<string> listTotais = new List<string>(new string[] { "R$ 9.850,00", "R$ 2.850,00", "R$ 7.850,00" });

            ContaAPaga Caixa1 = new ContaAPaga { Empresa = "Universo Matriz", filial = "Capim Grosso 02", Total = listTotais };
            ContaAPaga Caixa2 = new ContaAPaga { Empresa = "Constam", filial = "Feira de Santa 01", Total = listTotais };
            ContaAPaga Caixa3 = new ContaAPaga { Empresa = "Universo Matriz", filial = "Nova Fatima 02", Total = listTotais };

            ListModulo.Add(Caixa1);
            ListModulo.Add(Caixa2);
            ListModulo.Add(Caixa3);

            return ListModulo;
        }
    }
}
