using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Enviat
{
    public partial class Enviat : CartaAccio
    {
        dominion.Altres.Partida partida;
        public event FiExecutaAccio fiAccio;
        public Enviat()
        {
            InitializeComponent();
            cost = 4;
            imatgeAnvers = dominion.ImatgesCartes.Enviat;

        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            this.partida = partida;
            partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(PosaCartes);
 	      DescubrirCartas(partida);
        
        }
        private void DescubrirCartas(dominion.Altres.Partida partida)
        {
            PiloJugador mazoJugador = partida.JugadorActual.Pilo;
            List<CartaDominion> cartes = mazoJugador.Robar(5);
            EscollirUnaDeCinc(cartes);
            

        }
        private void EscollirUnaDeCinc(List<CartaDominion> cartes)
        {
            dominion.Altres.MaDominion ma = new Altres.MaDominion();
            for (int i = 0; i < cartes.Count; i++)
                ma.Afegir(cartes.ElementAt(i));
            partida.Pregunta.NumMaxSeleccionades = 1;
                partida.Pregunta.FesPregunta(ma, "Jugador " + partida.NomJugadorEsquerra + " escull una carta per posar al pilo de descartades i les altres van a la ma", "Posar al pilo descartades", "", false);
           
        }

        private void PosaCartes(Altres.MaDominion cartes, bool clicatBtn1)
        {
            
                foreach (CartaDominion carta in cartes)
                    if (carta.Seleccionada)
                        partida.JugadorActual.Pilo.PosarAlCimDeLesDescartades(carta);
                    else
                        partida.JugadorActual.Ma.Afegir(carta);
         
       
            partida.Pregunta.clicBtnEvent -= PosaCartes;
            partida.JugadorActual.Ma.RecolocarCartes();
            partida.JugadorActual.Ma.OrdenaMa();
            if (fiAccio != null)
                fiAccio();
        }
    

    }
}
