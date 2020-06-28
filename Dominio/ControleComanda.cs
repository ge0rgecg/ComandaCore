using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class ControleComanda
    {
        public int Id { get; set; }

        public int NumeroComanda { get; set; }

        public int Produto_Id { get; set; }

        public int? Fechamento_Id { get; set; }

        public Produto Produto { get; set; }

        public Fechamento Fechamento { get; set; }
    }
}
