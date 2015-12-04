using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Remodelar
{
    public partial class Remodelar : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        dominion.Altres.Partida partida;
        public Remodelar()
        {
            cost = 4;
            InitializeComponent();
            imatgeAnvers = dominion.ImatgesCartes.Remodelar;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            this.partida = partida;
            string pregunta = "El·limina una carta de la teva mà si ho fas tindràs un regal del valor que tingui la carta +2";
            partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(EliminarCartaMano);
            partida.Pregunta.NumMaxSeleccionades = 1;
            partida.Pregunta.FesPregunta(partida.JugadorActual.Ma, pregunta, "Elimina", "", false);
    
        }


        public void EliminarCartaMano(Altres.MaDominion cartes, bool clicatBtn1)
        {
            //Despres d'eliminar, ganyaes una carta que costi 2 més que la carta eliminada
            foreach (CartaDominion c in cartes)
                partida.JugadorActual.Ma.Afegir(c);

            int i=0;
            bool trobat=false;
            int valor=0;
            while(!trobat && i<cartes.NCartes)
            {
                if (cartes[i].Seleccionada)
                {
                    partida.EliminaCarta(cartes[i]);
                    partida.JugadorActual.Ma.Elimina(cartes[i]);
                    valor=cartes[i].Cost;
                    trobat = true;
                }
                i++;
            }
            if (trobat)
            {
                partida.HabilitaRegal(valor + 2);
                partida.Subministrament.clicRegal += new EventHandler(HanHagafatRegal);
            }
            partida.Pregunta.clicBtnEvent -= EliminarCartaMano;
            partida.JugadorActual.Ma.RecolocarCartes();
        }

        private void HanHagafatRegal(object sender, EventArgs e)
        {
            partida.DeshabilitaRegal();
            partida.Subministrament.clicRegal -= new EventHandler(HanHagafatRegal);
            if (fiAccio != null)
                fiAccio();
        }
    }
}
