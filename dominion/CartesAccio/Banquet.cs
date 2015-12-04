using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Banquet
{
    public partial class Banquet : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        public Banquet()
        {
            InitializeComponent();
            cost = 4;
            imatgeAnvers = dominion.ImatgesCartes.Banquet;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            //eliminar aquesta carta i guanya una carta amb un maxim de cost 5
            partida.JugadorActual.Pilo.PiloDescartades.Posar(this);
            if (partida.JugadorActual.Pilo.Robar().Cost <= 5)
            {
                partida.JugadorActual.Ma.Afegir(partida.JugadorActual.Pilo.Robar());
            }
            else
            {
                partida.JugadorActual.Pilo.PiloDescartades.Posar(partida.JugadorActual.Pilo.Robar());
            }
            if (fiAccio != null)
                fiAccio();
        }
    }
}
