using Dominio;
using Repositorio.Contexto;
using Repositorio.Interface;

namespace Repositorio.Repositorios
{
    public class ComboRepositorio :
        RepositorioBase<Combo>, IComboRepositorio
    {
        public ComboRepositorio(ContextoDb dbContexto) : base(dbContexto) { }
    }
}
