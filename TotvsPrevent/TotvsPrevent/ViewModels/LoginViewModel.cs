using GalaSoft.MvvmLight.Command;
using System.Net.Http;
using System.Windows.Input;
using TotvsPrevent.Models;
using TotvsPrevent.Services;
using TotvsPrevent.Views;
using Xamarin.Forms;
using TotvsPrevent.Helpers;
using TotvsPrevent.Views.RM;
using Newtonsoft.Json;

namespace TotvsPrevent.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ApiService apiService;
        public string Username { get; set; }

        public string Password { get; set; }

        public string produto { get; set; }




        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.IsEnabled = true;
        }

        public LoginViewModel(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.produto = Settings.Produto;
            this.apiService = new ApiService();
            this.IsEnabled = true;
        }

        public bool isRunning;

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { this.SetValue(ref this.isRunning, value); }
        }


        public bool isRemembered;

        public bool IsRemembered
        {
            get { return this.isRemembered; }
            set { this.SetValue(ref this.isRemembered, value); }
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

            var url = Application.Current.Resources["UrlAPIAutentication"].ToString();

            result = await this.apiService.GetToken(url, this.Username, this.Password);

            var resultObjeto = result.Content.ReadAsStringAsync().Result;

            Cliente cliente = JsonConvert.DeserializeObject<Cliente>(resultObjeto);

            if (!result.IsSuccessStatusCode || string.IsNullOrEmpty(cliente.token))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Mensagem", "Credênciais não corresponde! Atenção para realizar login conecte a rede TOTVSBA.", "Ok");
                return;
            }
            else
            {
                if (this.IsRemembered == true)
                {
                    Settings.Produto = produtoSelect.Nome;
                    Settings.AccessToken = cliente.token;
                    Settings.IsRemembered = "true";
                    Settings.Username = this.Username;
                    Settings.Password = this.Password;
                }
                else
                {
                    Settings.IsRemembered = "false";
                    Settings.Produto = produtoSelect.Nome;
                    Settings.AccesstokenTemp = cliente.token;
                }

                if (produtoSelect.Nome == "Protheus")
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;
                    Application.Current.MainPage = new MainPage();

                }
                else if (produtoSelect.Nome == "RM")
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;
                    Application.Current.MainPage = new MainPage();
                }
            }
        }

    }
}

