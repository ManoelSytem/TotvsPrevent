using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace TotvsPrevent.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public string Username { get; set; }

        public string Password { get; set; }

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

        public LoginViewModel()
        {
            Username = "Totvs";
            Password = "123456";
            Icon = ImageSource.FromResource("TotvsPrevent.Resource.logo.png");
        }
    }
}

