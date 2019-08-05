using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TotvsPrevent.Models;
using TotvsPrevent.Services;
using Xamarin.Forms;


namespace TotvsPrevent.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ApiService apiService;
        public string Username { get; set; }

        public string Password { get; set; }

        public string produto { get; set; }

        public bool isRunning;


        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.IsEnabled = true;
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set  {  this.SetValue(ref this.isRunning, value);  }
        }

        public bool isEnabled;
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }

        public ImageSource i_con;
        public ImageSource Icon
        {
            get { return this.i_con; }
            set { this.SetValue(ref this.i_con, value); }
         
        }

        private string _message;
        public string Message
        {
            get { return this._message; }
            set { this.SetValue(ref this._message, value); }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand<object>((produto) => Login(produto));
            }
        }

        private async void Login(object produto)
        {
            var produtoSelect = (Produto)produto;

            
                if (string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Password))
                {
                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Usuário e senha não informado.", "Ok");
                    return;
                }

                if (produtoSelect == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Por gentileza selecione a linha do produto.", "Ok");
                    return;
                }


                this.IsEnabled = false;
                this.IsRunning = true;

                var connection = await this.apiService.CheckConnection();
                if (!connection.IsSuccess)
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;
                    await Application.Current.MainPage.DisplayAlert("Mensagem", connection.Message, "Ok");
                    return;
                }

                HttpResponseMessage result = new HttpResponseMessage();
                var url = "http://10.120.8.16:2504/users/authenticate";
                result = await this.apiService.GetToken(url, this.Username, this.Password);

                var objeto = result.Content.ReadAsStringAsync();

                if (!result.IsSuccessStatusCode)
                {
                    this.IsRunning = false;
                    this.isEnabled = true;
                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Credênciais não corresponde! Atenção para realizar login conecte a rede TOTVSBA.", "Ok");
                    return;
                }

            return;
        }

        
    }
}

