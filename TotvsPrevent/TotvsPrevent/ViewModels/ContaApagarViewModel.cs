using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TotvsPrevent.Models;
using TotvsPrevent.Services;
using Xamarin.Forms;

namespace TotvsPrevent.ViewModels
{
    public class ContaApagarViewModel : BaseViewModel
    {
        private ApiService apiService;

        private ContaApagarService contaApagarService;

        private ObservableCollection<ContaAPaga> contaApagar;

        public ObservableCollection<ContaAPaga> ContaApagar
        {
            get { return this.contaApagar; }
            set { this.SetValue(ref contaApagar, value); }
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
            var response = await this.apiService.GetList<ContaAPaga>("https://localhost:5001/", "/api", "/Finaceiro", "/GetTotalCaixa");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", response.Message, "ok"); ;
                return;
            }
            var list = (List<ContaAPaga>)response.Result;
            this.contaApagar = new ObservableCollection<ContaAPaga>(list);
        }
    }
}
