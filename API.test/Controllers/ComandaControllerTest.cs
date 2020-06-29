using API.Controllers;
using AutoFixture.Xunit2;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Servico.Interface;
using System;
using System.Threading.Tasks;
using Xunit;

namespace API.test
{
    public class ComandaControllerTest
    {
        private readonly Mock<IComandaServico> _mockServico = new Mock<IComandaServico>();

        [Fact]
        public void Constructor_null()
        {
            Assert.Throws<ArgumentNullException>(
                () => new ComandaController(null)
            );
        }

        [Theory]
        [AutoData]
        public async Task Post_Fechar_Comanda(int numeroComanda)
        {
            _mockServico.Setup(mock => mock.FecharComanda(It.IsAny<int>()))
                .Returns(Task.FromResult(new Retorno<Fechamento>()));

            var controller = new ComandaController(_mockServico.Object);

            var response = await controller.FecharComanda(numeroComanda);

            Assert.NotNull(response);
            Assert.IsType<Retorno<Fechamento>>(response);

            _mockServico.Verify(
                mock => mock.FecharComanda(It.IsAny<int>()),
                Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task Post_Registrar_Produto(
            int numeroComanda,
            int idProduto)
        {
            _mockServico.Setup(mock => mock.AdicionarProduto(It.IsAny<ControleComanda>()))
                .Returns(Task.FromResult(new Retorno<SemConteudo>()));

            var controller = new ComandaController(_mockServico.Object);

            var response = await controller.RegistrarProduto(numeroComanda, idProduto);

            Assert.NotNull(response);
            Assert.IsType<Retorno<SemConteudo>>(response);

            _mockServico.Verify(
                mock => mock.AdicionarProduto(It.IsAny<ControleComanda>()),
                Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task Post_Resetar_Comanda(int numeroComanda)
        {
            _mockServico.Setup(mock => mock.Resetar(It.IsAny<int>()))
                .Returns(Task.FromResult(new Retorno<SemConteudo>()));

            var controller = new ComandaController(_mockServico.Object);

            var response = await controller.ResetarComanda(numeroComanda);

            Assert.NotNull(response);
            Assert.IsType<Retorno<SemConteudo>>(response);

            _mockServico.Verify(
                mock => mock.Resetar(It.IsAny<int>()),
                Times.Once);
        }


    }
}