using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TotvsPrevent.Models;
using TotvsPrevent.ViewModels;
using TotvsPrevent.ViewModels.Finaceiro.ContaApagarDetalhe;
using TotvsPrevent.Views.Fluig;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views.Finaceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContaPagarPage : ContentPage
    {
        public ICommand NavigateCommand { private set; get; }
        public ContaAPaga cax;
        public ContaPagarPage(List<Dados> dados)
        {
            InitializeComponent();
            NavigateCommand = new Command<ContaAPaga>(
           async (ContaAPaga contaAPaga) =>
           {

               if (contaAPaga != null) { 
                   List<DetalheContaAPagarViewModel> list = new List<DetalheContaAPagarViewModel>();
               DetalheContaAPagarViewModel novo;

               foreach (ContaApagarEmpresa cont in contaAPaga.ContaApagarEmpresa)
               {
                  
                   novo = new DetalheContaAPagarViewModel();
                   novo.Servico = cont.Servico;
                   novo.Valor = cont.Valor;
                   novo.Dapartamento = cont.Dapartamento;
                   list.Add(novo);
               }

               await Navigation.PushAsync(new Teste(list, contaAPaga.Empresa));
               }
           });
            ListViewContaApagar.ItemsSource = dados;
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as ContaApagarViewModel;
            cax = e.Item as ContaAPaga;
        }

        private async void Selected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ColigadaViewPage(), true);
        }

        private async void ObterDetalheRoot(object sender, EventArgs e)
        {
            List<ContaApagarEmpresa> listaContaApagarEmpresa = new List<ContaApagarEmpresa>();
            listaContaApagarEmpresa.Add(new ContaApagarEmpresa { Servico = "Fornecedor A", Valor = "R$ 5.656,00", Dapartamento = "03/09/2019" });
            listaContaApagarEmpresa.Add(new ContaApagarEmpresa { Servico = "Fornecedor B", Valor = "R$ 10.000,00", Dapartamento = "03/09/2019" });
            listaContaApagarEmpresa.Add(new ContaApagarEmpresa { Servico = "Fornecedor C", Valor = "R$ 5.000,00", Dapartamento = "03/09/2019" });
            listaContaApagarEmpresa.Add(new ContaApagarEmpresa { Servico = "Fornecedor D", Valor = "R$ 5.000,00", Dapartamento = "03/09/2019" });
            listaContaApagarEmpresa.Add(new ContaApagarEmpresa { Servico = "Fornecedor E", Valor = "R$ 5.000,00", Dapartamento = "03/09/2019" });

            List<DetalheContaAPagarViewModel> list = new List<DetalheContaAPagarViewModel>();
            DetalheContaAPagarViewModel novo;

            foreach (ContaApagarEmpresa cont in listaContaApagarEmpresa)
            {

                novo = new DetalheContaAPagarViewModel();
                novo.Servico = cont.Servico;
                novo.Valor = cont.Valor;
                novo.Dapartamento = cont.Dapartamento;
                list.Add(novo);
            }

            await Navigation.PushAsync(new Teste(list, "Test"));
        }
    }
}