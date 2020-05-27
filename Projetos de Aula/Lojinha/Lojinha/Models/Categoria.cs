using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
        }

        public Categoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdicionarProduto(Produto produto)
        {
            Produtos.Add(produto);
        }

        public void RemoverProduto(Produto produto)
        {
            Produtos.Remove(produto);
        }
    }
}
