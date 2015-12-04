using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Mina
{
    public partial class Mina : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        dominion.Altres.Partida partida;
        public Mina()
        {
            InitializeComponent();
            cost = 5;
            imatgeAnvers = dominion.ImatgesCartes.Mina;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            this.partida = partida;
            if (partida.JugadorActual.Ma.HiHaCartesTresor)
            {
                string pregunta = "El·limina una carta de tresor";
                partida.Pregunta.esDelTipus += new Altres.EsDelTipusEvenHandler(esTressor);
                partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(EliminaCartaTesoro);
                partida.Pregunta.NumMaxSeleccionades = 1;
                partida.Pregunta.FesPregunta(partida.JugadorActual.Ma, pregunta, "Elimina", "", false);
            }
        }

        private bool esTressor(Altres.TipusDeCartes tipus)
        {
            return tipus.Equals(Altres.TipusDeCartes.tressor);
        }

        public void EliminaCartaTesoro(Altres.MaDominion cartes, bool clicatBtn1)
        {
            //Haig d'eliminar un carta de tesoro de la meva ma
            foreach (CartaDominion c in cartes)
                partida.JugadorActual.Ma.Afegir(c);
            int i = 0;
            bool trobat = false;
          
               
                while (!trobat && i < cartes.NCartes)
                {
                    if (cartes[i].Seleccionada && cartes[i] is CartaTresor.CartaTresor)
                    {
                        partida.EliminaCarta(cartes[i]);
                        trobat = true;
                        partida.JugadorActual.Ma.Elimina(cartes[i]);
                    }
                }
                i++;
           
            // i ganyar una de valor 3
            if (trobat)
            {
                partida.HabilitaRegal(3);
                partida.Subministrament.clicRegal += new EventHandler(HagafaCartaPiloDescartades);
                //FALTA QUE LA CARTA GANADA VAYA DIRECTAMENTE A LA MANO
            }

            partida.Pregunta.clicBtnEvent -= EliminaCartaTesoro;
            partida.Pregunta.esDelTipus -= new Altres.EsDelTipusEvenHandler(esTressor);
 

        }

        private void HagafaCartaPiloDescartades(object sender, EventArgs e)
        {
            partida.JugadorActual.Ma.Afegir(partida.JugadorActual.Pilo.PiloDescartades.Robar());
            partida.JugadorActual.Ma.RecolocarCartes();
            partida.Subministrament.clicRegal -= new EventHandler(HagafaCartaPiloDescartades);
            if (fiAccio != null)
                fiAccio();
        }
    }
}
