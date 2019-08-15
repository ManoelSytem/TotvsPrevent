using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TotvsPrevent.Models;
using TotvsPrevent.Services;
using Xamarin.Forms;
using TotvsPrevent.Helpers;

namespace TotvsPrevent.ViewModels
{
    public class ContaApagarViewModel : BaseViewModel
    {
        private ApiService apiService;

        private bool isRefreshing;

        private ContaApagarService contaApagarService;

        private ObservableCollection<ContaAPaga> contaApagar;

        public ObservableCollection<ContaAPaga> ContaApagar
        {
            get { return this.contaApagar; }
            set { this.SetValue(ref contaApagar, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }
        public ContaApagarViewModel()
        {
            //this.apiService = new WebApiService();
            //this.GetAllContaApagar();

            contaApagarService = new ContaApagarService();

            ContaApagar = new ObservableCollection<ContaAPaga>
            {
            };
            ContaApagar = contaApagarService.GetAll();
            //this.apiService  = new ApiService();
            //this.GetAllContaApagar();
        }

        private async void GetAllContaApagar()
        {
            ////var response = await this.apiService.GetList<ContaAPaga>("https://localhost:5001/", "/api", "/Finaceiro", "/GetTotalCaixa");
            //if (!response.IsSuccess)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Erro", response.Message, "ok"); ;
            //    return;
            //}
            //var list = (List<ContaAPaga>)response.Result;
            //this.contaApagar = new ObservableCollection<ContaAPaga>(list);
        }


        private async void LoadProducts()
        {
            this.IsRefreshing = true;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Mensagem", connection.Message, "Ok");
                return;
            }

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlProductsController"].ToString();

            var response = await this.apiService.GetList<ContaAPaga>(url, prefix, controller, "GetProduto", Settings.AccessToken,"");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Mensagem", connection.Message, "Ok");
                return;
            }

            var list = (List<ContaAPaga>)response.Result;
            this.ContaApagar = new ObservableCollection<ContaAPaga>(list);
            this.IsRefreshing = false;
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadProducts);
            }
        }
    }
}
