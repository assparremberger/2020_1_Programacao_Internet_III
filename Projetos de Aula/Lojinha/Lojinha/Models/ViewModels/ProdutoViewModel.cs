using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Models.ViewModels
{
    public class ProdutoViewModel
    {
        public Produto Produto { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
    }
}
