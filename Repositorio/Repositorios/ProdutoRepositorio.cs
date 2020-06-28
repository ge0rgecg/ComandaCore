using Dominio;
using Repositorio.Contexto;
using Repositorio.Interface;

namespace Repositorio.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(ContextoDb dbContexto) : base(dbContexto) { }
    }
}
