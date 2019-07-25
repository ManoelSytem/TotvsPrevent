using Android.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Provider.ContactsContract;
using static Android.Provider.SyncStateContract;

namespace TotvsPrevent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            logoLogin.Source = ImageSource.FromResource("TotvsPrevent.Resource.logo.png");
            Init();
        }

        private void Init()
        {
            //Button_Entrar.Visibility = ViewStates.Gone;
            Entry_Login.Completed += (s, e) => Entry_Senha.Focus();
            Entry_Senha.Completed += (s, e) => EntrarProcedure(s, e);
        }


        private async void EntrarProcedure(object sender, EventArgs e)
        {
            try
            {
                ActivitySpinner.IsVisible = true;
                string accesstoken = "";
                //var accesstoken = await _apiService.LoginAsync(Entry_Login.Text, Entry_Senha.Text);
                if (!string.IsNullOrEmpty(accesstoken))
                {
                    ActivitySpinner.IsVisible = false;
                    await Navigation.PushModalAsync(new MainPage());
                }
                else
                {
                    ActivitySpinner.IsVisible = false;
                    await Navigation.PushModalAsync(new MainPage());
                }
            }
            catch (Exception)
            {
                await Navigation.PushModalAsync(new MainPage());
            }
        }
    }
}

