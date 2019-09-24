using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TotvsPrevent.Models;
using TotvsPrevent.Services;
using TotvsPrevent.ViewModels;
using TotvsPrevent.Views.Fluig;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views.Finaceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPageFinaceiro : ContentPage
    {
        private RootService rootService;
        public Command NavigateCommand { private set; get; }
        public RootPageFinaceiro(List<Dados> dados)
        {
            InitializeComponent();
            ListViewContaApagar.ItemsSource = dados;
        }

        private async void Selected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ColigadaViewPage(), true);
        }

        private void ObterDetalheRoot(object sender, EventArgs e)
        {
            var vm = BindingContext as DadosViewModel;
        }

        private async void DetalheNivel(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Dados;
            try
            {
                   if (item == null)
            {

                return;
            }
            else
            {
                rootService = new RootService();
                var response = await rootService.GetAllUrl(item.urlFilhos);
              
                 var list = (Root)response.Result;
                List<Dados> listDados = new List<Dados>();
                if (list != null)
                {
                    string natureza = "";
                    List<Dados> dadosFiltro = new List<Dados>();
                    foreach (Dados dado in list.dados)
                    {
                        decimal total = Convert.ToDecimal(dado.total);
                        dado.total = total.ToString("N2");
                        natureza = dado.natureza;
                        dadosFiltro.Add(dado);

                    }

                    await Navigation.PushAsync(new Teste(dadosFiltro, natureza));
                     ((ListView)sender).SelectedItem = null;
                }
            }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}