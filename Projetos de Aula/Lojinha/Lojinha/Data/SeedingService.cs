using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lojinha.Models;

namespace Lojinha.Data
{
    public class SeedingService
    {
        private LojinhaContext _context;

        public SeedingService( LojinhaContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if( _context.Produto.Any())
            {
                return;
            }

            Categoria cat01 = new Categoria(1, "Bebidas");
            Categoria cat02 = new Categoria { Id = 2, Nome = "Eletrônicos" };

            Produto p1 = new Produto(1, "Pepsi", 5.99, 100, cat01);
            Produto p2 = new Produto(2, "iPhone", 3999.9, 5, cat02);
            Produto p3 = new Produto(3, "Coca-cola", 6.49, 100, cat01);

            _context.Categoria.AddRange(cat01, cat02);
            _context.Produto.AddRange(p1, p2, p3);

            _context.SaveChanges();

        }
    }
}
