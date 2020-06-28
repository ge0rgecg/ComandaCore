using Dominio;
using Repositorio.Contexto;
using Repositorio.Interface;

namespace Repositorio.Repositorios
{
    public class LimiteProdutoRepositorio :
        RepositorioBase<LimiteProduto>, ILimiteProdutoRepositorio
    {
        public LimiteProdutoRepositorio(ContextoDb dbContexto) : base(dbContexto) { }
    }
}
