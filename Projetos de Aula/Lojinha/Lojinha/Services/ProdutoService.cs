using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lojinha.Data;
using Lojinha.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Produto.Include(prod => prod.Categoria)
                .OrderBy(x => x.Nome).ToList();
        }

        public Produto getProdutoById(int id)
        {
            return _context.Produto.Include(prod => prod.Categoria)
                .FirstOrDefault(prod => prod.Id == id);
        }

        public void Excluir(int id)
        {
            var prod = _context.Produto.Find(id);
            _context.Produto.Remove(prod);
            _context.SaveChanges();

        }

        public void Editar( Produto produto)
        {
            if (_context.Produto.Any(prod => prod.Id == produto.Id))
            {
                try
                {
                    _context.Update(produto);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {

                }
            } 
        }


    }
}
