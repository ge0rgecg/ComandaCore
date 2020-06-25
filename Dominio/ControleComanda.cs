using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class ControleComanda
    {
        public int Id { get; set; }

        public Produto Produto { get; set; }

        public Fechamento Fechamento { get; set; }
    }
}
