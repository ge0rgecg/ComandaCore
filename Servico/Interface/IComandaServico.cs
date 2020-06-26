using Dominio;
using System;

namespace Servico.Interface
{
    public interface IComandaServico
    {
        Retorno<bool> AdicionarProduto(ControleComanda controleComanda);

        Retorno<Fechamento> FecharComanda(int idComanda);

        Retorno<bool> Resetar(int idComanda);
    }
}
