using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TotvsPrevent.Models;
using TotvsPrevent.Views.Finaceiro;

namespace TotvsPrevent.Services
{
    public class FuncionalidadeService
    {
        private static ObservableCollection<Funcionalidade> ListFuncionalidade { get; set; }

        public FuncionalidadeService()
        {

        }
        public ObservableCollection<Funcionalidade> GetAll()
        {
            ListFuncionalidade = new ObservableCollection<Funcionalidade>();

            ListFuncionalidade.Add(new Funcionalidade()
            {
                Nome = "Contas a Pagar",
                Descricao = "Gestão",
                Imagem = null,
                Modulo = "F",
                TargetType = typeof(ContaPagarPage)
            });

            ListFuncionalidade.Add(new Funcionalidade()
            {
                Nome = "Juras e multas",
                Descricao = "Gestão",
                Imagem = null,
                Modulo = "F",
                TargetType = typeof(JuraMultaPage)
            });
           

            return ListFuncionalidade;
        }
    }
}
