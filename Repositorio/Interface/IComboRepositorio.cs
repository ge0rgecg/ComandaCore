using Dominio;
using System.Collections.Generic;

namespace Repositorio.Interface
{
    public interface IComboRepositorio :
        IRepositorioBase<Combo>
    {
        IEnumerable<Combo> GetAllWithChilds();
    }
}
