using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views.Finaceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Teste : ContentPage
    {
        public List<Weather> Weathers { get => WeatherData(); }
        public Teste()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private List<ContaPagarEmpresa> WeatherData()
        {
            var listaContaApagarEmpresa = new List<ContaPagarEmpresa>();
            listaContaApagarEmpresa.Add(new ContaPagarEmpresa { Servico = "Limpeza", valor = "R$ 3.646,00", Dapartamento = "RH" });
            listaContaApagarEmpresa.Add(new ContaPagarEmpresa { Servico = "Elétrica", valor = "R$ 3.646,00", Dapartamento = "Engenharia" });
            listaContaApagarEmpresa.Add(new ContaPagarEmpresa { Servico = "Estoque", valor = "R$ 3.646,00", Dapartamento = "Engenharia" });
            listaContaApagarEmpresa.Add(new ContaPagarEmpresa { Servico = "Estoque", valor = "R$ 3.646,00", Dapartamento = "Engenharia" });
            listaContaApagarEmpresa.Add(new ContaPagarEmpresa { Servico = "Estoque", valor = "R$ 3.646,00", Dapartamento = "Engenharia" });
            listaContaApagarEmpresa.Add(new ContaPagarEmpresa { Servico = "Estoque", valor = "R$ 3.646,00", Dapartamento = "Engenharia" });

            return listaContaApagarEmpresa;
        }
    }

    public class ContaPagarEmpresa
    {
        public string Servico { get; set; }

        public string Dapartamento { get; set; }
        public string valor { get; set; }
    }
}
}
