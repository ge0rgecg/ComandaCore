using Dominio;
using System.Threading.Tasks;

namespace Repositorio.Interface
{
    public interface IControleComandaRepositorio : IRepositorioBase<ControleComanda>
    {
        Task Resetar(int numeroComanda);
    }
}
