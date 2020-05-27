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

        public Categoria getCategoriaById(int id)
        {

            return _context.Categoria.FirstOrDefault(cat => cat.Id == id);
        }

        public void editar(Categoria categoria)
        {
            if (_context.Categoria.Any(cat => cat.Id == categoria.Id))
            {
                try
                {
                    _context.Update(categoria);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {

                }
            }
        }

        public void excluir(int id)
        {
            var cat = getCategoriaById(id);
            _context.Categoria.Remove(cat);
            _context.SaveChanges();
            
        }
    }
}
