using Dominio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class AdicionarProdutoViewModel
    {
        public int NumeroComanda { get; set; }

        public int IdProduto { get; set; }

        public List<Produto> Produtos { get; set; }
    }

}
