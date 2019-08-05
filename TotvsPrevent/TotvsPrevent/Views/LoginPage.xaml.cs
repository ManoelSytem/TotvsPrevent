using Android.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Models;
using TotvsPrevent.Services;
using TotvsPrevent.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Provider.ContactsContract;
using static Android.Provider.SyncStateContract;

namespace TotvsPrevent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel objeto;
        public LoginPage()
        {
            InitializeComponent();
            logoLogin.Source = ImageSource.FromResource("TotvsPrevent.Resource.logo.png");
            Init();
        }

        private void Init()
        {
            Picker.ItemsSource = new List<Produto>()
            {
                new Produto { Id=1,Nome="RM"},
                new Produto { Id=2, Nome = "Protheus" }
            };
            //Button_Entrar.Visibility = ViewStates.Gone;
            Entry_Login.Completed += (s, e) => Entry_Senha.Focus();
            Entry_Senha.Completed += (s, e) => EntrarProcedure(s, e);
        }


        private async void EntrarProcedure(object sender, EventArgs e)
        {
            try
            {
                  
                   string accesstoken = "";
                //var accesstoken = await _apiService.LoginAsync(Entry_Login.Text, Entry_Senha.Text);
                if (!string.IsNullOrEmpty(accesstoken))
                {
                    
                    await Navigation.PushModalAsync(new MainPage());
                }
                else
                { 
                    await Navigation.PushModalAsync(new MainPage());
                }
            }
            catch (Exception)
            {
                   await Navigation.PushModalAsync(new MainPage());
            }
        }

        private async void Picker_OnSelectIndexCanger(object sender, EventArgs e)
        {
            var proSelect = (Produto)Picker.SelectedItem;
           
        }
    }
}

