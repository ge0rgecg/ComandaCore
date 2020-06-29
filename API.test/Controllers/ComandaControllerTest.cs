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
            var controller = new ComandaController(_mockServico.Object);

            var response = await controller.FecharComanda(numeroComanda);

            Assert.NotNull(response);
            Assert.IsType<OkResult>(response);

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
            var controller = new ComandaController(_mockServico.Object);

            var response = await controller.RegistrarProduto(numeroComanda, idProduto);

            Assert.NotNull(response);
            Assert.IsType<OkResult>(response);

            _mockServico.Verify(
                mock => mock.AdicionarProduto(It.IsAny<ControleComanda>()),
                Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task Post_Resetar_Comanda(int numeroComanda)
        {
            var controller = new ComandaController(_mockServico.Object);

            var response = await controller.ResetarComanda(numeroComanda);

            Assert.NotNull(response);
            Assert.IsType<OkResult>(response);

            _mockServico.Verify(
                mock => mock.Resetar(It.IsAny<int>()),
                Times.Once);
        }


    }
}