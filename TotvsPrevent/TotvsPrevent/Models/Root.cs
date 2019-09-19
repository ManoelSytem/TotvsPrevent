using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TotvsPrevent.Models
{
    public class Root 
    {
        public string titulo { get; set; }
        public bool raiz { get; set; }
        public List<Dados> dados { get; set; }
        public Fitros fitros { get; set; }
        public List<Totalizadores> totalizadores { get; set; }

    }

    public class Dados
    {
        public string id { get; set; }
        public string periodo { get; set; }
        public string total { get; set; }
        public bool possuiFilhos  { get; set; }
        public string urlFilhos { get; set; }
        public string natureza { get; set; }
        public string natcod { get; set; }
        public string fornecedor { get; set; }
        public string forncod { get; set; }
        public string parcela { get; set; }
        public string titulo { get; set; }
        public string vencimento { get; set; }
        public string fornloja { get; set; }
        public string prefixo { get; set; }


    }

    public class Fitros
    {
        public string campo { get; set; }
        public  List<string> valores { get; set; }
    }

    public class Totalizadores
    {
        public string campo { get; set; }
        public bool sum { get; set; }
        public bool min { get; set; }
        public bool max { get; set; }
        public bool avg { get; set; }
        public bool count { get; set; }
    }


}