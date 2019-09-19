using System.Collections.ObjectModel;
using TotvsPrevent.Models;
using TotvsPrevent.Views;
using TotvsPrevent.Views.Configurador;
using TotvsPrevent.Views.RM;
using Xamarin.Forms;

namespace TotvsPrevent.Services
{
    public class ItemService
    {
        private static ObservableCollection<MasterPageItem> menuLista { get; set; }


        public static ObservableCollection<MasterPageItem> GetMenuItens(string produto)
        {
            menuLista = new ObservableCollection<MasterPageItem>();
            // Criando as paginas para navegação
            // Definimos o titulo para o item
            // o icone do lado esquerdo e a pagina que vamos abrir
            if (produto == "Protheus")
            {
                var HomeView = new MasterPageItem() { Title = "Início", Icon = ImageSource.FromResource("TotvsPrevent.Resource.home_icon.png"), TargetType = typeof(HomePageMaster) };
                var HomeProthues = new MasterPageItem() { Title = "Serviços", Icon = ImageSource.FromResource("TotvsPrevent.Resource.logo.png"), TargetType = typeof(HomePageMaster) };
                var Configuracao = new MasterPageItem() { Title = "Configuração", Icon = ImageSource.FromResource("TotvsPrevent.Resource.logo.png"), TargetType = typeof(ConfigEmpresa) };
                var Logaout = new MasterPageItem() { Title = "Sair", Icon = ImageSource.FromResource("TotvsPrevent.Resource.logo.png"), TargetType = typeof(LoginPage) };

                menuLista.Add(HomeView);
                menuLista.Add(HomeProthues);
                menuLista.Add(Configuracao);
                menuLista.Add(Logaout);

            }
            else if (produto == "RM")
            {

                var HomeView = new MasterPageItem() { Title = "Início", Icon = ImageSource.FromResource("TotvsPrevent.Resource.home_icon.png"), TargetType = typeof(HomePageMaster) };
                var HomeRM = new MasterPageItem() { Title = "Serviços", Icon = ImageSource.FromResource("TotvsPrevent.Resource.logo.png"), TargetType = typeof(HomePageMaster) };
                var Logaout = new MasterPageItem() { Title = "Sair", Icon = ImageSource.FromResource("TotvsPrevent.Resource.logo.png"), TargetType = typeof(LoginPage) };
                //var Configuracao = new MasterPageItem() { Title = "Configuração", Icon = ImageSource.FromResource("TotvsPrevent.Resource.logo.png"), TargetType = typeof(ConfigEmpresa) };

                menuLista.Add(HomeView);
                menuLista.Add(HomeRM);
                //menuLista.Add(Configuracao);
                menuLista.Add(Logaout);

            }



            return menuLista;
        }
    }
}
