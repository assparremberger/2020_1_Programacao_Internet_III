using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lojinha.Data;
using Lojinha.Models;

namespace Lojinha.Services
{

    public class ProdutoService
    {
        private readonly LojinhaContext _context;

        public ProdutoService(LojinhaContext context)
        {
            _context = context;
        }

        public void Inserir(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
        }

        public List<Produto> getProdutos()
        {
            return _context.Produto.OrderBy(x => x.Nome).ToList();
        }
    }
}
