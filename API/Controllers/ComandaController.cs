using Dominio;
using Microsoft.AspNetCore.Mvc;
using Servico.Interface;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private IComandaServico _comandaServico { get; set; }
        
        public ComandaController(IComandaServico comandaServico)
        {
            _comandaServico = comandaServico;
        }

        // GET api/<ComandaController>/5
        [HttpDelete("{id}")]
        public string Get(int id)
        {
            //_comandaServico.
            return "value";
        }

        // POST api/<ComandaController>
        [HttpPost("{idComanda}")]
        public Retorno<Fechamento> FecharComanda(int idComanda)
        {
            return _comandaServico.FecharComanda(idComanda);
        }

        // PUT api/<ComandaController>/5
        [HttpPut("{idComanda}")]
        public Retorno<bool> RegistrarProduto(int idComanda, [FromBody] int idProduto)
        {
            return _comandaServico.AdicionarProduto(new ControleComanda());
        }

        // DELETE api/<ComandaController>/5
        [HttpDelete("{id}")]
        public Retorno<bool> ResetarComanda(int idComanda)
        {
            return _comandaServico.Resetar(idComanda);

            
        }
    }
}
