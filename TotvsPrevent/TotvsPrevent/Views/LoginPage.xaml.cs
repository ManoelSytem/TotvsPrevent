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
            Init();
        }

        private void Init()
        {

            ActivitySpinner.IsVisible = false;
            //Button_Entrar.Visibility = ViewStates.Gone;
            Entry_Login.Completed += (s, e) => Entry_Senha.Focus();
            Entry_Senha.Completed += (s, e) => EntrarProcedure(s, e);

        }


        private async void EntrarProcedure(object sender, EventArgs e)
        {
            try
            {
                var accesstoken = await ApiServices.LoginAsync(Entry_Login.Text, Entry_Senha.Text);
                if (!string.IsNullOrEmpty(accesstoken))
                {
                    await Navigation.PushModalAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Menssagem", "O nome do usuário ou senha está incorreto", "OK");
                    await Navigation.PushModalAsync(new MainPage());
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Menssagem", "Erro Exception", "OK");
                await Navigation.PushModalAsync(new MainPage());
            }
        }
    }
}

