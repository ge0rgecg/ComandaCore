using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Retorno<IEnumerable<Produto>> objetoProduto =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Retorno<IEnumerable<Produto>>>(obterProduto());

            return View(new AdicionarProdutoViewModel { Produtos = objetoProduto.Objeto.ToList() });
        }

        [HttpPost]
        public IActionResult Index(AdicionarProdutoViewModel model)
        {
            var retornoRegistro = adicionarProduto(model.NumeroComanda, model.IdProduto);

            Retorno<SemConteudo> retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<Retorno<SemConteudo>>(retornoRegistro);

            ViewBag.Message = retorno.Ok ? "Produto adicionado." : retorno.Mensagem;

            Retorno<IEnumerable<Produto>> objetoProduto =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Retorno<IEnumerable<Produto>>>(obterProduto());

            return View(new AdicionarProdutoViewModel { Produtos = objetoProduto.Objeto.ToList() });
        }

        [HttpGet]
        public IActionResult Fechamento()
        {
            //var view = new FechamentoComandaViewModel { Fechamento = new Dominio.Fechamento() {ControleComandas=new List<ControleComanda>() } };
            return View();
        }

        [HttpPost]
        public IActionResult Fechamento(FechamentoComandaViewModel model)
        {
            var fechamento = fecharComanda(model.NumeroComanda);

            Retorno<Fechamento> objetoFechamento =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Retorno<Fechamento>>(fechamento);

            model.Fechamento = objetoFechamento.Objeto;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string obterProduto()
        {
            using (var client = new HttpClient(new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            }))
            {

                client.BaseAddress = new Uri("https://localhost:44314/");

                HttpResponseMessage response = client.GetAsync("api/Comanda").Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        public string adicionarProduto(int numeroPedido, int produtoId)
        {
            using (var client = new HttpClient(new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            }))
            {

                client.BaseAddress = new Uri("https://localhost:44314/");
                string url = "api/Comanda/" + numeroPedido;
                var stringContent = new StringContent(produtoId.ToString(), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(url, stringContent).Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        public string fecharComanda(int numeroPedido)
        {
            using (var client = new HttpClient(new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            }))
            {

                client.BaseAddress = new Uri("https://localhost:44314/");
                string url = "api/Comanda";
                var stringContent = new StringContent(numeroPedido.ToString(), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }
    }
}
