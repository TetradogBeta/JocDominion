using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaVictoria.Ducat
{
    public partial class Ducat : CartaVictoria
    {
        public Ducat()
        {
            InitializeComponent();
            valor = 0;
            cost = 5;
            puntsDeVictoria = 3;
            imatgeAnvers = dominion.ImatgesCartes.Ducat;
        }
    }
}
