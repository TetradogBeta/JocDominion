using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Bruixa
{
    public partial class Bruixa : CartaAccio
    {
        dominion.Altres.Partida partida;
        public event FiExecutaAccio fiAccio;
        public Bruixa()
        {
            InitializeComponent();
            cost = 5;
            imatgeAnvers = dominion.ImatgesCartes.Bruixa;
        }

        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            this.partida = partida;
            RegalaDosMalediccions(partida);
        }


        public void RegalaDosMalediccions(dominion.Altres.Partida partida)
        {
            //+2 Cartes
            partida.JugadorActual.Ma.Afegir(partida.JugadorActual.Pilo.Robar());
            partida.JugadorActual.Ma.Afegir(partida.JugadorActual.Pilo.Robar());
           
            //Cada Jugador Rival guanya UNA malediccions
            foreach (Altres.Jugador j in partida.Jugadors.Values)
            {
                if ((j!=partida.JugadorActual) && !(j.Ma.HiHaCartesReaccio))
                {
                    j.Ma.Afegir(partida.Subministrament[3].Robar());
                
                }
            }
            if (fiAccio != null)
                fiAccio();
        }
    }
}
