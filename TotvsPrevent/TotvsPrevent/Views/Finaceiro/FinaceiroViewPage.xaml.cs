using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Models;
using TotvsPrevent.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views.Finaceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinaceiraViewPage : ContentPage
    {
        private Funcionalidade func;
        public FinaceiraViewPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as FuncionalidadeViewModel;
            func = e.Item as Funcionalidade;

        }

        private async void FuncionalidadeSelected(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Funcionalidade;
            Type pagina = item.TargetType;

            if (item == null)
            {

                return;
            }
            else
            {
                await Navigation.PushAsync(new PeriodoPage(item));
                ((ListView)sender).SelectedItem = null;
            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}