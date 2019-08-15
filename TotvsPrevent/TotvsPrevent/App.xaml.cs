using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TotvsPrevent.Services;
using TotvsPrevent.Views;
using TotvsPrevent.Helpers;
using TotvsPrevent.Views.Finaceiro;

namespace TotvsPrevent
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
         
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
