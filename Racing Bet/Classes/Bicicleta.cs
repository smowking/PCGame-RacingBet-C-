using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing_Bet.Classes
{
    public class Bicicleta
    {
        #region Propriedades
        public string NomeCiclista { get; set; }
        public int Numero { get; set; }
        #endregion

        #region Construtor
        public Bicicleta(string nomeCiclista, int numero) {
            this.NomeCiclista = nomeCiclista;
            this.Numero = numero;
        }
        #endregion


    }
}
