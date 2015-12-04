using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaVictoria.Finca
{
    public partial class Finca : CartaVictoria
    {
        public Finca()
        {
            InitializeComponent();
            puntsDeVictoria = 1;
            cost = 2;
            imatgeAnvers = dominion.ImatgesCartes.Finca;
        }
    }
}
