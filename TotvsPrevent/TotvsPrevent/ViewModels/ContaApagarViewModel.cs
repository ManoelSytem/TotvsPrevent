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
        private ContaApagarService contaApagarService;

        private ApiService apiService;

        private bool isRefreshing;

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

            var response = await this.contaApagarService.GetAll();
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
                return new RelayCommand(LoadContaApagar);
            }
        }
    }
}
