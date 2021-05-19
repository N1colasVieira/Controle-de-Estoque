using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Itens
    {
        public int idItem { get; set; }
        public string nome { get; set; }
        public string cor { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string tamanho { get; set; }
        public int quantidadeDisponivel { get; set; }
        public string tipo { get; set; }
        public int quantidadeRecomendada { get; set; }
        public DateTime cadastradoNoDia { get; set; }
    }
}
