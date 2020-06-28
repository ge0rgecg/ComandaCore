using Dominio;
using Repositorio.Contexto;
using Repositorio.Interface;

namespace Repositorio.Repositorios
{
    public class ComboItemRepositorio :
        RepositorioBase<ComboItem>, IComboItemRepositorio
    {
        public ComboItemRepositorio(ContextoDb dbContexto) : base(dbContexto) { }
    }
}
