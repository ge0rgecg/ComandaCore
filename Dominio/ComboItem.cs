namespace Dominio
{
    public class ComboItem
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public int Produto_Id { get; set; }

        public int Combo_Id { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Combo Fechamento { get; set; }
    }
}
