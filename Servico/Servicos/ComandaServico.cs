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
        private ILimiteProdutoRepositorio _limiteProdutoRepositorio { get; set; }
        private IComboRepositorio _comboRepositorio { get; set; }

        public ComandaServico(IProdutoRepositorio produtoRepositorio,
            IControleComandaRepositorio controleComandaRepositorio,
            IFechamentoRepositorio fechamentoRepositorio,
            ILimiteProdutoRepositorio limiteProdutoRepositorio,
            IComboRepositorio comboRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _controleComandaRepositorio = controleComandaRepositorio;
            _fechamentoRepositorio = fechamentoRepositorio;
            _limiteProdutoRepositorio = limiteProdutoRepositorio;
            _comboRepositorio = comboRepositorio;
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

            var limites = _limiteProdutoRepositorio.GetAll().Where(w => w.Produto_Id == controleComanda.Produto_Id);

            if (limites.Any())
            {
                var quantidade = _controleComandaRepositorio.GetAllByNumeroComanda(controleComanda.NumeroComanda).Count(c => c.Produto_Id == controleComanda.Produto_Id);

                if (limites.FirstOrDefault().QuantidadeLimite == quantidade)
                {
                    return new Retorno<SemConteudo>
                    {
                        Mensagem = $"Limite de produto excedido, não é permitido pedir mais desse item."
                    };
                }
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
                ValorTotal = valorTotal
            };

            //implementar regra de desconto.
            var combos = _comboRepositorio.GetAllWithChilds();

            foreach(var combo in combos)
            {
                var vezesDesconto = 0;
                foreach(var item in combo.ComboItem)
                {
                    var quantidadeConsumida = lista.Count(w => w.Produto_Id == item.Produto_Id);
                    var itemAtual = (quantidadeConsumida / item.Quantidade);
                    if (itemAtual <= 0) 
                    {
                        vezesDesconto = 0;
                        break;
                    }

                    vezesDesconto = (vezesDesconto == 0 || vezesDesconto > itemAtual) ? itemAtual : vezesDesconto;
                }

                if (vezesDesconto == 0) continue;

                foreach(var item in combo.ComboDesconto)
                {
                    var descontoItem = lista.FirstOrDefault(f => f.Produto_Id == item.Produto_Id).Produto.Valor * item.Porcentagem / 100;

                    var itens = lista.Where(w => w.Produto_Id == item.Produto_Id).Take(vezesDesconto);

                    foreach(var i in itens)
                    {
                        i.Desconto += descontoItem;
                    }

                    fechamento.ValorTotal -= descontoItem * vezesDesconto;
                }
            }


            await _fechamentoRepositorio.Create(fechamento);

            await _controleComandaRepositorio.AssinarFechamento(
                lista.Select(s => new ControleComanda
                { 
                    Fechamento_Id = fechamento.Id, 
                    Id = s.Id, 
                    NumeroComanda = s.NumeroComanda, 
                    Produto_Id = s.Produto_Id, 
                    Desconto = s.Desconto 
                }).ToList());

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
