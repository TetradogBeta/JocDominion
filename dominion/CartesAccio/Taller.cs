using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Taller
{
    public partial class Taller : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        dominion.Altres.Partida partida;
        public Taller()
        {
            InitializeComponent();
            cost = 3;
            imatgeAnvers = dominion.ImatgesCartes.Taller;
        }

        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            this.partida = partida;
            GanaUnaCarta(partida);
            
        }

        public void GanaUnaCarta(dominion.Altres.Partida partida)
        {
           partida.HabilitaRegal(4);
           partida.Subministrament.clicRegal += new EventHandler(HanHagafatElRegal);
    
            
        }

        private void HanHagafatElRegal(object sender, EventArgs e)
        {
            partida.DeshabilitaRegal();
            partida.Subministrament.clicRegal -= new EventHandler(HanHagafatElRegal);
            if (fiAccio != null)
                fiAccio();
        }
    }
}
