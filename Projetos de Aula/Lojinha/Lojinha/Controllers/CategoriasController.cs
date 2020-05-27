using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lojinha.Services;
using Microsoft.AspNetCore.Mvc;
using Lojinha.Models;

namespace Lojinha.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly CategoriaService _categoriaService;

        public CategoriasController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        public IActionResult Index()
        {
            var categorias = _categoriaService.getCategorias();
            return View( categorias );
        }
        
        // GET
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            _categoriaService.Inserir(categoria);
            //    return RedirectToAction("Index");
            // ou
            return RedirectToAction(nameof(Index));
        }
    }
}