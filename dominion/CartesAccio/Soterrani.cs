using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Soterrani
{
    public partial class Soterrani : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        dominion.Altres.Partida partida;
        public Soterrani()
        {
            InitializeComponent();
            cost = 2;
            imatgeAnvers =dominion.ImatgesCartes.Soterrani;
            accionsAdicionals++;
        }

        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            this.partida = partida;
            string pregunta = "El·limina quantes cartes volguis per cada carta que eliminis robaras una del pilo ";
            partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(DescartaIRoba);
            partida.Pregunta.NumMaxSeleccionades = partida.JugadorActual.Ma.NCartes;
            partida.Pregunta.FesPregunta(partida.JugadorActual.Ma, pregunta, "Elimina", "", false);
        }

        public void DescartaIRoba(Altres.MaDominion cartes, bool clicatBtn1)
        {
            //+1 accio
           

            //Descartar les cartes que volgui i per cada descartada robar una carta

            foreach (CartaDominion c in cartes)
                partida.JugadorActual.Ma.Afegir(c);

            int seleccionades=0;
            for (int i = 0; i < cartes.NCartes; i++)
            {
                if (cartes[i].Seleccionada)
                {
                    partida.EliminaCarta(cartes[i]);
                    seleccionades++;
                    partida.JugadorActual.Ma.Elimina(cartes[i]);
                }
            }

            //ROBA EL Nº CARTES SELECCIONADES
            if (seleccionades != 0)
            {
                for(int i=0;i<seleccionades;i++)
                    partida.JugadorActual.Ma.Afegir(partida.JugadorActual.Pilo.Robar());
            }

            partida.Pregunta.clicBtnEvent -= DescartaIRoba;
          //  partida.JugadorActual.Ma.RecolocarCartes();
            if (fiAccio != null)
                fiAccio();
        }
    }
}
