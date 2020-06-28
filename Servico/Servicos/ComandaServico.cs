using Dominio;
using Repositorio.Interface;
using Servico.Interface;
using System.Linq;

namespace Servico.Servicos
{
    public class ComandaServico : IComandaServico
    {
        private IProdutoRepositorio _produtoRepositorio { get; set; }
        private IControleComandaRepositorio _controleComandaRepositorio { get; set; }
        private IFechamentoRepositorio _fechamentoRepositorio { get; set; }

        public ComandaServico(IProdutoRepositorio produtoRepositorio,
            IControleComandaRepositorio controleComandaRepositorio,
            IFechamentoRepositorio fechamentoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _controleComandaRepositorio = controleComandaRepositorio;
            _fechamentoRepositorio = fechamentoRepositorio;
        }
        public Retorno<SemConteudo> AdicionarProduto(ControleComanda controleComanda)
        {
            
            if(controleComanda.Produto_Id == 0)
            {
                return new Retorno<SemConteudo>
                {
                    Mensagem = "Informar o Id do Produto.",
                    Ok = false,
                };
            }

            if(controleComanda.NumeroComanda == 0)
            {
                return new Retorno<SemConteudo>
                {
                    Mensagem = "Informar um número de comanda válido.",
                    Ok = false,
                };
            }

            _controleComandaRepositorio.Create(controleComanda);

            return new Retorno<SemConteudo> { Ok = true };
        }

        public Retorno<Fechamento> FecharComanda(int numeroComanda)
        {
            if (numeroComanda == 0)
            {
                return new Retorno<Fechamento>
                {
                    Mensagem = "Informar um número de comanda válido.",
                    Ok = false,
                };
            }

            var lista = _controleComandaRepositorio.GetAll().Where(w => w.NumeroComanda == numeroComanda && w.Fechamento_Id == null);

            var valorTotal = lista.Sum(s => s.Produto.Valor);

            var fechamento = new Fechamento
            {
                ValorTotal = valorTotal,
                ControleComandas = lista.ToList()
            };
            var retorno = _fechamentoRepositorio.Create(fechamento);

            return new Retorno<Fechamento> { Ok = true };
        }

        public Retorno<SemConteudo> Resetar(int numeroComanda)
        {
            if(numeroComanda == 0)
            {
                return new Retorno<SemConteudo>
                {
                    Mensagem = "Informar um numero de comanda válido.",
                    Ok = false
                };
            }

            var algo = _controleComandaRepositorio.Resetar(numeroComanda);

            return new Retorno<SemConteudo> { Ok = true };
        }
    }
}
