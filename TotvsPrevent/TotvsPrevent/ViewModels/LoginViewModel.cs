using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace TotvsPrevent.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public bool isRunning;

        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
            set
            {
                this.SetValue(ref this.isRunning, value);
            }
        }

        public bool isEnabled;
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                this.SetValue(ref this.isEnabled, value);
            }
        }

        public ImageSource i_con;
        public ImageSource Icon
        {
            get
            {
                return i_con;
            }
            set
            {
                SetValue(ref i_con, value);
            }
        }

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                SetValue(ref _message, value);
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Mensagem", "Usuário e senha não informado", "Ok");
                return;
            }
        }

        public LoginViewModel()
        {
            this.isEnabled = false;
            Username = "Totvs";
            Password = "123456";
            Icon = ImageSource.FromResource("TotvsPrevent.Resource.logo.png");
        }
    }
}

