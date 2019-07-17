using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TotvsPrevent.Models;
using TotvsPrevent.Services;
using Xamarin.Forms;

namespace TotvsPrevent.ViewModels
{
    public class CaixaViewModel : BaseViewModel
    {
        private WebApiService apiService;

        private ContaApagarService contaApagarService;

        private ObservableCollection<Caixa> caixa;

        public ObservableCollection<Caixa> Caixa
        {
            get { return this.caixa; }
            set { this.SetValue(ref caixa, value); }
        }
        

        public CaixaViewModel()
        {
            //this.apiService = new WebApiService();
            //this.GetAllContaApagar();
            contaApagarService = new ContaApagarService();

            Caixa = new ObservableCollection<Caixa> { };
            Caixa = contaApagarService.GetAll();

        }

        private async void GetAllContaApagar()
        {
            var response = await this.apiService.GetList<Caixa>("https://localhost:5001/", "/api", "/Finaceiro");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", response.Message, "ok"); ;
                return;
            }

            var list = (List<Caixa>)response.Result;
            this.caixa = new ObservableCollection<Caixa>(list);
        }
    }
}
