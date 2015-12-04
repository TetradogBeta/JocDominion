using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Aldea
{
    public partial class Aldea : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        public Aldea()
        {
            InitializeComponent();
            cost = 3;
            AccionsAdicionals += 2;
            imatgeAnvers = dominion.ImatgesCartes.Aldea;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            partida.JugadorActual.Ma.Afegir(partida.JugadorActual.Pilo.Robar());
            if (fiAccio != null)
                fiAccio();
       
        }
    }
}
