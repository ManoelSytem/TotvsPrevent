﻿using System;
using System.ComponentModel;
using Xamarin.Forms;

using TotvsPrevent.Models;
using System.Collections.ObjectModel;
using TotvsPrevent.Services;
using TotvsPrevent.Helpers;
using TotvsPrevent.Views.RM;
using TotvsPrevent.Views.Finaceiro;

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
            _menuLista = ItemService.GetMenuItens("Protheus");
            navigationDrawerList.ItemsSource = _menuLista;
            ImgCicle.Source = ImageSource.FromResource("TotvsPrevent.Resource.perfil_icon.png");
            //if(Settings.Produto == "Protheus")
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(FinaceiraViewPage)));
            //else
            //Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(RmHomePage)));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type pagina = item.TargetType;


            if (item.Title == "Sair")
            {
                Settings.Produto = string.Empty;
                Settings.AccessToken = string.Empty;
                Settings.Produto = string.Empty; 
                Settings.AccessToken = string.Empty;
                Settings.IsRemembered = string.Empty;
                Settings.Username = string.Empty;
                Settings.Password = string.Empty;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }

            else { 
            Detail = new NavigationPage((Page)Activator.CreateInstance(pagina));
            IsPresented = false;
            }
        }
    }
}