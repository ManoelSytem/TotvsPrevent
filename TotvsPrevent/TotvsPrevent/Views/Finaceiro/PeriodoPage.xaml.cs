using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Models;
using TotvsPrevent.Services;
using TotvsPrevent.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views.Finaceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeriodoPage : ContentPage
    {
        public Funcionalidade func;
        public Command ObterRootRaiz { private set; get; }
        public PeriodoPage(Funcionalidade _func)
        {
            InitializeComponent();
          
            BindingContext = new RootViewModel(_func.Nome);
            this.func = _func;

            FlowListView.Init();
            ObterRootRaiz = new Command<string>(
          async (string periodo) =>
          {
           if (periodo != null)
            {
                  RootService RootService = new RootService();
                  var response = await RootService.ObterServico(this.func.Nome);
                 
                  var list = (Root)response.Result;
                  List<Dados> listDados = new List<Dados>();
                 if(list != null) { 
                  List<Dados> dadosFiltro = new List<Dados>();
                  foreach (Dados dados in list.dados)
                  {
                      if (dados.periodo == periodo)
                          {
                              decimal total = Convert.ToDecimal(dados.total);
                              dados.total = total.ToString("N2");
                              dadosFiltro.Add(dados);
                          }
                  }
                  await Navigation.PushAsync(new RootPageFinaceiro(dadosFiltro));
                  }
              }
          });

        }
    }
}