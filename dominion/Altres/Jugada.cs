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
{
    public enum Fases
    {
        Accio,Compra,Manteniment
    }
    public partial class Jugada : UserControl,IEnumerable<CartaDominion>
    {
        Comptadors comptadors;
        MaDominion maDeLaJugada;
        Stack<Fases> fases;
        int percentMarge=5;
        public Jugada()
        {
         
            InitializeComponent();
            comptadors = new Comptadors();
            fases = new Stack<Fases>();
            maDeLaJugada = new MaDominion();
            BackColor = Color.Transparent;
            OnResize(new EventArgs());
            Controls.Add(maDeLaJugada);
            Controls.Add(comptadors);
            //DoubleBuffered = true;//posat
        
        }
        public int PercentMarge
        {
            get { return percentMarge; }
            set { percentMarge = value; OnResize(new EventArgs()); }
        }
        protected override void OnResize(EventArgs e)
        {
            //base.OnResize(e);
            if (comptadors != null)
            {
              
                int marge = (int)(Width * (percentMarge / 100.0));
                comptadors.Height = Height;
                comptadors.Location = new Point(0, 0);
                maDeLaJugada.Location = new Point(comptadors.Width+marge, 0);
                maDeLaJugada.Height = Height;
                Width = comptadors.Width + maDeLaJugada.Width+marge;
           
            }
        }
        public void ComptadorsAZero()
        {
            comptadors.NAccions = 0;
            comptadors.NCompres = 0;
            comptadors.NMonedes = 0;
        }
        public void Afegir(CartaDominion carta)
        {
         
            maDeLaJugada.Afegir(carta);
            if (carta.EsCartaDeAccio)
            {
                CartaAccio.CartaAccio cartaA = carta as CartaAccio.CartaAccio;
                comptadors.NAccions += cartaA.AccionsAdicionals;
                for (int i = 0; i < cartaA.AccionsAdicionals; i++)
                    fases.Push(Fases.Accio);
                comptadors.NCompres+=cartaA.CompresAdicionals;
                for (int i = 0; i < cartaA.CompresAdicionals; i++)
                    fases.Push(Fases.Compra);
                comptadors.NMonedes += cartaA.Valor;

            }
            else if(carta.EsCartaDeTresor)
                comptadors.NMonedes += carta.Valor;

            
        }
        public Fases Desempila()
        {
            if (fases.Count == 0)
                throw new Exception("No hi ha fases");
            Fases fase = fases.Pop();
            if (fase.Equals(Fases.Accio))
                comptadors.NAccions--;
            else if (fase.Equals(Fases.Compra))
                comptadors.NCompres--;
            return fase;
        }
        public void Elimina(CartaDominion carta)
        {
            maDeLaJugada.Elimina(carta);
        }
        public void Empila(Fases fase)
        {
            fases.Push(fase);
            if (fase.Equals(Fases.Accio))
                comptadors.NAccions++;
            else if (fase.Equals(Fases.Compra))
                comptadors.NCompres++;
           
        }
        public void Gasta(int numMonedes)
        {
            comptadors.NMonedes -= numMonedes;
        }


        public IEnumerator<CartaDominion> GetEnumerator()
        {

            foreach (CartaDominion carta in maDeLaJugada)
                yield return carta;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Recollir(PiloDominion pilo)
        {
            foreach (CartaDominion carta in this)
            {
                carta.CaraAmunt = false;
                pilo.Posar(carta);
            }
            maDeLaJugada.Neteja();
        }
        public int NCartes
        { get { return maDeLaJugada.NCartes; } }
        public int NAccions
        { get { return comptadors.NAccions; } }
        public int NCompres
        { get { return comptadors.NCompres; } }
        public int NMonedes
        { get { return comptadors.NMonedes; } }
    }
}
