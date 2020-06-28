using Dominio;
using Repositorio.Contexto;
using Repositorio.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class ControleComandaRepositorio : RepositorioBase<ControleComanda>, IControleComandaRepositorio
    {
        public ControleComandaRepositorio(ContextoDb dbContexto) : base(dbContexto) { }

        public async Task Resetar(int numeroComanda)
        {
            var listaComanda = this.GetAll().Where(w => w.NumeroComanda == numeroComanda && w.Fechamento_Id == null);

            _dbContexto.RemoveRange(listaComanda);
            await _dbContexto.SaveChangesAsync();
        }
    }
}
