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
    public partial class Jugador : UserControl
    {
        PiloJugador mazo;
        MaDominion ma;
        string nom;
        int percentMarge = 5;

  
        public Jugador()
        {
            InitializeComponent();
            mazo = new PiloJugador();
            ma = new MaDominion();
          //  DoubleBuffered = true;//posat
            OnResize(new EventArgs());
            Controls.Add(ma);
            Controls.Add(mazo);
        }
        protected override void OnResize(EventArgs e)
        {
            //base.OnResize(e);
            mazo.Height = Height;
            ma.Height = Height;
            int marge = (int)(Width * (percentMarge / 100.0));
            mazo.Location = new Point(0, 0);
            ma.Location = new Point((int)(mazo.Width+marge), 0);
            Width = ma.Width + mazo.Width+marge;
        }
        public PiloJugador Pilo
        { get { return mazo; } }
        public MaDominion Ma
        { get { return ma; } }
        public string Nom
        { get { return nom; } set { nom = value; } }
        public int PercentMarge
        {
            get { return percentMarge; }
            set { percentMarge = value; OnResize(new EventArgs()); }
        }

    }
}
