using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Laboratori
{
    public partial class Laboratori : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        public Laboratori()
        {
            InitializeComponent();
            cost = 5;
            // +1 Acció
            AccionsAdicionals++;
            imatgeAnvers = dominion.ImatgesCartes.Laboratori;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            // + 2 cartes
            for (int i = 0; i < 2; i++)
            {
                partida.JugadorActual.Ma.Afegir(partida.JugadorActual.Pilo.Robar());
            }
            if (fiAccio != null)
                fiAccio();
      
            
            
        }
    }
}
