using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lojinha.Data;
using Lojinha.Models;
using Lojinha.Services;
using Lojinha.Models.ViewModels;

namespace Lojinha.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly LojinhaContext _context;

        private readonly ProdutoService _produtoService;
        private readonly CategoriaService _categoriaService;
/*
        public ProdutosController(LojinhaContext context)
        {
            _context = context;
        }
        */

        public ProdutosController(ProdutoService produtoService, CategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            //           return View(await _context.Produto.ToListAsync());
            return View(_produtoService.getProdutos());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            var categorias = _categoriaService.getCategorias();
            var viewModel = new ProdutoViewModel { Categorias = categorias };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            _produtoService.Inserir(produto);
            //    return RedirectToAction("Index");
            // ou
            return RedirectToAction(nameof(Index));
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*      [HttpPost]
              [ValidateAntiForgeryToken]
              public async Task<IActionResult> Create([Bind("Id,Nome,Preco,Quantidade")] Produto produto)
              {
                  if (ModelState.IsValid)
                  {
                      _context.Add(produto);
                      await _context.SaveChangesAsync();
                      return RedirectToAction(nameof(Index));
                  }
                  return View(produto);
              }
              */

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco,Quantidade")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
