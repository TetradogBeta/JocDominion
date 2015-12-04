using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Festival
{
    public partial class Festival : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        public Festival()
        {
            InitializeComponent();
            cost = 5;
            valor = 2;
            //+2 Accio
            AccionsAdicionals += 2;
            //+1 Compra
            CompresAdicionals++;   
            imatgeAnvers = dominion.ImatgesCartes.Festival;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            if (fiAccio != null)
                fiAccio();
        }
    }
}
