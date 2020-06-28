using Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositorio.Interface
{
    public interface IControleComandaRepositorio : IRepositorioBase<ControleComanda>
    {
        Task Resetar(int numeroComanda);
        IEnumerable<ControleComanda> GetAllByNumeroComanda(int numeroComanda);
        Task AssinarFechamento(IEnumerable<ControleComanda> controleComandas);
    }
}
