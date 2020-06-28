using Dominio;
using Repositorio.Contexto;
using Repositorio.Interface;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IEnumerable<ControleComanda> GetAllByNumeroComanda(int numeroComanda)
        {
            return this._dbContexto.ControleComanda
                .Where(w => w.NumeroComanda == numeroComanda)
                .Select(e => new ControleComanda
                { 
                    Id = e.Id, 
                    Fechamento_Id = e.Fechamento_Id,
                    Produto_Id = e.Produto_Id,
                    Produto = e.Produto})
                .ToList();
        }
    }
}
