﻿using Xamarin.Forms;
using TotvsPrevent.Services;
using TotvsPrevent.Views;
using TotvsPrevent.Helpers;
using System.Net.Http;
using TotvsPrevent.Models;
using Newtonsoft.Json;
using TotvsPrevent.Views.Finaceiro;

namespace TotvsPrevent
{
    public partial class App : Application
    {
        private ApiService apiService;
        public App()
        {
            InitializeComponent();
            //if (Settings.IsRemembered == "true" && Settings.Username != string.Empty && Settings.Password != string.Empty && Settings.Produto != string.Empty)
            //{
            //    Validation(Settings.IsRemembered, Settings.Username, Settings.Password, Settings.Produto);
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new LoginPage());
            //}
            MainPage = new NavigationPage(new LoginPage());
           // MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
           

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public async void Validation(string isRemembered, string username, string password, string produto)
        {

            apiService = new ApiService();
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                MainPage = new NavigationPage(new LoginPage());
                return;
            }

           

            var url = Application.Current.Resources["UrlAPIAutentication"].ToString();

            var result = await this.apiService.GetToken(url, username, password);

            var resultObjeto = result.Content.ReadAsStringAsync().Result;

            Cliente cliente = JsonConvert.DeserializeObject<Cliente>(resultObjeto);

            if (!result.IsSuccessStatusCode || string.IsNullOrEmpty(cliente.token))
            {
                
                await Application.Current.MainPage.DisplayAlert("Mensagem", "Credênciais salvas não corresponde! Atenção para realizar login conecte a rede TOTVSBA.", "Ok");
                MainPage = new NavigationPage(new LoginPage());
                return;
            }
            else
            {
                if (produto == "Protheus")
                {
                    Settings.AccesstokenTemp = cliente.token;
                    Application.Current.MainPage = new MainPage();

                }
                else if (produto == "RM")
                {
                    Settings.AccesstokenTemp = cliente.token;
                    Application.Current.MainPage = new MainPage();
                }
            }
        }
    }
}
