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
    public class ContaApagarService
    {
        private ApiService apiService;

        private static ObservableCollection<ContaAPaga> ListModulo { get; set; }

        public ContaApagarService()
        {
            apiService = new ApiService();
        }

        public async Task<Response> GetAll()
        {
           
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var urlPrefix = Application.Current.Resources["UrlPrefix"].ToString();
            var prefixControl = Application.Current.Resources["UrlPrefixController"].ToString();
            var action = Application.Current.Resources["UrlContaApagarAction"].ToString();


            var response = await this.apiService.GetList<ContaAPaga>(url, urlPrefix, prefixControl, action, Settings.IsRemembered != "false" ? Settings.AccessToken : Settings.AccesstokenTemp);
           

            return response;
        }
    }
}
