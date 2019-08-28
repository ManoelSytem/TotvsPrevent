using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.ViewModels.Finaceiro.ContaApagarDetalhe;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views.Finaceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Teste : ContentPage
    {
        public Teste(IEnumerable<DetalheContaAPagarViewModel> detalhes)
        {
            InitializeComponent();
            LisViewDetalheFornecedor.ItemsSource = new ObservableCollection<DetalheContaAPagarViewModel>(detalhes);
        }
    }
    
}

