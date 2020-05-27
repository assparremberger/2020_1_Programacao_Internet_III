using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lojinha.Data;
using Lojinha.Models;

namespace Lojinha.Services
{

    public class CategoriaService
    {
        private readonly LojinhaContext _context;

        public CategoriaService(LojinhaContext context)
        {
            _context = context;
        }

        public void Inserir(Categoria categoria)
        {
            _context.Add( categoria );
            _context.SaveChanges();
        }

        public List<Categoria> getCategorias()
        {
            return _context.Categoria.OrderBy(x => x.Nome).ToList();
        }
    }
}
