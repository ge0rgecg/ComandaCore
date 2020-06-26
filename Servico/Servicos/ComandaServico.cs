using Dominio;
using Servico.Interface;
using System;

namespace Servico.Servicos
{
    public class ComandaServico : IComandaServico
    {
        public Retorno<bool> AdicionarProduto(ControleComanda controleComanda)
        {
            throw new NotImplementedException();
        }

        public Retorno<Fechamento> FecharComanda(int idComanda)
        {
            throw new NotImplementedException();
        }

        public Retorno<bool> Resetar(int idComanda)
        {
            throw new NotImplementedException();
        }
    }
}
