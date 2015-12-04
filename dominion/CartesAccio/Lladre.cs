using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio.Lladre
{
    public partial class Lladre : CartaAccio/*Acció-Atac*/
    {
        dominion.Altres.MaDominion maRobada;
        dominion.Altres.Partida partida;
        List<KeyValuePair<string, dominion.Altres.MaDominion>> cartesJugadors = new List<KeyValuePair<string, dominion.Altres.MaDominion>>();
        List<int> jugadors=new List<int>();
        int jugador=0;
        public event FiExecutaAccio fiAccio;
        public Lladre()
        {
            InitializeComponent();
            cost = 4;
            imatgeAnvers = dominion.ImatgesCartes.Lladre;
        }
        public override void ExecutaAccio(dominion.Altres.Partida partida)
        { 
            /*Cada jugador(menys propi) revela les 2 cartes superiors del seu mazo 
             * i elimina una carta del tresor que ja estigui revelada(elecció propia)
             * 
             * Pots guanyar els Tresors eliminats que volguis. Les altres cartes revelades es descarten*/
         
            this.partida = partida;
            maRobada = new Altres.MaDominion();
            cartesJugadors = new List<KeyValuePair<string, Altres.MaDominion>>();
            jugadors = new List<int>();
            for(int i =0;i<partida.NumJugadors;i++)
                if (partida.Jugadors[i].Nom != partida.NomJugadorActual)
                {
                    jugadors.Add(i);
                    dominion.Altres.MaDominion ma = new Altres.MaDominion();
                    ma.Afegir(partida.Jugadors[i].Pilo.Robar());
                    ma.Afegir(partida.Jugadors[i].Pilo.Robar());
                    string nom = partida.Jugadors[i].Nom;
                    cartesJugadors.Add(new KeyValuePair<string, dominion.Altres.MaDominion>(nom,ma));
                }
           partida.Pregunta.clicBtnEvent += new Altres.PreguntaEventHandler(RobarCartes);
           clicElimina( new object(),  new EventArgs());
           
        }

private void clicElimina(object sender, EventArgs e)
{
    if(jugador<cartesJugadors.Count)
    {
      
        EnsenyarCarta(cartesJugadors[jugador]);
       
    }
    jugador++;
    if(jugador==cartesJugadors.Count+1)
        if(maRobada.NCartes>0)
        {
            partida.Pregunta.NumMaxSeleccionades=maRobada.NCartes;
            partida.Pregunta.clicBtnEvent-=RobarCartes;
            partida.Pregunta.NumMaxSeleccionades=maRobada.NCartes;
            partida.Pregunta.clicBtnEvent+=new Altres.PreguntaEventHandler(AgafaCartes);
            partida.Pregunta.FesPregunta(maRobada,"Quines vols?","Robar","",false);
       
        }
}

private void AgafaCartes(Altres.MaDominion cartes, bool clicatBtn1)
{
 	foreach(CartaDominion cartaR in cartes)
    {
        if(cartaR.Seleccionada)
        partida.JugadorActual.Ma.Afegir(cartaR);
        else
            partida.EliminaCarta(cartaR);
        partida.Pregunta.clicBtnEvent -= AgafaCartes;
        if (fiAccio != null)
            fiAccio();
       
    }
}



        private void RobarCartes(Altres.MaDominion cartes, bool clicatBtn1)
        {
            foreach (CartaDominion cartaR in cartes)
                if (cartaR.Seleccionada && cartaR.EsCartaDeTresor)
                    maRobada.Afegir(cartaR);
                else
                partida.Jugadors[jugadors[jugador-1]].Pilo.PosarAlCimDeLesDescartades(cartaR);
           
              clicElimina( new object(),  new EventArgs());

        }
        private void EnsenyarCarta(KeyValuePair<string, dominion.Altres.MaDominion> jugadors)
        {
           
            
                if (jugadors.Value.HiHaCartesTresor)
                {
                    string pregunta = "Vols robar una carta de tresor del jugador " + jugadors.Key;
                    partida.Pregunta.NumMaxSeleccionades = 1;
                    partida.Pregunta.FesPregunta(jugadors.Value, pregunta, "Robar", "", false);
                }
            }
        }
    }

