using Dominio;
using Repositorio.Contexto;
using Repositorio.Interface;

namespace Repositorio.Repositorios
{
    public class FechamentoRepositorio : RepositorioBase<Fechamento>, IFechamentoRepositorio
    {
        public FechamentoRepositorio(ContextoDb dbContexto) : base(dbContexto) { }
    }
}
