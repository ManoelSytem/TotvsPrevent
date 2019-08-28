using System;
using System.Collections.Generic;
using System.Text;

namespace TotvsPrevent.ViewModels.Finaceiro.ContaApagarDetalhe
{
    public class DetalheContaAPagarViewModel : BaseViewModel
    {
        
        public string dapartamento;
        public string Dapartamento
        {
            get { return this.dapartamento; }
            set { this.SetValue(ref this.dapartamento, value); }
        }

        public string valor;
        public string Valor
        {
            get { return this.valor; }
            set { this.SetValue(ref this.valor, value); }
        }

        public string servico;
        public string Servico
        {
            get { return this.servico; }
            set { this.SetValue(ref this.servico, value); }
        }

    }
}
