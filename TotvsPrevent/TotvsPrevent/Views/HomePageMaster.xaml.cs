using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Views.Finaceiro;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageMaster : ContentPage
    {
        public HomePageMaster()
        {
            InitializeComponent();
        }

        async void OnImageButtonFinaceiro(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FinaceiraViewPage());
        }
    }
}