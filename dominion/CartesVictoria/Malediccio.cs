using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaVictoria.Malediccio
{
    public partial class Malediccio : CartaVictoria
    {
        public Malediccio()
        {
            InitializeComponent();
            cost = 0;
            puntsDeVictoria = -1;
            imatgeAnvers = dominion.ImatgesCartes.Malediccio;
        }
    }
}
