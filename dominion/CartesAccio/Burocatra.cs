using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Burocrata
{
    public partial class Burocrata : CartaAccio
    {
        List<dominion.Altres.Jugador> jugadors;
        public event FiExecutaAccio fiAccio;
        dominion.Altres.Partida partida;
        int numJugador;
        public Burocrata()
        {
            InitializeComponent();
            cost = 4;
            imatgeAnvers = dominion.ImatgesCartes.Burocrata;
        }

        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            this.partida = partida;
            partida.JugadorActual.Pilo.PosarAlCimDelPilo(partida.Subministrament[15].Robar());
            partida.Pregunta.TipusEsperat = Altres.TipusDeCartes.victoria;
            jugadors = new List<Altres.Jugador>();
            jugadors.AddRange(partida.Jugadors.Values);
            jugadors.Remove(partida.JugadorActual);
            numJugador = 0;
            MostramCartaVictoria();
        }

        private void MostramCartaVictoria()
        {
            if (numJugador < jugadors.Count)
            {
                if (jugadors[numJugador].Ma.HiHaCartesVictoria)
                    MostraCarta(jugadors[numJugador]);
                else
                    MostraMa(jugadors[numJugador]);
            }
            else
                if (fiAccio != null)
                    fiAccio();
        }

        private void MostraCarta(Altres.Jugador jugador)
        {
            partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(EscullCartaHaMostrar);
            partida.Pregunta.MinCartesSelecionades = 1;
            partida.Pregunta.NumMaxSeleccionades = 1;
            partida.Pregunta.esDelTipus += new Altres.EsDelTipusEvenHandler(EsVictoria);
            partida.Pregunta.FesPregunta(jugador.Ma, "Jugador " + jugador.Nom + " escull la carta de victoria ha mostar", "Mostrar", "", false);
        }

        private bool EsVictoria(Altres.TipusDeCartes tipus)
        {
            return tipus.Equals(Altres.TipusDeCartes.victoria);
        }

        private void EscullCartaHaMostrar(Altres.MaDominion cartes, bool clicatBtn1)
        {//no mira si es de victoria
            CartaDominion cartaAMostar = null;
            foreach (CartaDominion carta in cartes)
            {
                if (carta.Seleccionada)
                    cartaAMostar = carta;
                else
                {
                    if (numJugador == jugadors.Count)
                        numJugador--;
                    jugadors[numJugador].Ma.Afegir(carta);
                }
            }
            partida.hanClicatIMG += new EventHandler(PosarCartaJugador);
            partida.PonerImagen(cartaAMostar);
        }

        private void PosarCartaJugador(object sender, EventArgs e)
        {
            CartaDominion carta = sender as CartaDominion;
            bool acabat = false;
            if (carta != null)
            {
                if (numJugador == jugadors.Count)
                {
                    numJugador--; acabat = true;
                }
                jugadors[numJugador].Pilo.PosarAlCimDeLesDescartades(carta);
            }
            partida.hanClicatIMG -= PosarCartaJugador;
            partida.Pregunta.esDelTipus -= new Altres.EsDelTipusEvenHandler(EsVictoria);
            if (!acabat)
            {
                numJugador++;
                MostramCartaVictoria();
            }
        }

        private void MostraMa(Altres.Jugador jugador)
        {
            partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(HaMostratMa);
            partida.Pregunta.NumMaxSeleccionades = 0;
            partida.Pregunta.FesPregunta(jugador.Ma, "Son les cartes del jugador " + jugador.Nom, "Ok", "", false);
        }

        private void HaMostratMa(Altres.MaDominion cartes, bool clicatBtn1)
        {
            foreach(CartaDominion carta in cartes)
            jugadors[numJugador].Ma.Afegir(carta);
            numJugador++;
            partida.Pregunta.clicBtnEvent -= new Altres.PreguntaEventHandler(HaMostratMa);
            MostramCartaVictoria();
        }
    }
}
