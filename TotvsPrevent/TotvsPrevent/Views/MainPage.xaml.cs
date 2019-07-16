using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TotvsPrevent.Models;
using System.Collections.ObjectModel;
using TotvsPrevent.Services;

namespace TotvsPrevent.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        private ObservableCollection<MasterPageItem> _menuLista;
        public MainPage()
        {
            InitializeComponent();
            ImgbackMenu.Source = ImageSource.FromResource("TotvsPrevent.Resource.backMenu.png");
            _menuLista = ItemService.GetMenuItens();
            navigationDrawerList.ItemsSource = _menuLista;
            ImgCicle.Source = ImageSource.FromResource("TotvsPrevent.Resource.perfil_icon.png");
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            //obtem o tipo de objeto 
            Type pagina = item.TargetType;

            //abre a pagina correspondente ao item selecionado
            //Cria uma instância do tipo especificado usando o construtor
            //que melhor se adequa ao parametro informado
            Detail = new NavigationPage((Page)Activator.CreateInstance(pagina));
            IsPresented = false;
        }
    }
}