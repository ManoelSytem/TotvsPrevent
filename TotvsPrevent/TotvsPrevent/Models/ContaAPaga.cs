using System;
using System.Collections.Generic;
using System.Text;

namespace TotvsPrevent.Models
{
   public class ContaAPaga
    {
        public string Empresa  { get; set; }
        public string filial { get; set; }
        public List<string> Total { get; set; }

        public List<ContaApagarEmpresa> ContaApagarEmpresa { get; set; }

    }
}
