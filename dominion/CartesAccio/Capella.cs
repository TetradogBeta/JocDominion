using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Capella
{
    public partial class Capella : CartaAccio
    {
        dominion.Altres.Partida partida;
        public event FiExecutaAccio fiAccio;
        public Capella()
        {
            InitializeComponent();
            cost = 2;
            valor = 0;
            imatgeAnvers = dominion.ImatgesCartes.Capella;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        {
            this.partida = partida;
            string pregunta = "Selecciona fins a 4 cartes per eliminar";
            partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(EliminaCartes);
            partida.Pregunta.NumMaxSeleccionades = 4;
            partida.Pregunta.FesPregunta(partida.JugadorActual.Ma, pregunta, "Elimina", "", false);
      
        }

        private void EliminaCartes(Altres.MaDominion cartes, bool clicatBtn1)
        {

           
            
           
                List<CartaDominion> cartesMa = new List<CartaDominion>();
                for (int i = 0; i < cartes.NCartes; i++)
                {
                    CartaDominion carta = cartes[i];
                    if (carta.Seleccionada)
                    {
                     
                        partida.EliminaCarta(carta);
                    }
                    else
                        partida.JugadorActual.Ma.Afegir(carta);
                }
        
                partida.Pregunta.clicBtnEvent -= EliminaCartes;
                partida.JugadorActual.Ma.RecolocarCartes();
                if (fiAccio != null)
                    fiAccio();
              
            
           
        }

      

    }
}
