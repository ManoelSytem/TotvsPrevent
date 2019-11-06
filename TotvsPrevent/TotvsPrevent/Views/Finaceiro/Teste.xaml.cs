using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TotvsPrevent.Models;
using TotvsPrevent.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TotvsPrevent.Helpers;
namespace TotvsPrevent.Views.Finaceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Teste : ContentPage
    {

        public ICommand NavigateCommand { private set; get; }
        public Teste(List<Dados> detalhes, string empresa, string perioado)
        {
           InitializeComponent();
           DateTime dia = DateTime.Now;
           CultureInfo idioma = new CultureInfo("pt-BR");
           labelEmpresa.Text = "Natureza";
           lblperiodo.Text = perioado;
          
          LisViewDetalheFornecedor.ItemsSource = new ObservableCollection<Dados>(detalhes);
        }

        private  async void SelectItemDetalhe(object sender, ItemTappedEventArgs e)
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
                    RootService rootService = new RootService();
                    var response = await rootService.GetAllUrl(item.urlFilhos);

                    var list = (Root)response.Result;
                    this.Title = list.titulo;
                   List <Dados> listDados = new List<Dados>();
                    if (list != null)
                    {
                        string fornecedor = "";
                        string empresa = "";
                        string periodo = "";
                        string prefixo = "";
                        List<Dados> dadosFiltro = new List<Dados>();
                        foreach (Dados dado in list.dados)
                        {
                            decimal total = Convert.ToDecimal(dado.total);
                            dado.total = total.ToString("N2");
                            fornecedor = dado.fornecedor;
                            empresa = dado.natureza;
                            periodo = dado.id;
                            prefixo = dado.prefixo;
                            dadosFiltro.Add(dado);
                        }
                       
                        if (prefixo == null)
                        {
                              await Navigation.PushAsync(new Teste(dadosFiltro, empresa, periodo));
                        }
                        else
                        {
                            await Navigation.PushAsync(new DetalhePage(dadosFiltro, fornecedor, periodo,this.Title));
                        }

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

