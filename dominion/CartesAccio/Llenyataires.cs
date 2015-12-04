using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Llenyataires
{
    public partial class Llenyataires : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        public Llenyataires()
        {
            InitializeComponent();
            cost = 3;
            valor = 2;
            //+1 Compra
            CompresAdicionals++;
            imatgeAnvers = dominion.ImatgesCartes.Llenyataires;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            if (fiAccio != null) 
            fiAccio();
        }
    }
}
