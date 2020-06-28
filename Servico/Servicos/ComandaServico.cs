using Dominio;
using Repositorio.Interface;
using Servico.Interface;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<Retorno<SemConteudo>> AdicionarProduto(ControleComanda controleComanda)
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

            await _controleComandaRepositorio.Create(controleComanda);

            return new Retorno<SemConteudo> { Ok = true };
        }

        public async Task<Retorno<Fechamento>> FecharComanda(int numeroComanda)
        {
            if (numeroComanda == 0)
            {
                return new Retorno<Fechamento>
                {
                    Mensagem = "Informar um número de comanda válido.",
                    Ok = false,
                };
            }

            var lista = _controleComandaRepositorio.GetAllByNumeroComanda(numeroComanda)
                .Where(w => w.Fechamento_Id == null);
            
            var valorTotal = lista.Sum(s => s.Produto.Valor);

            var fechamento = new Fechamento
            {
                ValorTotal = valorTotal,
                ControleComandas = lista.ToList()
            };
            await _fechamentoRepositorio.Create(fechamento);

            return new Retorno<Fechamento> { Ok = true, Objeto = fechamento };
        }

        public async Task<Retorno<SemConteudo>> Resetar(int numeroComanda)
        {
            if(numeroComanda == 0)
            {
                return new Retorno<SemConteudo>
                {
                    Mensagem = "Informar um numero de comanda válido.",
                    Ok = false
                };
            }

            await _controleComandaRepositorio.Resetar(numeroComanda);

            return new Retorno<SemConteudo> { Ok = true };
        }
    }
}
