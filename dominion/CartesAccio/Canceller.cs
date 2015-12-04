using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Canceller
{
    public partial class Canceller : CartaAccio
    {
       dominion.Altres.Partida partida;
       public event FiExecutaAccio fiAccio;
        public Canceller()
        {
            InitializeComponent();
            cost = 3;
            valor = 2;
            imatgeAnvers = dominion.ImatgesCartes.Canceller;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            this.partida = partida;
            string pregunta="Pots posar inmediatament el teu MAZO el la teva pila de descartades";
            partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(RespostaPregunta);
            partida.Pregunta.FesPregunta(null, pregunta, "Posar", "No posar", true);
           
        }

        private void RespostaPregunta(Altres.MaDominion cartes, bool clicatBtn1)
        {
            if (clicatBtn1)
                while(!partida.JugadorActual.Pilo.PiloPerRobar.Buida)
                partida.JugadorActual.Pilo.PosarAlCimDeLesDescartades(partida.JugadorActual.Pilo.PiloPerRobar.Robar());
      
            partida.Pregunta.clicBtnEvent -= RespostaPregunta;
            if (fiAccio != null)
                fiAccio();

        }


    }
}
