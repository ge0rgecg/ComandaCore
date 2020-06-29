using Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servico.Interface
{
    public interface IComandaServico
    {
        Task<Retorno<IEnumerable<Produto>>> ObterProdutos();

        Task<Retorno<SemConteudo>> AdicionarProduto(ControleComanda controleComanda);

        Task<Retorno<Fechamento>> FecharComanda(int idComanda);

        Task<Retorno<SemConteudo>> Resetar(int idComanda);
    }
}
