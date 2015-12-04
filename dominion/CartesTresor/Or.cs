using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaTresor.Or
{
    public partial class Or : CartaTresor
    {
        public Or()
        {
            InitializeComponent();
            cost = 6;
            valor = 3;
            imatgeAnvers = dominion.ImatgesCartes.Or;
        }
    }
}
