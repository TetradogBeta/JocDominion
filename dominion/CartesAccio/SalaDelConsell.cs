using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.SalaDelConsell
{
    public partial class SalaDelConsell : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        public SalaDelConsell()
        {
            cost = 5;
            InitializeComponent();
            imatgeAnvers = dominion.ImatgesCartes.SalaDelConsell;
            // +1 compra
            CompresAdicionals++;
        }

        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            // + 4 cartes
            for (int i = 0; i < 4; i++)
            {
                partida.JugadorActual.Ma.Afegir(partida.JugadorActual.Pilo.Robar());
            }

          

            //Els altres jugadors roban una carta
            foreach (Altres.Jugador j in partida.Jugadors.Values)
            {
                if (j!=partida.JugadorActual)
                {
                    j.Ma.Afegir(j.Pilo.Robar());
                }

            }

        }
    }
}
