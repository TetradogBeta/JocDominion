using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominion.Altres;

namespace dominion.CartaAccio.Espia
{
    public partial class Espia : CartaAccio/*accio-atac*/
    {
        public event FiExecutaAccio fiAccio;
        List<Jugador> jugadors;
        Partida partida;
        int numJugador;
        public Espia()
        {
            InitializeComponent();
            cost = 4;
            imatgeAnvers = dominion.ImatgesCartes.Espia;
            
            
        }         
        /// <summary>
        /// Cada jugador inclos el propi revela la carta superor de el seu mazo 
        /// i tu decideixes si la descarta o la tornes el seu lloc 
        /// El jugador que tira aquesta carta, li desapareix el mazo i paraeixen la primera carta
        /// del mazo de cada jugador(inclus propia) i selecciona quina descarta i quina torna el seu propietari
        /// </summary>
        /// <param name="partida"></param>
        public override void ExecutaAccio(Partida partida)
        {
            this.partida = partida;
            AccionsAdicionals++;
            partida.JugadorActual.Ma.Afegir(partida.JugadorActual.Pilo.Robar());
            jugadors = new List<Jugador>();
            jugadors.AddRange(partida.Jugadors.Values);
            numJugador = 0;
            partida.Pregunta.NumMaxSeleccionades = 0;
            partida.Pregunta.clicBtnEvent += new PreguntaEventHandler(HaEspiat);
            EspiaJugador(numJugador);


        }

        private void HaEspiat(MaDominion cartes, bool clicatBtn1)
        {
            if (clicatBtn1)
                jugadors[numJugador].Pilo.PosarAlCimDeLesDescartades(cartes[0]);
            else
                jugadors[numJugador].Pilo.PosarAlCimDelPilo(cartes[0]);
            numJugador++;
            EspiaJugador(numJugador);
        }
        public void EspiaJugador(int jugador)
        {
            if (jugador < jugadors.Count)
            {
                Espiar(jugadors[jugador]);
            }
            else
            {
                partida.Pregunta.clicBtnEvent -= new PreguntaEventHandler(HaEspiat);
                if (fiAccio != null)
                    fiAccio();
            }
        }

        private void Espiar(Jugador jugador)
        {
            string pregunta = "Que vols fer amb la carta de "+jugador.Nom+"?";
            MaDominion maCartaEspiada = new MaDominion();
            maCartaEspiada.Afegir(jugador.Pilo.Robar());
            partida.Pregunta.FesPregunta(maCartaEspiada, pregunta, "Posar al pilo DESCARTADES", "Tornar al seu lloc", true);
        }
    }
}