using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Movimentacao
    {
        public int id_itens { get; set; }
        public int id_usuario { get; set; }
        public string requisicao { get; set; }
        public DateTime dataRequisicao { get; set; }
        public int quantidadeRequisitada { get; set; }
        public string reposicao { get; set; }
        public DateTime dataReposicao { get; set; }
        public int quantidadeRepositada { get; set; }
        public string observacao { get; set; }
    }
}
