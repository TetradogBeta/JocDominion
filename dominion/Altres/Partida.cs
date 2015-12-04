using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.Altres
{//enviat,canceller,capella
    public enum TipusSubministraments
    {
        Aldea, Aventurer, Banquet, Biblioteca, Bruixa, Burocrata, Canceller, Capella,
        Enviat, Espia, Ferreria, Festival, Fossat, Laboratori, Lladre, Llenyataires,
        Mercat, Milicia, Mina, Prestador, Remodelar, SalaDelTron, SalaDelConsell, Soterrani, Taller, Jardins
    }
    public enum TipusMazo { PrimerJoc, BigMoney, Interaccio, MidaDistorsio, VillageSquare }

    public enum PrimerJoc { Celler, Mercat, Milicia, Mina, Fossat, Remodelar, Ferreria, Aldea, Llenyataires, Prestador }
    public enum BigMoney { Aventurer, Burocrata, Canceller, Capella, Festival, Laboratori, Mercat, Mina, Prestador, SalaDelTron }
    public enum Interaccio { Burocrata, Canceller, SalaDelConsell, Festival, Biblioteca, Milicia, Fossat, Espia, Lladre, Aldea }
    public enum MidaDistorsio { Soterrani, Capella, Festival, Jardins, Laboratori, Lladre, Aldea, Bruixa, Llenyataires, Prestador }
    public enum VillageSquare { Burocrata, Soterrani, Festival, Biblioteca, Mercat, Remodelar, Ferreria, SalaDelTron, Aldea, Llenyataires }
 
    public partial class Partida : UserControl
    {
        Panel piloM;
        Panel panellJugadors;
        MostraPilo mostraPilo;
        PiloDominion piloEliminades;
        Jugada piloJugada;
        public event EventHandler hanClicatIMG;
        
        Pregunta pregunta;
        Subministrament pilonsSubministrament;

        public Subministrament Subministrament
        {
            get { return pilonsSubministrament; }
        
        }
        string[] nomJugadors;
        Button btnFinal;
        Label lblNomJugador;
        Panel pnlMostraCarta;
        Random rnd = new Random();
        Dictionary<int, Jugador> jugadors;
        int torn;
        Label nomJugadorIFase;
        int contadorSelecciona = 0;//per fer proves
        public Partida()
        {
            InitializeComponent();
            mostraPilo = new MostraPilo();
            Controls.Add(mostraPilo);
            BackColor = Color.Transparent;
            jugadors = new Dictionary<int, Jugador>();
            panellJugadors = new Panel();
            pilonsSubministrament = new Subministrament();
            piloEliminades = new PiloDominion(ImatgesCartes.Eliminades);
            piloJugada = new Jugada();
            piloJugada.PercentMarge = 30;
            pregunta = new Pregunta();
            Controls.Add(pregunta);
            btnFinal = new Button();
            btnFinal.Click += new EventHandler(btnFinal_Click);
            lblNomJugador = new Label();
            pnlMostraCarta = new Panel();
            Button fiDeTorn = new Button();
            btnFinal.Text = "Finalitza fase";
            nomJugadorIFase = new Label();
            Controls.Add(nomJugadorIFase);
            fiDeTorn.Click += new EventHandler(acabaElTorn);
            foreach (PiloSubministrament pilo in pilonsSubministrament)
            {
                pilo.compra.Click += new EventHandler(Compra);
                pilo.regal.Click += new EventHandler(regal);
                pilo.Click += new EventHandler(MostraPilo_Click);
            }
            Controls.Add(panellJugadors);
            Controls.Add(pilonsSubministrament);
            Controls.Add(piloEliminades);
            Controls.Add(piloJugada);
            Controls.Add(btnFinal);
            Controls.Add(lblNomJugador);
            Controls.Add(pnlMostraCarta);

            piloM = new Panel();
         //   DoubleBuffered = true;//posat
            piloM.Click += new EventHandler(pnlMostraCarta_Click);
            Controls.Add(piloM);
            piloM.BackgroundImageLayout = ImageLayout.Stretch;
        
        }

        private void acabaElTorn(object sender, EventArgs e)
        {
            Fases faseActual = piloJugada.Desempila();
            nomJugadorIFase.Text = NomJugadorActual + "-Fase-" + faseActual.ToString();
            RealitzaFase(faseActual);
        }
        public Jugada Jugada
        {
            get { return piloJugada; }

        }
        private void Repartir()
        {
        //les cartes de finca les crea pero les de coure les agafa del pilo...
            int numFinca=3;
            int numCoure=7;
            for (int i = 0; i < NumJugadors; i++)
            {
                for (int j = 0; j < numFinca; j++)
                {
                    CartaDominion carta = CartaDominion.DonamCarta("Finca");
                    carta.CaraAmunt = false;
                    jugadors[i].Pilo.PiloDescartades.Posar(carta);
                 
                }
            
             
               
            for (int j = 0; j < numCoure; j++)
			{
                CartaDominion carta = pilonsSubministrament[14].Robar();
                carta.CaraAmunt = false;
                jugadors[i].Pilo.PiloDescartades.Posar(carta);
			}
            jugadors[i].Ma.Animacio = false;
            jugadors[i].Ma.Neteja();
            for (int k = 0; k < 5; k++)
            {
                CartaDominion cartaMa = jugadors[i].Pilo.Robar();

                if (cartaMa != null)
                {

                    jugadors[i].Ma.Afegir(cartaMa);
                }

            }
            jugadors[i].Ma.Animacio = true;
            jugadors[i].Ma.OrdenaMa();
            jugadors[i].Ma.RecolocarCartes();
            }
        
        }
        private void btnFinal_Click(object sender, EventArgs e)
        {
     
            
            Fases faseActual = piloJugada.Desempila();
            nomJugadorIFase.Text = NomJugadorActual + "-Fase-" + faseActual.ToString();
            RealitzaFase(faseActual);
        }

        private void RealitzaFase(Fases fases)
        {
            /*
             * Si la és d'acció: Mira si la del jugador conté
             * cartes d'acció i les selecciona, 
             * sinó, fa un final d'acció Si la és de compra: 
             * Mira si la del jugador conté cartes de tresor
             * i les selecciona, sinó, no fa un final d'acció
             * perqué sempre pot comprar cartes de cost zero 
             * Si la és de manteniment: Fa el manteniment de 
             * la del jugador i espera a que el jugador doni 
             * el torn per finalitzat.

             */
        
            switch (fases)
            {
                case Fases.Accio:DeseleccionaCartes(); SeleccionaAccions();  break;//espera si en té, sino acaba la fase
                case Fases.Compra: DeseleccionaCartes(); SeleccionaTresors(); MiraSiHaAcabat(); break;//espera a que fasin algu...;
                case Fases.Manteniment: Manteniment(); break;//espera a que l'usuari li doni a fi de fase;
            }
        }
        private void ConfiguraJugadors(string[] nomJugadors)
        {
            this.nomJugadors = nomJugadors;
  
            for (int i = 0; i <nomJugadors.Length; i++)
            {
                jugadors.Add(i, new Jugador());
                jugadors[i].Nom = nomJugadors[i];
                jugadors[i].Location = new Point(0, 0);
                jugadors[i].Visible = false;
                jugadors[i].Dock = DockStyle.Left;
            
                panellJugadors.Controls.Add(jugadors[i]);
                jugadors[i].PercentMarge = 20;

            }

        }
        #region Propietats
        public Pregunta Pregunta
        { get { return pregunta; } }
        public bool FinalPartida
        { get { return MiraSiHaAcabat(); } }
        public Jugador JugadorActual
        { get { return jugadors[torn]; } }
        public Dictionary<int, Jugador> Jugadors
        { get { return jugadors; } }
        public string NomJugadorActual
        { get { return JugadorActual.Nom; } }
        public int NumJugadors
        { get { return jugadors.Count; } }
        
        #endregion
        internal void EliminaCarta(CartaDominion carta)
        {
            carta.CaraAmunt = true;
            piloEliminades.Posar(carta);
        }
        private bool MiraSiHaAcabat()
        {

            bool acabat = false;
            if (pilonsSubministrament[2].NCartes == 0)
                acabat = true;
            else
            {
                int numDePilonsAcabats=0;
                int i = 0;
                while (i < pilonsSubministrament.Count && !acabat)
                {
                    if (pilonsSubministrament[i].NCartes == 0)
                        numDePilonsAcabats++;
                    if (numDePilonsAcabats == 3)
                        acabat = true;
                    i++;
                    if (i == 2)
                        i++;
                }
            }
            return acabat;
        }
        private void SortejaTorn()
        {
            torn = rnd.Next(0, NumJugadors);
            AvançaTorn();

        }
        public string NomJugadorEsquerra
        {
            get { return jugadors[DonamJugador(true)].Nom; }
        }
        public string NomJugadorDreta
        {
            get { return jugadors[DonamJugador(false)].Nom; }
        }
        private int DonamJugador(bool esquerra)
        {
            
            if (esquerra)
            {
                if (torn == 0)
                    return NumJugadors - 1;
                else
                    return torn - 1;
            }
            else
                return (torn + 1) % NumJugadors; 

        }
        public void ComençaPartida(string[] nomJugadors,TipusSubministraments[] subministraments)
        {

            if (nomJugadors.Length  < 2 || nomJugadors.Length > 4)
                throw new Exception("Numero de jugadors invalid, 2 a 4");
            if (subministraments.Length != 10)
                throw new Exception("El numero de pilons de subministraments és invalid");
            ConfiguraJugadors(nomJugadors);
            ConfiguraSobministraments(subministraments);
            Repartir();
            SortejaTorn();
            OnResize(new EventArgs());

        }
        private void Compra(object sender,EventArgs e)
        {
            Button buto = sender as Button;
            if (buto != null)
            {
                PiloSubministrament pilo = buto.Tag as PiloSubministrament;
                CartaDominion carta=pilo.Robar();
                
                JugadorActual.Pilo.PosarAlCimDeLesDescartades(carta);
             
                pilonsSubministrament.DeshabilitaCompres();
                piloJugada.Gasta(carta.Cost);
                DeseleccionaCartes();
                MiraSiHaAcabat();
                btnFinal_Click(new object(), new EventArgs());
            }
        }
        private void ConfiguraSobministraments(TipusSubministraments[] subministraments)
        {

            int numeroCoure=40;
            int numeroOr=10;
            int numeroPlata=10;

            int numeroDeCartes = 2 == NumJugadors ? 8 : 12;
            int numeroDucat=numeroDeCartes;
            int numeroMaladiccions=10*(NumJugadors-1);
            int numeroJardins= numeroDeCartes;
            int numeroProvincia=numeroDeCartes;
            int numeroFinca=numeroDeCartes;
           
            for (int i = 0; i <numeroDucat ; i++)
            {
                        CartaDominion carta = CartaDominion.DonamCarta("Ducat");
                        pilonsSubministrament[0].Posar(carta);
            }
            for (int i = 0; i < numeroFinca; i++)
            {
                CartaDominion carta = CartaDominion.DonamCarta("Finca");
                pilonsSubministrament[2].Posar(carta);
            }
            for (int i = 0; i < numeroProvincia; i++)
            {
                CartaDominion carta = CartaDominion.DonamCarta("Provincia");
                pilonsSubministrament[1].Posar(carta);
            }
            for (int i = 0; i < numeroMaladiccions; i++)
            {
                CartaDominion carta = CartaDominion.DonamCarta("Malediccio");
                pilonsSubministrament[3].Posar(carta);
            }
            //10 accio
           
            for (int i = 0; i < 10; i++)
            {
                string nomTipus = subministraments[i].ToString();
          
              
                if (!(nomTipus== "Jardins"))
                    for (int j = 0; j < 10; j++)
                    {
                        CartaDominion carta = CartaDominion.DonamCarta(nomTipus);
                        pilonsSubministrament[i+4].Posar(carta);
                    }
                else
                {
                 
                   for (int j = 0; j < numeroJardins; j++)
                    {
                        CartaDominion carta = CartaDominion.DonamCarta(nomTipus);
                        pilonsSubministrament[i+4].Posar(carta);
                    }
                }
            }  
            //3 tresor
            for (int i = 0; i < numeroCoure; i++)
            {
                CartaDominion carta = CartaDominion.DonamCarta("Coure");
                pilonsSubministrament[14].Posar(carta);
            }
            for (int i = 0; i < numeroPlata; i++)
            {
                CartaDominion carta = CartaDominion.DonamCarta("Plata");
                pilonsSubministrament[15].Posar(carta);
            }
            for (int i = 0; i < numeroOr; i++)
            {
                CartaDominion carta = CartaDominion.DonamCarta("Or");
                pilonsSubministrament[16].Posar(carta);
            }
          
       

        }
        public void SeleccionaAccions()
        {
            contadorSelecciona++;
            MaDominion maActual = JugadorActual.Ma;
            foreach (CartaDominion carta in maActual)
                if (carta.EsCartaDeAccio){
                    carta.Click += new EventHandler(TriarCarta);
                 carta.Seleccionada = true;
                }
            JugadorActual.Ma.Refresh();
        }
        public void SeleccionaTresors()
        {
            contadorSelecciona++;
            MaDominion maActual = JugadorActual.Ma;
            foreach (CartaDominion carta in maActual)
                if (carta.EsCartaDeTresor)
                {
                    carta.Click += new EventHandler(TriarCarta);
                    carta.Seleccionada = true;
                }
            pilonsSubministrament.HabilitaCompres(piloJugada.NMonedes);

        }
        private void Recollir()
        {
            for (int i = 0; i < NumJugadors; i++)
            {
                Jugador jugador = jugadors[i];
                foreach (CartaDominion carta in jugador.Ma)
                    jugador.Pilo.PosarAlCimDelPilo(carta);
                jugador.Ma.Neteja();
               while(! jugador.Pilo.PiloDescartades.Buida)
                   jugador.Pilo.PosarAlCimDelPilo(jugador.Pilo.PiloDescartades.Robar());
                
            }
        }
        private void AvançaTorn()
        {
            JugadorActual.Visible = false;
            torn = (torn + 1) % NumJugadors;
            EmpilaTorn();
            nomJugadorIFase.Text = NomJugadorActual;
            JugadorActual.Visible = true;
            OnResize(new EventArgs());
      
            //RealitzaFase(piloJugada.Desempila());

        }
        private void EmpilaTorn()
        {
            piloJugada.Empila(Fases.Manteniment);
            piloJugada.Empila(Fases.Compra);
            piloJugada.Empila(Fases.Accio);
  
        }
       
        private void TriarCarta(object sender, EventArgs e)
        {
            CartaDominion carta = sender as CartaDominion;
 
            JugadorActual.Ma.Elimina(carta);
            piloJugada.Afegir(carta);
            if (carta.EsCartaDeTresor)
                pilonsSubministrament.HabilitaCompres(piloJugada.NMonedes);
            else
            {
                DeseleccionaCartes();
                CartaAccio.CartaAccio cartaA = carta as CartaAccio.CartaAccio;
                cartaA.ExecutaAccio(this);
               
            }
            carta.Seleccionada = false;
            carta.Click -= TriarCarta;


        }
        
        private void regal(object sender, EventArgs e)
        {
            Button buto = sender as Button;
        if (buto != null)
        {
            PiloSubministrament pilo = buto.Tag as PiloSubministrament;
            if (pilo != null)
            {
                CartaDominion carta = pilo.Robar();
                carta.CaraAmunt = false;
                JugadorActual.Pilo.PiloDescartades.Posar(carta);
            }
        }
        }
        private void MostraPilo_Click(object sender, EventArgs e)
        {
            PiloSubministrament pilo = sender as PiloSubministrament;
            if (pilo != null)
               PonerImagen(pilo.PrimeraCarta);

        }
      
        protected override void OnResize(EventArgs e)
        {
            //base.OnResize(e);
            //hace los controles de la medida cogiendo el HEight
            //los coloca;
            //Hace que el with coja el Jugador.Width+espai+PiloEliminades
   
          int  alturaControls = Height * 2 / 7;
          int marge = Height / 30;

          pilonsSubministrament.Height = alturaControls+alturaControls/2;
          pilonsSubministrament.Location = new Point(pilonsSubministrament.Width / 4, 0);
          nomJugadorIFase.Location = new Point(Width / 2 - nomJugadorIFase.Width / 2, pilonsSubministrament.Height);

          piloJugada.Height = alturaControls*2/3;
          piloJugada.Location = new Point(pilonsSubministrament.Width / 4, pilonsSubministrament.Height + marge);
          piloJugada.Location = new Point(piloJugada.Location.X - piloJugada.Location.X / 2, piloJugada.Location.Y);
          panellJugadors.Height = alturaControls;
          
          panellJugadors.Width = JugadorActual.Width;
          btnFinal.Height = marge;
          btnFinal.Location = new Point(Width/2-btnFinal.Width/2, piloJugada.Location.Y + piloJugada.Height);
          panellJugadors.Location = new Point(piloJugada.Location.X, piloJugada.Location.Y + piloJugada.Height + btnFinal.Height * 2);
          btnFinal.Width = Width / 10;
       
          piloEliminades.Height = alturaControls;
          piloEliminades.Location = new Point(pilonsSubministrament.Location.X+pilonsSubministrament.Width, panellJugadors.Location.Y);
         Width =pilonsSubministrament.Location.X+pilonsSubministrament.Width+(Width/2-pilonsSubministrament.Width/2);
         // Width = pilonsSubministrament.Location.X+pilonsSubministrament.Width+pilonsSubministrament.Width/2;
            pregunta.Height=Height;
            pregunta.Location = new Point(Width / 2 - pregunta.Width / 2, 0);
        

        }
        private void DeseleccionaCartes()
        {
            contadorSelecciona--;
            MaDominion ma = JugadorActual.Ma;
            foreach (CartaDominion carta in ma)
            {
                carta.Click -= TriarCarta;
                if (carta.Seleccionada)
                    carta.Seleccionada = false;
            }
        }
        private void HabilitaCompra()
        {
            pilonsSubministrament.HabilitaCompres(piloJugada.NMonedes);
        }
        private void DeshabilitaCompres()
        {
            pilonsSubministrament.DeshabilitaCompres();
        }
        internal void HabilitaRegal(int numMonedesMax)
        {
            pilonsSubministrament.HabilitaRegals(numMonedesMax);
        }
        internal void DeshabilitaRegal()
        {
            pilonsSubministrament.DeshabilitaRegals();
        }
        private void Manteniment()
        {
            DeshabilitaCompres();
            DeshabilitaRegal();
            DeseleccionaCartes();
            piloJugada.ComptadorsAZero();
            piloJugada.Recollir(JugadorActual.Pilo.PiloDescartades);
            foreach (CartaDominion carta in JugadorActual.Ma)
            {

                JugadorActual.Pilo.PosarAlCimDeLesDescartades(carta);
            }
            JugadorActual.Ma.Neteja();
            for (int i = 0; i < 5; i++)
            {
                CartaDominion carta = JugadorActual.Pilo.Robar();

                if (carta != null)
                {
                 
                    JugadorActual.Ma.Afegir(carta);
                }
            }
          
            
            AvançaTorn();
            btnFinal_Click(new object(), new EventArgs());
        }
        public void PonerImagen(Object sender)
        {
            piloM.BringToFront();
            piloM.Height = Height;
            piloM.BackgroundImage = ((CartaDominion)sender).imatgeAnvers;
            piloM.Width = (int)(Height * Carta.relacioAltAmple);
            piloM.Location = new Point(Width / 2 - piloM.Width / 2, 0);
            piloM.Visible = true;
            piloM.Tag = sender;
          
        }

        private void pnlMostraCarta_Click(object sender, EventArgs e)
        {
          
            Panel pan = sender as Panel;
            pan.Visible = false;
            if (hanClicatIMG != null)
                hanClicatIMG(piloM.Tag,new EventArgs());
        }

    }
}
