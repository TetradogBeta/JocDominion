using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Fossat
{
    public partial class Fossat : CartaAccio/*Acció-Reacció*/
    {
        public event FiExecutaAccio fiAccio;
        public Fossat()
        {
            InitializeComponent();
            cost = 2;
            imatgeAnvers = dominion.ImatgesCartes.Fossat;
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
        public override bool EsCartaReaccio
        {
            get
            {
                return true;
            }
        }
    }
}
