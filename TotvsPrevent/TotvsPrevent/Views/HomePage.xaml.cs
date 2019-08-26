using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Models;
using TotvsPrevent.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private Modulo md;
        public HomePage()
        {
            InitializeComponent();
           

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var vm = BindingContext as ModuloViewModel;
            md = e.Item as Modulo;
        }

        private async void ModuloSelected(object sender, SelectedItemChangedEventArgs e)
        {

            
            var item = (Modulo)e.SelectedItem;
            Type pagina = item.TargetType;

            if (pagina == null)
            {
               
                return ;
            }
            else
            {
                await Navigation.PushAsync((Page)Activator.CreateInstance(pagina),true);
            }
           
        }
    }
}