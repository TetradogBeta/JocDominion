using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaVictoria.Provincia
{
    public partial class Provincia : CartaVictoria
    {
        public Provincia()
        {
            InitializeComponent();
            cost = 8;
            puntsDeVictoria = 6;
            imatgeAnvers = dominion.ImatgesCartes.Provincia;
        }
    }
}
