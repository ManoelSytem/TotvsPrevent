using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TotvsPrevent.Models;

namespace TotvsPrevent.Services
{
    public class ContaApagarService
    {
        private static ObservableCollection<Caixa> ListModulo { get; set; }

        public ContaApagarService()
        {

        }

        public ObservableCollection<Caixa> GetAll()
        {
            ListModulo = new ObservableCollection<Caixa>();

            Caixa Caixa1 = new Caixa { filial = "01", Tipo = "Contas a Pagar", Valor = "R$ 9.850,00", Departamento = "Engenharia/Operações" };
            Caixa Caixa2 = new Caixa { filial = "01", Tipo = "Contas a Pagar", Valor = "R$ 20.745,00", Departamento = "Limpeza" };
            Caixa Caixa3 = new Caixa { filial = "01", Tipo = "Contas a Pagar", Valor = "R$ 40.745,00", Departamento = "Recursos Humanos" };

            ListModulo.Add(Caixa1);
            ListModulo.Add(Caixa2);
            ListModulo.Add(Caixa3);

            return ListModulo;
        }
    }
}
