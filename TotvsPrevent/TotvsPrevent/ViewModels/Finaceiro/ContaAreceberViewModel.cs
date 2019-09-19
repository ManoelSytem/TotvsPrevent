using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TotvsPrevent.Models;
using TotvsPrevent.Services;
using Xamarin.Forms;
using TotvsPrevent.Views.Finaceiro;
using TotvsPrevent.ViewModels.Finaceiro.ContaApagarDetalhe;

namespace TotvsPrevent.ViewModels.Finaceiro
{
    public class ContaAreceberViewModel : BaseViewModel
    {
        private ContaApagarService contaApagarService;

        private ApiService apiService;

        private bool isRefreshing;

        private string titulo;
        public string Titulo
        {
            get { return this.titulo; }
            set { this.SetValue(ref titulo, value); }
        }

        private ObservableCollection<string> filtros;

        private ObservableCollection<Dados> dado;

        public ObservableCollection<Dados> Dado
        {
            get { return this.dado; }
            set { this.SetValue(ref dado, value); }
        }

        private List<Dados> dados;

        public List<Dados> Dados
        {
            get { return this.dados; }
            set { this.SetValue(ref dados, value); }
        }
        public ObservableCollection<string> Filtros
        {
            get { return this.filtros; }
            set { this.SetValue(ref filtros, value); }
        }

        private ObservableCollection<Root> contaApagar;

        public ObservableCollection<Root> ContaApagar
        {
            get { return this.contaApagar; }
            set { this.SetValue(ref contaApagar, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }
        public ContaAreceberViewModel()
        {
            contaApagarService = new ContaApagarService();
            apiService = new ApiService();
            LoadContaApagar();
        }


        private async void LoadContaApagar()
        {
            this.IsRefreshing = true;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Mensagem", connection.Message, "Ok");
                return;
            }

            var response = await this.contaApagarService.GetAllContaAreceberAll();

            var list = (Root)response.Result;
            List<Root> ListRoot = new List<Root>();
            ListRoot.Add(list);


            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Mensagem", connection.Message, "Ok");
                return;
            }

            this.ContaApagar = new ObservableCollection<Root>(ListRoot);
            this.Titulo = list.titulo.ToString();
            this.Dados = new List<Dados>(list.dados);

            this.Filtros = new ObservableCollection<string>(list.fitros.valores);
            this.IsRefreshing = false;
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadContaApagar);
            }
        }

        private List<ContaApagarEmpresa> listaContaApagarPorNatureza()
        {

            var listaContaApagarEmpresa = new List<ContaApagarEmpresa>();
            listaContaApagarEmpresa.Add(new ContaApagarEmpresa { Servico = "Fornecedor A", Valor = "R$ 5.656,00", Dapartamento = "03/09/2019" });
            listaContaApagarEmpresa.Add(new ContaApagarEmpresa { Servico = "Fornecedor B", Valor = "R$ 10.000,00", Dapartamento = "03/09/2019" });
            listaContaApagarEmpresa.Add(new ContaApagarEmpresa { Servico = "Fornecedor C", Valor = "R$ 5.000,00", Dapartamento = "03/09/2019" });
            listaContaApagarEmpresa.Add(new ContaApagarEmpresa { Servico = "Fornecedor D", Valor = "R$ 5.000,00", Dapartamento = "03/09/2019" });
            listaContaApagarEmpresa.Add(new ContaApagarEmpresa { Servico = "Fornecedor E", Valor = "R$ 5.000,00", Dapartamento = "03/09/2019" });
            this.IsRefreshing = false;

            return listaContaApagarEmpresa;
        }

        public ICommand ObterRootRaizPorPeriodo
        {
            get
            {
                return new RelayCommand<string>((periodo) => ObterRootRaiz(periodo));
               
            }
        }

        public Command Detalhe
        {
            get
            {
                return new Command<ContaAPaga>((contaAPagar) => DetalheContaApagar(contaAPagar));
            }
        }

        private async void DetalheContaApagar(ContaAPaga contaAPagar)
        {


        }

        private async void ObterRootRaiz(string periodo)
        {
            List<Dados> dadosFiltro = new List<Dados>();

            foreach(Dados dados in this.Dados)
            {
                if(dados.periodo == periodo)
                dadosFiltro.Add(dados);
            }
            this.Dado = new ObservableCollection<Dados>(dadosFiltro);
        }
    }

}
