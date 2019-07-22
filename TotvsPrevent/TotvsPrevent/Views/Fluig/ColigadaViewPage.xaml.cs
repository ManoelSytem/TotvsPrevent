using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotvsPrevent.Views.Fluig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColigadaViewPage : ContentPage
    {
        public ColigadaViewPage()
        {
            ServiceFluig serviceFluig = new ServiceFluig();
            InitializeComponent();
            //ListViewColigada.ItemsSource = serviceFluig.GetColleagues().Result.ToList();
        }
    }
}