using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaVictoria.Jardins
{
    public partial class Jardins : CartaVictoria
    {
        public Jardins()
        {
            InitializeComponent();
            cost = 4;
            imatgeAnvers = dominion.ImatgesCartes.Jardins;
        }
        //public int PuntsDeVictoria()
        //{
        //    //conta la de jardins??
        //    return 0;
        //}
    }
}
