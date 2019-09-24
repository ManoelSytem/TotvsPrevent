using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TotvsPrevent.Models;

namespace TotvsPrevent.ViewModels
{
    public class DadosViewModel : BaseViewModel
    {
        public string periodo;
        public string Periodo
        {
            get { return this.periodo; }
            set { this.SetValue(ref periodo, value); }
        }

        public string natureza;
        public string Natureza
        {
            get { return this.natureza; }
            set { this.SetValue(ref natureza, value); }
        }
        public string total;

        public string Total
        {
            get { return this.total; }
            set { this.SetValue(ref total, value); }
        }

        public string urlFilhos;
        public string UrlFilhos
        {
            get { return this.urlFilhos; }
            set { this.SetValue(ref urlFilhos, value); }
        }

        public DadosViewModel()
        {
                
        }

    }
}
