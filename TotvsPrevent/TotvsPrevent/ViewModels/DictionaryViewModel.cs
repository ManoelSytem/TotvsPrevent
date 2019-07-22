using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TotvsPrevent.ViewModels
{
    public class DictionaryViewModel<T> : BaseViewModel
    {

        private ObservableCollection<T> objeto;

        public ObservableCollection<T> Objeto
        {
            get { return this.objeto; }
            set { this.SetValue(ref objeto, value); }
        }

        public DictionaryViewModel()
        {
            //this.apiService = new WebApiService();
            //this.GetAllContaApagar();
            objeto = new ObservableCollection<T>();
        }
    }
}