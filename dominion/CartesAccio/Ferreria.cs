using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Ferreria
{
    public partial class Ferreria : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        public Ferreria()
        {
            InitializeComponent();
            cost = 4;
            imatgeAnvers = dominion.ImatgesCartes.Ferreria;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            //Robar  3 cartes del mazo cap a la ma
            for (int i = 0; i < 3; i++)
            {
                partida.JugadorActual.Ma.Afegir(partida.JugadorActual.Pilo.Robar());
            }
            if (fiAccio != null)
                fiAccio();
           
        }
    }
}
