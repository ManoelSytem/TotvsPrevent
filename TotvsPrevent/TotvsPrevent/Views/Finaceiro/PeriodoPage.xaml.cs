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
        private RootService rootService;
        public Funcionalidade func;
        public Command ObterRootRaiz { private set; get; }
        public PeriodoPage(Funcionalidade _func)
        {
           
            InitializeComponent();
            BindingContext = new RootViewModel(_func.Nome);
            this.func = _func;

            try
            {

                FlowListView.Init();
                ObterRootRaiz = new Command<string>(
              async (string urlFilhos) =>
              {
                  if (urlFilhos != null)
                  {
                      RootService rootService = new RootService();
                      var response = await rootService.GetAllUrl(urlFilhos);

                      var list = (Root)response.Result;
                      List<Dados> listDados = new List<Dados>();
                      if (list != null)
                      {
                          string natureza = "";
                          string periodo = "";
                          bool UrlFilho = false;
                          List<Dados> dadosFiltro = new List<Dados>();
                          foreach (Dados dado in list.dados)
                          {
                              decimal total = Convert.ToDecimal(dado.total);
                              dado.total = total.ToString("N2");
                              periodo = dado.periodo;
                              dadosFiltro.Add(dado);
                              dadosFiltro.Add(dado);
                          }
                          await Navigation.PushAsync(new Teste(dadosFiltro, natureza, periodo));
                      }
                  }
              });
            }
            catch (Exception e)
            {

                throw;
            }


        }

    }
}