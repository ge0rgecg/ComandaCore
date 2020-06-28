using Dominio;
using Repositorio.Contexto;
using Repositorio.Interface;

namespace Repositorio.Repositorios
{
    public class ComboDescontoRepositorio :
        RepositorioBase<ComboDesconto>, IComboDescontoRepositorio
    {
        public ComboDescontoRepositorio(ContextoDb dbContexto) : base(dbContexto) { }
    }
}
