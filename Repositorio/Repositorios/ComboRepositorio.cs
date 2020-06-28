using Dominio;
using Repositorio.Contexto;
using Repositorio.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Repositorios
{
    public class ComboRepositorio :
        RepositorioBase<Combo>, IComboRepositorio
    {
        public ComboRepositorio(ContextoDb dbContexto) : base(dbContexto) { }

        public IEnumerable<Combo> GetAllWithChilds()
        {
            return this._dbContexto.Combo
                .Select(e => new Combo
                {
                    Id = e.Id,
                    ComboDesconto = e.ComboDesconto,
                    ComboItem = e.ComboItem
                });
        }
    }
}
