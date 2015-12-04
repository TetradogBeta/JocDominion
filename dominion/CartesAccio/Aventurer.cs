using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Aventurer
{
    public partial class Aventurer : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        public Aventurer()
        {
            InitializeComponent();
            cost = 6;
            imatgeAnvers = dominion.ImatgesCartes.Aventurer;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            int num = 0;
            /*Lenvanta cartas de tu mazo hasta que descubras 2 Cartas del Tesor.
             * Coloca los Tesoros en tu mano y descarta las demas cartas.*/
            while (num == 2)
            {
                CartaDominion carta = partida.JugadorActual.Pilo.Robar();
                if (carta.EsCartaDeTresor)
                {
                    partida.JugadorActual.Ma.Afegir(carta);
                    num++;
                }
                else
                {
                    partida.JugadorActual.Pilo.PiloDescartades.Posar(carta);
                }
            }
            if (fiAccio != null)
                fiAccio();
        }
    }
}
