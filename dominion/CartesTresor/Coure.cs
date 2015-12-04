using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaTresor.Coure
{
    public partial class Coure : CartaTresor
    {
        public Coure()
        {
            InitializeComponent();
            cost = 0;
            valor = 1;
            imatgeAnvers = dominion.ImatgesCartes.Coure;
       
        }
    }
}
