using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Models;
using TotvsPrevent.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views.Configurador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigEmpresa : ContentPage
    {
        public ConfigEmpresa()
        {
            InitializeComponent();

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var urlPrefix = Application.Current.Resources["UrlPrefix"].ToString();
            var prefixControl = Application.Current.Resources["UrlPrefixControllerContaApagar"].ToString();
            var action = "emp=99&fil=01";

            UrlApiEntry.Text = url + urlPrefix + prefixControl + action;
        }

        private async void ObterJsonAsync(object sender, EventArgs e)
        {
            ContaApagarService contaApagarService = new ContaApagarService();
            ApiService apiService = new ApiService();


            resultText.Text = "Carregando dados...";

            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Mensagem", connection.Message, "Ok");
                return;
            }

            Response response = new Response();

            response = await contaApagarService.GetAllUrl(UrlApiEntry.Text);

           
            if (response.IsSuccess)
            {
                resultText.Text =  response.Result.ToString();
            }
            else
            {
                resultText.Text = response.Message.ToString();
            }
        }
    }
}