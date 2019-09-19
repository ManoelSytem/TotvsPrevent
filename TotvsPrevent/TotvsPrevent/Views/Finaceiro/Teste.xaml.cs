using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TotvsPrevent.Models;
using TotvsPrevent.ViewModels.Finaceiro.ContaApagarDetalhe;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views.Finaceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Teste : ContentPage
    {
        public ICommand NavigateCommand { private set; get; }
        public Teste(IEnumerable<DetalheContaAPagarViewModel> detalhes, string empresa)
        {
            InitializeComponent();
            labelEmpresa.Text = empresa;
            LisViewDetalheFornecedor.ItemsSource = new ObservableCollection<DetalheContaAPagarViewModel>(detalhes);
        }


    }
    
}

