using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Models;
using TotvsPrevent.ViewModels;
using TotvsPrevent.Views.Fluig;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views.Finaceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContaPagarPage : ContentPage
    {
        public ContaAPaga cax;
        public ContaPagarPage()
        {
            InitializeComponent();
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as ContaApagarViewModel;
            cax = e.Item as ContaAPaga;
        }

        private async void Selected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ColigadaViewPage(), true);
        }

    }
}