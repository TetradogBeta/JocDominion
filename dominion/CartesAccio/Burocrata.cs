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
        public Burocrata()
        {
            InitializeComponent();
            cost = 4;
            imatgeAnvers = dominion.ImatgesCartes.Burocrata;
        }

        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            
        }
    }
}
