using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Models;
using TotvsPrevent.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views.Finaceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeriodoPageContaReceber : ContentPage
    {
        public Command ObterRootRaiz { private set; get; }
        public PeriodoPageContaReceber()
        {
            InitializeComponent();
            FlowListView.Init();
            ObterRootRaiz = new Command<string>(
          async (string periodo) =>
          {
              if (periodo != null)
              {
                  ContaApagarService contaApagarService = new ContaApagarService();
                  var response = await contaApagarService.GetAllContaAreceberAll();

                  var list = (Root)response.Result;
                  List<Dados> listDados = new List<Dados>();
                  if (list != null)
                  {
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
                      await Navigation.PushAsync(new ContaPagarPage(dadosFiltro));
                  }
              }
          });

        }
    }
}