using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace dominion.Altres
{
 
    public partial class MaDominion : UserControl,IEnumerable<CartaDominion>
    {

        #region Atributs
        List<CartaDominion> cartesMa=new List<CartaDominion>();
 
        const int ALTURACARTA = 7;
  
        bool animacio = true;
        int velocitatAnimacio = 1;

        bool aixecaCarta = true;
        const int PAUSA = 5;
        static bool esMouenCartes=false;
      static  int  contadorCartesMogudes = 0;
        public bool AixecaCarta
        {
            get { return aixecaCarta; }
            set { if (value != aixecaCarta) { aixecaCarta = value; PosarOTreureEventAixeca(); } }
        }
        private void PosarOTreureEventAixeca()
        {
            
            foreach(CartaDominion carta in cartesMa)
                if (AixecaCarta)
                {
                    carta.MouseHover += new EventHandler(MouseDinsCarta);
                    carta.MouseLeave += new EventHandler(SurtRatoli);
                }
                else
                {
                    carta.MouseHover -= new EventHandler(MouseDinsCarta);
                    carta.MouseLeave -= new EventHandler(SurtRatoli);
                }
        }
       
        
        #endregion
        public MaDominion()
        {
            InitializeComponent();
            Width = ((int)(Height * dominion.Carta.relacioAltAmple)) * 5;
            BackColor = Color.Transparent;
     
          
        }
        #region Propietats
        public int VelocitatAnimacio
        {
            get { return velocitatAnimacio; }
            set { velocitatAnimacio = value; }
        }

        public bool HiHaCartesAccio { get { return HiHaCartaAccio(); } }
        public bool HiHaCartesTresor { get { return HiHaCartaTresor(); } }

     
        public bool HiHaCartesVictoria { get { return HiHaCartaVictoria(); } }

        public bool HiHaCartesReaccio { get { return HiHaCartaReccio(); } }
        public CartaDominion this[int index]
        { get { if (index > cartesMa.Count - 1 && index < 0)throw new Exception("Fora de rang"); return cartesMa.ElementAt(index); } }
        public bool Animacio
        {
            get { return animacio; }
            set { animacio = value; }
        }
 
        public int NCartes
        { get { return cartesMa.Count; } }
        #endregion
        #region metodesPublics
        public void Afegir(CartaDominion carta)
        {
           if (carta != null)
            {
               bool animacioB=Animacio;
               Point localitazioCarta;
               carta.CaraAmunt = true;
              if (AixecaCarta)
                {
                    carta.Height = Height - AlturaCarta();
                    carta.MouseHover += new EventHandler(MouseDinsCarta);
                    carta.MouseLeave += new EventHandler(SurtRatoli);
                }
                else
                    carta.Height = Height;
               
                if (cartesMa.Count > 0)
                {
                    localitazioCarta = cartesMa.ElementAt(cartesMa.Count - 1).Location;
                    localitazioCarta = new Point(localitazioCarta.X + carta.Width, AlturaCarta());
                }
                else
                    localitazioCarta = new Point(0, AlturaCarta());

                carta.Location = localitazioCarta;
                cartesMa.Add(carta);
                Controls.Add(carta);
                if (!esMouenCartes)
                {
                 
                    MoureCartes();
                }
                else
                {
                    AturaCartes();
                    MoureCartes();
                }
                Animacio = animacioB;
            }

        }

        public void Neteja()
        {
            Controls.Clear();
            cartesMa.Clear();
        }
        public void CartesABaixAlSortir(object sender, EventArgs e)//per si vol que les cartes vagin a baix
        {
            MaDominion ma = sender as MaDominion;
            foreach (CartaDominion carta in ma.cartesMa)
            {
                Thread fil = carta.Tag as Thread;
                if (fil != null)
                    fil.Abort();
                PosarLocalizacioCartes(new Point(carta.Location.X, AlturaCarta()), carta);
            }
        }
        public void Elimina(CartaDominion cartaE)
        {
            cartesMa.Remove(cartaE);
            Controls.Remove(cartaE);
            if (AixecaCarta)
            {
                cartaE.MouseHover -= new EventHandler(MouseDinsCarta);
                cartaE.MouseLeave -= new EventHandler(SurtRatoli);
            }
            if(NCartes>0)
            MoureCartes();
        }
        public void Elimina(int posicioMa)
        {
            CartaDominion carta = cartesMa.ElementAt(posicioMa);
            Elimina(carta);
        }
        public void OrdenaMa()
        {
            cartesMa.Sort();
            cartesMa.Sort();
            List<CartaDominion> aux = new List<CartaDominion>();
            aux.AddRange(cartesMa);
            Neteja();
            cartesMa.AddRange(aux);
            Controls.AddRange(aux.ToArray<CartaDominion>());
            MoureCartes();
 
        }

        private void AturaCartes()
        {
            foreach (CartaDominion carta in this)
            {
                Thread fil = carta.Tag as Thread;
                if (fil != null)
                    fil.Abort();
           
            }
        }
        #endregion
        #region Metodes Animacio

        private void MouseDinsCarta(object sender, EventArgs e)
        {
            CartaDominion carta = sender as CartaDominion;

            if (carta.Location.Y > 0)
            {

                PosarLocalizacioCartes(new Point(carta.Location.X, 0), carta);
                BaixaCartes();
            }
        }
        private void SurtRatoli(object sender, EventArgs e)
        {

            CartaDominion carta = sender as CartaDominion;
            PosarLocalizacioCartes(new Point(carta.Location.X, AlturaCarta()), carta);
            
        }

        internal void RecolocarCartes()
        {
            MaDominion maAux = new MaDominion();
            maAux.Animacio = false;
            foreach (CartaDominion carta in this)
                maAux.Afegir(carta);
            Neteja();
            Animacio = false;
            foreach (CartaDominion carta in maAux)
                Afegir(carta);
            Animacio = true;
        }
        private int AlturaCarta()
        {
            return (Height / ALTURACARTA);
        }
        private void BaixaCartes()
        {
            foreach (CartaDominion carta in cartesMa)
            {
                if (carta.Location.Y < AlturaCarta())
                    PosarLocalizacioCartes(new Point(carta.Location.X, AlturaCarta()), carta);

            }
        }
        private void PosarLocalizacioCartes(Point localitacio, CartaDominion carta)
        {
            Thread fil = null;

            if (animacio)
                fil = new Thread(() => AnimacioPosarEnPosicioCarta(carta.Location, localitacio, carta));

            else
                carta.Location = localitacio;
            carta.Tag = fil;
            if (fil != null)
                fil.Start();



        }
        private void MoureCartes()
        {
            
            int withTotal = 0;
            int withPerCarta = Width / NCartes;
             int numMaxCartes;
           
                 numMaxCartes = 0; 
            esMouenCartes = true;
            contadorCartesMogudes = 0;
            if (NCartes <= numMaxCartes)
                foreach (CartaDominion carta in cartesMa)
                {

                    PosarLocalizacioCartes(new Point(withTotal, AlturaCarta()), carta);

                    withTotal += withPerCarta;
                }
            else
                foreach (CartaDominion carta in cartesMa)
                {

                    PosarLocalizacioCartes(new Point(withTotal, AlturaCarta()), carta);

                    withTotal += withPerCarta/2;
                }


        }
        private void AnimacioPosarEnPosicioCarta(Point inici, Point fi, CartaDominion carta)
        {
            if (inici.X < fi.X)
                for (int i = inici.X; i < fi.X; i += velocitatAnimacio)
                {
                    PosarLocalitzacio(carta, new Point(i, carta.Location.Y));
                   
                }
            else
                for (int i = inici.X; i > fi.X; i -= velocitatAnimacio)
                {

                    PosarLocalitzacio(carta, new Point(i, carta.Location.Y));
                }
            if (inici.Y < fi.Y)
                for (int i = inici.Y; i < fi.Y; i += velocitatAnimacio)
                {
                    PosarLocalitzacio(carta, new Point(carta.Location.X, i));
                }
            else
                for (int i = inici.Y; i > fi.Y; i -= velocitatAnimacio)
                {
                    PosarLocalitzacio(carta, new Point(carta.Location.X, i));
                }
            if (!carta.Location.Equals(fi))
                PosarLocalitzacio(carta, fi);
            contadorCartesMogudes++;
            if (contadorCartesMogudes == NCartes)
                esMouenCartes = false;
        }
        private void PosarLocalitzacio(CartaDominion carta, Point localitacio)
        {

         Monitor.Enter(carta);
          Action  action= () => carta.Location = localitacio;
         Monitor.Exit(carta);
            try
            {
              
                    this.BeginInvoke(action);
            }
            catch {  }
            Pausa();



        }
        private void Pausa()
        {
            Thread.Sleep(PAUSA);
        }
        #endregion
        protected override void OnResize(EventArgs e)
        {
            //base.OnResize(e);
        
          
            Width = ((int)(Height * Carta.relacioAltAmple)) * 4;
            foreach (CartaDominion carta in cartesMa)
            {
                carta.Height = Height;
        
            }
            if(NCartes>0)
            MoureCartes();
           
        }


        private int NumeroDeCartes
        { get { return cartesMa.Count; } }

        private bool HiHaCartaAccio()
        {
            IEnumerator<CartaDominion> dit = cartesMa.GetEnumerator();
            bool trobat = false;
            while (dit.MoveNext() && !trobat)
            {
                CartaDominion carta = dit.Current;
                if (carta.EsCartaDeAccio)
                    trobat = true;
            }
            return trobat;

        }


        private bool HiHaCartaReccio()
        {
            IEnumerator<CartaDominion> dit = this.GetEnumerator();
            bool trobat = false;
            while (dit.MoveNext() && !trobat)
            {
                CartaDominion carta = dit.Current;
                if (carta.EsCartaDeAccio)
                {
                    CartaAccio.CartaAccio cartaA = carta as CartaAccio.CartaAccio;
                    if (cartaA.EsCartaReaccio)
                        trobat = true;
                }
            }
            return trobat;

        }
        private bool HiHaCartaTresor()
        {
            IEnumerator<CartaDominion> dit = this.GetEnumerator();
            bool trobat = false;
            while (dit.MoveNext() && !trobat)
            {
                CartaDominion carta = dit.Current;
                if (carta.EsCartaDeTresor)
                {
                   
                        trobat = true;
                }
            }
            return trobat;
        }
        private bool HiHaCartaVictoria()
        {
            IEnumerator<CartaDominion> dit = this.GetEnumerator();
            bool trobat = false;
            while (dit.MoveNext() && !trobat)
            {
                CartaDominion carta = dit.Current;
                if (carta.EsCartaDeVictoria)
                {
                  
                        trobat = true;
                }
            }
            return trobat;
        }

        public IEnumerator<CartaDominion> GetEnumerator()
        {
            return cartesMa.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

       
    }

    public class HiHaCartesSeleccionadesEventArgs : EventArgs
    {
        bool cartesSeleccionades;

        public HiHaCartesSeleccionadesEventArgs(int numeroDeCartes)
        {
            cartesSeleccionades = numeroDeCartes != 0;
        }

        public bool CartesSeleccionades
        {
            get { return cartesSeleccionades; }
          
        }

    }
}
