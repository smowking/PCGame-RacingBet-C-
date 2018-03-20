using Racing_Bet.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing_Bet
{
    //Laio Racing Bet
    //07/03/2018
    //Tamanho ideal do form: 988; 567
    public partial class Form1 : Form
    {
        Bicicleta ciclistaVencedor = null;
        List<Jogador> jogadores;

        #region Construtor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            btnReiniciar.Enabled = false;
            btnIniciar.Enabled = false;
            List<Bicicleta> listaCiclistas = ColocarCiclistasNaPista();
            List<PictureBox> pistasCorrida = DefinirPistasDeCorrida();

            List<Jogador> jogadoresRodada = GravarApostas(jogadores);

            while (ciclistaVencedor == null)
            {
                Correr(listaCiclistas, pistasCorrida);
            }

            string[] temp = {};

            jogadoresRodada.ForEach(o => {
                if (o.CiclistaCorrente == o.Numero) {
                    jogadores.Where(x => x.Numero == o.Numero).Single().Saldo += o.ApostaCorrente;
                }
            });

            txtCampeão.Text = "O ciclista campeão é: " + ciclistaVencedor.NomeCiclista;
            btnReiniciar.Enabled = true;
        }

        private List<Jogador> GravarApostas(List<Jogador> llstJogadores)
        {
            List<Jogador> jogadoresApostados = new List<Jogador>();

            if (!string.IsNullOrEmpty(txtNomeJogador1.Text) && !string.IsNullOrEmpty(txtApostaJogador1.Text))
            {
                Jogador jogador = llstJogadores.Where(o => o.Numero == 1).Single();

                jogador.ApostaCorrente = Convert.ToDouble(txtApostaJogador1.Text);
                jogador.CiclistaCorrente = tbarCiclistaJogador1.Value;

                jogadoresApostados.Add(jogador);
            }

            if (!string.IsNullOrEmpty(txtNomeJogador2.Text) && !string.IsNullOrEmpty(txtApostaJogador2.Text))
            {
                Jogador jogador = llstJogadores.Where(o => o.Numero == 2).Single();

                jogador.ApostaCorrente = Convert.ToDouble(txtApostaJogador2.Text);
                jogador.CiclistaCorrente = tbarCiclistaJogador2.Value;

                jogadoresApostados.Add(jogador);
            }

            if (!string.IsNullOrEmpty(txtNomeJogador3.Text) && !string.IsNullOrEmpty(txtApostaJogador3.Text))
            {
                Jogador jogador = llstJogadores.Where(o => o.Numero == 3).Single();

                jogador.ApostaCorrente = Convert.ToDouble(txtApostaJogador3.Text);
                jogador.CiclistaCorrente = tbarCiclistaJogador3.Value;

                jogadoresApostados.Add(jogador);
            }

            if (!string.IsNullOrEmpty(txtNomeJogador4.Text) && !string.IsNullOrEmpty(txtApostaJogador4.Text))
            {
                Jogador jogador = llstJogadores.Where(o => o.Numero == 4).Single();

                jogador.ApostaCorrente = Convert.ToDouble(txtApostaJogador4.Text);
                jogador.CiclistaCorrente = tbarCiclistaJogador4.Value;

                jogadoresApostados.Add(jogador);
            }

            return jogadoresApostados;
        }

        private void Correr(List<Bicicleta> listaCiclistas, List<PictureBox> pistasCorrida)
        {
            Thread.Sleep(5);
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(10);
                ExecutarMovimentacao(pistasCorrida[i], listaCiclistas[i]);
            }
        }

        private List<PictureBox> DefinirPistasDeCorrida()
        {
            List<PictureBox> listPistas = new List<PictureBox>();

            listPistas.Add(picCiclista1);
            listPistas.Add(picCiclista2);
            listPistas.Add(picCiclista3);
            listPistas.Add(picCiclista4);

            return listPistas;
        }

        private void ExecutarMovimentacao(PictureBox picCiclista, Bicicleta ciclista)
        {

            Point localizacao = picCiclista.Location;
            int avanco = new Random().Next(1, 10);

            if (localizacao.X + avanco >= 707 && ciclistaVencedor == null) {
                localizacao.X = 843;
                localizacao.Y -= 60;
                picCiclista.Location = localizacao;
                ciclistaVencedor = ciclista;
                return;
            }
            else
            {
                localizacao.X += avanco;
                picCiclista.Location = localizacao;
            }

            Application.DoEvents();
        }
        #endregion

        #region Metodos
        private List<Bicicleta> ColocarCiclistasNaPista()
        {
            List<Bicicleta> llstCiclistas = new List<Bicicleta>();

            for (int i = 1; i <= 4; i++)
            {
                Bicicleta ciclista = new Bicicleta("Ciclista "+ i.ToString(), i);
                llstCiclistas.Add(ciclista);
            }

            return llstCiclistas;
        }
        #endregion

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Point point1 = picCiclista1.Location;
            Point point2 = picCiclista2.Location;
            Point point3 = picCiclista3.Location;
            Point point4 = picCiclista4.Location;

            point1.X = 27;
            point1.Y = 207;
            picCiclista1.Location = point1;
            point2.X = 27;
            point2.Y = 237;
            picCiclista2.Location = point2;
            point3.X = 27;
            point3.Y = 267;
            picCiclista3.Location = point3;
            point4.X = 27;
            point4.Y = 295;
            picCiclista4.Location = point4;
            
            ciclistaVencedor = null;
            txtCampeão.Text = string.Empty;

            btnIniciar.Enabled = true;
            btnReiniciar.Enabled = false;
        }

        private void btnConfirmarJogadores_Click(object sender, EventArgs e)
        {
            jogadores = CadastrarJogadores();

            txtNomeJogador1.Enabled = false;
            txtNomeJogador2.Enabled = false;
            txtNomeJogador3.Enabled = false;
            txtNomeJogador4.Enabled = false;

            btnConfirmarJogadores.Visible = false;
            btnIniciar.Visible = true;
            btnReiniciar.Visible = true;
        }

        private List<Jogador> CadastrarJogadores()
        {
            List<Jogador> jogadores = new List<Jogador>();

            if (!string.IsNullOrEmpty(txtNomeJogador1.Text) && !string.IsNullOrEmpty(txtApostaJogador1.Text))
            {
                Jogador jogador1 = new Jogador();

                jogador1.NomeJogador = txtNomeJogador1.Text;
                jogador1.ApostaCorrente = Convert.ToDouble(txtApostaJogador1.Text);
                jogador1.CiclistaCorrente = tbarCiclistaJogador1.Value;
                jogador1.Saldo = 0;
                jogador1.Numero = 1;

                jogadores.Add(jogador1);
            }

            if (!string.IsNullOrEmpty(txtNomeJogador2.Text) && !string.IsNullOrEmpty(txtApostaJogador2.Text))
            {
                Jogador jogador2 = new Jogador();

                jogador2.NomeJogador = txtNomeJogador2.Text;
                jogador2.ApostaCorrente = Convert.ToDouble(txtApostaJogador2.Text);
                jogador2.CiclistaCorrente = tbarCiclistaJogador2.Value;
                jogador2.Saldo = 0;
                jogador2.Numero = 2;

                jogadores.Add(jogador2);
            }

            if (!string.IsNullOrEmpty(txtNomeJogador3.Text) && !string.IsNullOrEmpty(txtApostaJogador3.Text))
            {
                Jogador jogador3 = new Jogador();

                jogador3.NomeJogador = txtNomeJogador3.Text;
                jogador3.ApostaCorrente = Convert.ToDouble(txtApostaJogador3.Text);
                jogador3.CiclistaCorrente = tbarCiclistaJogador2.Value;
                jogador3.Saldo = 0;
                jogador3.Numero = 3;

                jogadores.Add(jogador3);
            }

            if (!string.IsNullOrEmpty(txtNomeJogador4.Text) && !string.IsNullOrEmpty(txtApostaJogador4.Text))
            {
                Jogador jogador4 = new Jogador();

                jogador4.NomeJogador = txtNomeJogador4.Text;
                jogador4.ApostaCorrente = Convert.ToDouble(txtApostaJogador4.Text);
                jogador4.CiclistaCorrente = tbarCiclistaJogador2.Value;
                jogador4.Saldo = 0;
                jogador4.Numero = 4;

                jogadores.Add(jogador4);
            }

            return jogadores;
        }
    }
}
