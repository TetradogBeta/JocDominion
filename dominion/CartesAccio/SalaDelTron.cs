using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.SalaDelTron
{
    public partial class SalaDelTron : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        dominion.CartaAccio.CartaAccio cAccio;
        dominion.Altres.Partida partida;
        public SalaDelTron()
        {
            cost = 4;
            InitializeComponent();
            imatgeAnvers = dominion.ImatgesCartes.SaloDelTron;

        }

        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
             this.partida = partida;
           if (partida.JugadorActual.Ma.HiHaCartesAccio)
            {
           
            string pregunta = "Tria una carta de accio";
            partida.Pregunta.esDelTipus += new Altres.EsDelTipusEvenHandler(EsAccio);
            partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(JugaAccioDosVegades);
            partida.Pregunta.NumMaxSeleccionades = 1;
            partida.Pregunta.FesPregunta(partida.JugadorActual.Ma, pregunta, "Tria", "", false);
           }
        }

        private bool EsAccio(Altres.TipusDeCartes tipus)
        {
            return tipus.Equals(Altres.TipusDeCartes.accio);
        }

        public void JugaAccioDosVegades(Altres.MaDominion cartes, bool clicatBtn1)
        {
            bool esAccio = false;
            int i=0;
            foreach (CartaDominion c in cartes)
                partida.JugadorActual.Ma.Afegir(c);

            
                while (!esAccio && i < cartes.NCartes)
                {
                    if (cartes[i] is CartaAccio)
                    {
                        if (cartes[i].Seleccionada)
                        {
                            esAccio = true;
                            cAccio = (CartaAccio)cartes[i];
                            cAccio.fiAccio += new FiExecutaAccio(SegonaExecucio);
                            cAccio.ExecutaAccio(partida);
                        }

                    }
                    else
                        if (cartes[i].Seleccionada)
                            cartes[i].Seleccionada = !cartes[i].Seleccionada;

                    i++;
                }
            
    

            partida.Pregunta.clicBtnEvent -= JugaAccioDosVegades;
            partida.Pregunta.esDelTipus -= new Altres.EsDelTipusEvenHandler(EsAccio);
            partida.JugadorActual.Ma.RecolocarCartes();
        }

        private void SegonaExecucio()
        {
            cAccio.fiAccio -= SegonaExecucio;
            cAccio.fiAccio += new FiExecutaAccio(Acabat);
            cAccio.ExecutaAccio(partida);
         
        
           
        }

        private void Acabat()
        {
            if (fiAccio != null)
                fiAccio();
        }


    }
}
