using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views.Finaceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhePage : ContentPage
    {
       
        public DetalhePage(List<Dados> detalhes, string empresa, string perioado, string titulo)
        {
            InitializeComponent();
            DateTime dia = DateTime.Now;
            CultureInfo idioma = new CultureInfo("pt-BR");
            lblperiodo.Text = perioado;
            this.Title = titulo;
            LisViewDetalheFornecedor.ItemsSource = new ObservableCollection<Dados>(detalhes);
        }
    }
}