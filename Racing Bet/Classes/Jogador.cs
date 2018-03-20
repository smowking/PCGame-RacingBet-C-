using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing_Bet.Classes
{
    public class Jogador
    {
        public string NomeJogador { get; set; }
        public int Numero { get; set; }
        public double ApostaCorrente { get; set; }
        public int CiclistaCorrente { get; set; }
        public double Saldo { get; set; }
    }
}
