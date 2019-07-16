﻿using System.Collections.ObjectModel;
using TotvsPrevent.Models;
using TotvsPrevent.Views;
using Xamarin.Forms;

namespace TotvsPrevent.Services
{
    public class ItemService
    {
        private static ObservableCollection<MasterPageItem> menuLista { get; set; }


        public static ObservableCollection<MasterPageItem> GetMenuItens()
        {
            menuLista = new ObservableCollection<MasterPageItem>();
            // Criando as paginas para navegação
            // Definimos o titulo para o item
            // o icone do lado esquerdo e a pagina que vamos abrir
            var HomeView = new MasterPageItem() { Title = "Início", Icon = ImageSource.FromResource("TotvsPrevent.Resource.home_icon.png"), TargetType = typeof(HomePage) };
            var HomeRM = new MasterPageItem() { Title = "RM", Icon = ImageSource.FromResource("TotvsPrevent.Resource.logo.png"), TargetType = typeof(HomePage) };
            var HomeProthues = new MasterPageItem() { Title = "Prothues", Icon = ImageSource.FromResource("TotvsPrevent.Resource.logo.png"), TargetType = typeof(HomePage) };
            menuLista.Add(HomeView);
            menuLista.Add(HomeRM);
            menuLista.Add(HomeProthues);
            return menuLista;
        }
    }
}
