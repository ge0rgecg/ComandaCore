using System.Collections.Generic;

namespace Dominio
{
    public class Fechamento
    {
        public int Id { get; set; }

        public double ValorTotal { get; set; }

        public ICollection<ControleComanda> ControleComandas { get; set; }
    }
}
