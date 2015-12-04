using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Milicia
{
    public partial class Milicia : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        dominion.Altres.Partida partida;
        List<Altres.Jugador> jugadors;
        int numJugadors = 0;
        public Milicia()
        {
            cost = 4;
            valor = 2;
            InitializeComponent();
            imatgeAnvers = dominion.ImatgesCartes.Milicia;
        }

        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            this.partida = partida;
            numJugadors = 0;
            jugadors=new List<Altres.Jugador>();
            jugadors.AddRange(partida.Jugadors.Values);
            jugadors.Remove(partida.JugadorActual);
            FesPregunta(0);

        }

        private void FesPregunta(int numJugadorList)
        {
            if (numJugadorList < jugadors.Count)
                FesPreguntaAlJugador(jugadors[numJugadorList]);
            else
                if (fiAccio != null)
                    fiAccio();
        }
        private void FesPreguntaAlJugador(Altres.Jugador jugador)
        {
            string pregunta ="Jugador "+jugador.Nom+ " descarta fins que només tinguis 3 cartes a la mà ";
            partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(Descarta4CartesRivals);
            partida.Pregunta.NumMaxSeleccionades = jugador.Ma.NCartes - 3;
            partida.Pregunta.MinCartesSelecionades = partida.Pregunta.NumMaxSeleccionades;
            partida.Pregunta.FesPregunta(jugador.Ma, pregunta, "El·limina", "", false);
        }


        private void Descarta4CartesRivals(Altres.MaDominion cartes, bool clicatBtn1)
        {
            //Descartar les cartes dels altres jugadors fins que nomes tinguin 3 a la mà

            foreach (CartaDominion carta in cartes)
                if (!carta.Seleccionada) jugadors[numJugadors].Ma.Afegir(carta);
                else jugadors[numJugadors].Pilo.PosarAlCimDeLesDescartades(carta);
            numJugadors++;
            partida.Pregunta.clicBtnEvent -= new Altres.PreguntaEventHandler(Descarta4CartesRivals);
            FesPregunta(numJugadors);
            



        }
    }
}
