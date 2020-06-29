using AutoFixture.Xunit2;
using Dominio;
using Moq;
using Repositorio.Interface;
using Servico.Servicos;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Xunit;

namespace Servico.Test
{
    public class ComandaServicoTest
    {
        private readonly Mock<IProdutoRepositorio> _mockProdutoRepositorio = new Mock<IProdutoRepositorio>();
        private readonly Mock<IControleComandaRepositorio> _mockControleComandaRepositorio = new Mock<IControleComandaRepositorio>();
        private readonly Mock<IFechamentoRepositorio> _mockFechamentoRepositorio = new Mock<IFechamentoRepositorio>();
        private readonly Mock<ILimiteProdutoRepositorio> _mockLimiteProdutoRepositorio = new Mock<ILimiteProdutoRepositorio>();
        private readonly Mock<IComboRepositorio> _mockComboRepositorio = new Mock<IComboRepositorio>();

        private ComandaServico _comandaServico;

        public ComandaServicoTest()
        {
            _comandaServico = new ComandaServico(
                    _mockProdutoRepositorio.Object,
                    _mockControleComandaRepositorio.Object,
                    _mockFechamentoRepositorio.Object,
                    _mockLimiteProdutoRepositorio.Object,
                    _mockComboRepositorio.Object);
        }


        [Fact]
        public void Constructor_null()
        {
            Assert.Throws<ArgumentNullException>(
                () => new ComandaServico(
                    null,
                    _mockControleComandaRepositorio.Object,
                    _mockFechamentoRepositorio.Object,
                    _mockLimiteProdutoRepositorio.Object,
                    _mockComboRepositorio.Object));

            Assert.Throws<ArgumentNullException>(
                () => new ComandaServico(
                    _mockProdutoRepositorio.Object,
                    null,
                    _mockFechamentoRepositorio.Object,
                    _mockLimiteProdutoRepositorio.Object,
                    _mockComboRepositorio.Object));

            Assert.Throws<ArgumentNullException>(
                () => new ComandaServico(
                    _mockProdutoRepositorio.Object,
                    _mockControleComandaRepositorio.Object,
                    null,
                    _mockLimiteProdutoRepositorio.Object,
                    _mockComboRepositorio.Object));

            Assert.Throws<ArgumentNullException>(
                () => new ComandaServico(
                    _mockProdutoRepositorio.Object,
                    _mockControleComandaRepositorio.Object,
                    _mockFechamentoRepositorio.Object,
                    null,
                    _mockComboRepositorio.Object));

            Assert.Throws<ArgumentNullException>(
                () => new ComandaServico(
                    _mockProdutoRepositorio.Object,
                    _mockControleComandaRepositorio.Object,
                    _mockFechamentoRepositorio.Object,
                    _mockLimiteProdutoRepositorio.Object,
                    null));
        }

        [Theory]
        [InlineAutoData(0)]
        [InlineAutoData(1)]
        public async Task test_resetar(int numeroComanda)
        {
            _mockControleComandaRepositorio.Setup(s => s.Resetar(It.IsAny<int>()))
                .Returns(Task.FromResult(new Retorno<SemConteudo>()));

            var servico = new ComandaServico(
                    _mockProdutoRepositorio.Object,
                    _mockControleComandaRepositorio.Object,
                    _mockFechamentoRepositorio.Object,
                    _mockLimiteProdutoRepositorio.Object,
                    _mockComboRepositorio.Object);

            var response = _comandaServico.Resetar(numeroComanda);

            Assert.NotNull(response);
            Assert.Equal(response.Result.Ok, Convert.ToBoolean(numeroComanda));

            _mockControleComandaRepositorio.Verify(
                mock => mock.Resetar(It.IsAny<int>()),
                Times.Exactly(numeroComanda));
        }

        [Theory]
        [InlineAutoData(0, 0, false, false, "Informar o Id do Produto.",false)]
        [InlineAutoData(1, 0, false, false, "Informar um número de comanda válido.", false)]
        [InlineAutoData(1, 1, true, true, "Limite de produto excedido, não é permitido pedir mais desse item.", false)]
        [InlineAutoData(1, 1, true, false, "", true)]
        public async Task test_adicionar_produto(
            int produtoId,
            int numeroComanda,
            bool temLimiteProduto,
            bool limiteExcedido,
            string mensagem,
            bool ok)
        {
            var controleComanda = new ControleComanda
            {
                NumeroComanda = numeroComanda,
                Produto_Id = produtoId,
            };

            _mockLimiteProdutoRepositorio.Setup(s => s.GetAll())
                .Returns(temLimiteProduto ?
                    new List<LimiteProduto> 
                    { 
                        new LimiteProduto { 
                            Produto_Id = produtoId, 
                            QuantidadeLimite = 1 
                        } 
                    } : new List<LimiteProduto>());

            _mockControleComandaRepositorio
                .Setup(s => s.GetAllByNumeroComanda(It.IsAny<int>()))
                .Returns(
                    limiteExcedido ? 
                        new List<ControleComanda> { new ControleComanda { Produto_Id = produtoId } }
                        : new List<ControleComanda>());

            _mockControleComandaRepositorio.Setup(s => s.Create(It.IsAny<ControleComanda>()))
                .Returns(Task.FromResult(1));

            var response = _comandaServico.AdicionarProduto(controleComanda);

            Assert.NotNull(response);
            Assert.Equal(response.Result.Ok, ok);
            Assert.Equal(response.Result.Mensagem, mensagem);

            _mockLimiteProdutoRepositorio.Verify(
                mock => mock.GetAll(),
                Times.Exactly(produtoId > 0 && numeroComanda > 0 ? 1 : 0));

            _mockControleComandaRepositorio.Verify(
                mock => mock.GetAllByNumeroComanda(It.IsAny<int>()),
                Times.Exactly(produtoId > 0 && numeroComanda > 0 && temLimiteProduto ? 1 : 0));

            _mockControleComandaRepositorio.Verify(
                mock => mock.Create(It.IsAny<ControleComanda>()),
                Times.Exactly(Convert.ToInt32(ok)));

        }

        [Theory]
        [InlineAutoData(0)]
        [InlineAutoData(1)]
        public async Task test_fechar_comanda(int numeroComanda)
        {
            _mockControleComandaRepositorio
                .Setup(s => s.GetAllByNumeroComanda(It.IsAny<int>()))
                .Returns(new List<ControleComanda> {
                    new ControleComanda
                    {
                        NumeroComanda = numeroComanda,
                        Produto_Id = 1,
                        Produto = new Produto
                        {
                            Valor = 10,
                            Id = 1,
                        }
                    }
                });

            _mockComboRepositorio.Setup(s => s.GetAllWithChilds())
                .Returns(new List<Combo>
                {
                    new Combo
                    {
                        ComboItem = new List<ComboItem>{ 
                            new ComboItem
                            {
                                Quantidade = 1,
                                Produto_Id = 1
                            }
                        },
                        ComboDesconto = new List<ComboDesconto>
                        {
                            new ComboDesconto
                            {
                                Produto_Id = 1,
                                Porcentagem = 50,
                            }
                        }
                    }
                });

            _mockFechamentoRepositorio.Setup(s => s.Create(It.IsAny<Fechamento>()))
                .Returns(Task.FromResult(1));

            _mockControleComandaRepositorio
                .Setup(s => s.AssinarFechamento(It.IsAny<IEnumerable<ControleComanda>>()))
                .Returns(Task.FromResult(1));

            var response = _comandaServico.FecharComanda(numeroComanda);

            Assert.NotNull(response);
            Assert.Equal(response.Result.Ok, Convert.ToBoolean(numeroComanda));

            if (response.Result.Ok)
                Assert.Equal(5, response.Result.Objeto.ValorTotal);

        }
    }
}
