using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Prestador
{
    public partial class Prestador : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        dominion.Altres.Partida partida;
        public Prestador()
        {
            InitializeComponent();
            cost = 4;
            imatgeAnvers = dominion.ImatgesCartes.Prestador;
        }

        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            this.partida = partida;
            string pregunta = "El·limina una carta de coure de la teva ma ";
            partida.Pregunta.esDelTipus += new Altres.EsDelTipusEvenHandler(EsTressor);
            partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(EliminaCartaCobre);
            partida.Pregunta.NumMaxSeleccionades = 1;
            partida.Pregunta.FesPregunta(partida.JugadorActual.Ma, pregunta, "El·limina", "No el·limina", true);
        }

        private bool EsTressor(Altres.TipusDeCartes tipus)
        {
            return tipus.Equals(Altres.TipusDeCartes.tressor);
        }

        public void EliminaCartaCobre(Altres.MaDominion cartes, bool clicatBtn1)
        {
            bool esCoure = false;
            int i = 0;
            foreach (CartaDominion c in cartes)
                partida.JugadorActual.Ma.Afegir(c);
            if(clicatBtn1)
            while (!esCoure && i<cartes.NCartes)
            {
                if (cartes[i] is CartaTresor.Coure.Coure)
                {
                    if (cartes[i].Seleccionada)
                    {
                        esCoure = true;
                        partida.JugadorActual.Ma.Elimina(cartes[i]);
                        partida.EliminaCarta(cartes[i]);
                     
                        valor += 3;
                        partida.Jugada.Afegir(this);
                    }

                }
                else
                    if (cartes[i].Seleccionada)
                        cartes[i].Seleccionada = !cartes[i].Seleccionada;
                
                i++;
            }

            partida.Pregunta.esDelTipus -= new Altres.EsDelTipusEvenHandler(EsTressor);
            partida.Pregunta.clicBtnEvent -= EliminaCartaCobre;
            partida.JugadorActual.Ma.RecolocarCartes();
            if (fiAccio != null)
                fiAccio();

        }
    }
}