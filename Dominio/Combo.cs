using System.Collections.Generic;

namespace Dominio
{
    public class Combo
    {
        public int Id { get; set; }

        public ICollection<ComboItem> ComboItem { get; set; }

        public ICollection<ComboDesconto> ComboDesconto { get; set; }
    }
}
