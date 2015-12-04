using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Mercat
{
    public partial class Mercat:CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        public Mercat()
        {
            InitializeComponent();
            cost = 5;
            valor = 1;
            // +1 Accio
            accionsAdicionals++;
            // +1 Compra
            CompresAdicionals++;
            imatgeAnvers = dominion.ImatgesCartes.Mercat;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            //* +1 carta
            partida.JugadorActual.Ma.Afegir(partida.JugadorActual.Pilo.Robar());
            if (fiAccio != null)
                fiAccio();

        }
    }
}
