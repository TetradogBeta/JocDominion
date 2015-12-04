using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Biblioteca
{
    public partial class Biblioteca : CartaAccio
    {
        public event FiExecutaAccio fiAccio;
        dominion.Altres.Partida partida;
        public Biblioteca()
        {
            InitializeComponent();
            cost = 5;
            imatgeAnvers = dominion.ImatgesCartes.Biblioteca;
        }

        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            this.partida = partida;
            bool trobat = false;
            CartaDominion carta=null;
            while (partida.JugadorActual.Ma.NCartes < 7&&!trobat)
            {
               carta = partida.JugadorActual.Pilo.Robar();
                if (carta.EsCartaDeAccio)
                    trobat = true;
                else
                    partida.JugadorActual.Ma.Afegir(carta);
            }
            if(trobat)
                FesPreguntaSiLaVol(carta);
            if (partida.JugadorActual.Ma.NCartes >= 7)
                if (fiAccio != null)
                    fiAccio();
        }

        private void FesPreguntaSiLaVol(CartaDominion carta)
        {
            dominion.Altres.MaDominion cartaP=new Altres.MaDominion();
            cartaP.Afegir(carta);
            partida.Pregunta.FesPregunta(cartaP, "La vols?", "Si", "No", true);
            partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(HaDecidit);
        }

        private void HaDecidit(Altres.MaDominion cartes, bool clicatBtn1)
        {
            if (clicatBtn1)
                partida.JugadorActual.Ma.Afegir(cartes[0]);
            else
                partida.JugadorActual.Pilo.PosarAlCimDeLesDescartades(cartes[0]);
            partida.Pregunta.clicBtnEvent -= new Altres.PreguntaEventHandler(HaDecidit);
            ExecutaAccio(partida);
        }
    }
}
