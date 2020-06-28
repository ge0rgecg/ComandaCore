using Dominio;
using System;

namespace Servico.Interface
{
    public interface IComandaServico
    {
        Retorno<SemConteudo> AdicionarProduto(ControleComanda controleComanda);

        Retorno<Fechamento> FecharComanda(int idComanda);

        Retorno<SemConteudo> Resetar(int idComanda);
    }
}
