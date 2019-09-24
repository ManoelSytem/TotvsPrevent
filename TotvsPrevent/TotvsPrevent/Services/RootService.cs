using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Models;
using Xamarin.Forms;
using TotvsPrevent.Helpers;

namespace TotvsPrevent.Services
{
    public class RootService
    {
        private ApiService apiService;

        private string url;

        private string urlPrefix;

        private string prefixControl;

        private string action;

        private string service;

        private static ObservableCollection<ContaAPaga> ListModulo { get; set; }

        public RootService()
        {
            apiService = new ApiService();
        }

        public async Task<Response> GetAll(string url, string urlPrefix, string prefixControl, string action)
        {
            var response = await apiService.GetList<Root>(url, urlPrefix, prefixControl, action, Settings.IsRemembered != "false" ? Settings.AccessToken : Settings.AccesstokenTemp);
            return response;
        }

        public async Task<Response> ObterServico(string service)
        {

            if (service == "Contas a receber")
            {
                this.url = Application.Current.Resources["UrlAPI"].ToString();
                this.urlPrefix = Application.Current.Resources["UrlPrefix"].ToString();
                this.prefixControl = Application.Current.Resources["UrlPrefixControllerContaReceber"].ToString();
                this.action = "emp=99&fil=01";
            }
            else
            {
                this.url = Application.Current.Resources["UrlAPI"].ToString();
                this.urlPrefix = Application.Current.Resources["UrlPrefix"].ToString();
                this.prefixControl = Application.Current.Resources["UrlPrefixControllerContaApagar"].ToString();
                this.action = "emp=99&fil=01";
            }

            var response = await apiService.GetList<Root>(url, urlPrefix, prefixControl, action, Settings.IsRemembered != "false" ? Settings.AccessToken : Settings.AccesstokenTemp);
            return response;
        }


        public async Task<Response> GetAllUrl(string url)
        {
            var response = await this.apiService.GetList<Root>(url);
            return response;
        }
    }
}
