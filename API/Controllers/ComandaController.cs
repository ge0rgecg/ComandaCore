using Dominio;
using Microsoft.AspNetCore.Mvc;
using Servico.Interface;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// API que manipula a comanda.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private IComandaServico _comandaServico { get; set; }
        
        /// <summary>
        /// Construtor da comanda e instância o serviço.
        /// </summary>
        /// <param name="comandaServico">Interface do serviço da comanda.</param>
        public ComandaController(IComandaServico comandaServico)
        {
            _comandaServico = comandaServico == null ? throw new ArgumentNullException("comandaServico") : comandaServico;
        }

        /// <summary>
        /// Realiza o fechamento da comanda.
        /// </summary>
        /// <param name="numeroComanda">Número da comanda</param>
        /// <returns>Retorno o status da operação, mensagem, caso exista  e as informações do fechamento.  </returns>
        [HttpPost("{numeroComanda}")]
        public Task<Retorno<Fechamento>> FecharComanda(int numeroComanda)
        {
            return _comandaServico.FecharComanda(numeroComanda);
        }

        /// <summary>
        /// Associa o código do produto a comanda.
        /// </summary>
        /// <param name="numeroComanda">Número da comanda.</param>
        /// <param name="idProduto">Código do produto.</param>
        /// <returns>Retorno o status da operação e uma mensagem, caso exista.</returns>
        [HttpPut("{numeroComanda}")]
        public Task<Retorno<SemConteudo>> RegistrarProduto(int numeroComanda, [FromBody] int idProduto)
        {
            return _comandaServico.AdicionarProduto(new ControleComanda
            {
                NumeroComanda = numeroComanda,
                Produto_Id = idProduto
            });
        }

        /// <summary>
        /// Limpa os produtos que estão na comanda.
        /// </summary>
        /// <param name="numeroComanda">Número da comanda.</param>
        /// <returns>Retorno o status da operação e uma mensagem, caso exista.</returns>
        [HttpDelete("{numeroComanda}")]
        public Task<Retorno<SemConteudo>> ResetarComanda(int numeroComanda)
        {
            return _comandaServico.Resetar(numeroComanda);
        }
    }
}
