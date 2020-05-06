using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Models
{
    public class Cliente
    {
        public int Id{ get; set; }
        public string Nome  { get; set; }
        public DateTime Nascimento { get; set; }
        public double Altura { get; set; }
    }
}
