using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lojinha.Models;

namespace Lojinha.Data
{
    public class LojinhaContext : DbContext
    {
        public LojinhaContext (DbContextOptions<LojinhaContext> options)
            : base(options)
        {
        }

        public DbSet<Lojinha.Models.Produto> Produto { get; set; }

        public DbSet<Lojinha.Models.Cliente> Cliente { get; set; }
    }
}
