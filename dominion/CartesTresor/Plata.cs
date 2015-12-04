using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaTresor.Plata
{
    public partial class Plata : CartaTresor
    {
        public Plata()
        {
            InitializeComponent();
            cost = 3;
            valor = 2;
            imatgeAnvers = dominion.ImatgesCartes.Plata;
        }
    }
}
