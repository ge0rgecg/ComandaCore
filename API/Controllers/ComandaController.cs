﻿using Dominio;
using Microsoft.AspNetCore.Mvc;
using Servico.Interface;

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
            _comandaServico = comandaServico;
        }

        /// <summary>
        /// Realiza o fechamento da comanda.
        /// </summary>
        /// <param name="NumeroComanda">Número da comanda</param>
        /// <returns>Retorno o status da operação, mensagem, caso exista  e as informações do fechamento.  </returns>
        [HttpPost("{NumeroComanda}")]
        public Retorno<Fechamento> FecharComanda(int NumeroComanda)
        {
            return _comandaServico.FecharComanda(NumeroComanda);
        }

        /// <summary>
        /// Associo o código do produto a comanda.
        /// </summary>
        /// <param name="NumeroComanda">Número da comanda.</param>
        /// <param name="idProduto">Código do produto.</param>
        /// <returns>Retorno o status da operação e uma mensagem, caso exista.</returns>
        [HttpPut("{NumeroComanda}")]
        public Retorno<SemConteudo> RegistrarProduto(int NumeroComanda, [FromBody] int idProduto)
        {
            return _comandaServico.AdicionarProduto(new ControleComanda());
        }

        /// <summary>
        /// Limpo os produtos que estão na comanda.
        /// </summary>
        /// <param name="NumeroComanda">Número da comanda.</param>
        /// <returns>Retorno o status da operação e uma mensagem, caso exista.</returns>
        [HttpDelete("{NumeroComanda}")]
        public Retorno<SemConteudo> ResetarComanda(int NumeroComanda)
        {
            return _comandaServico.Resetar(NumeroComanda);

            
        }
    }
}
