﻿namespace Dominio
{
    public class ComboDesconto
    {
        public int Id { get; set; }

        public int Porcentagem { get; set; }

        public int Produto_Id { get; set; }

        public int Combo_Id { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Combo Fechamento { get; set; }
    }
}
