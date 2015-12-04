using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion
{
    public partial class PiloJugador : UserControl
    {
        PiloDominion piloPerRobar;
        PiloDominion piloDescartades;
        int percentMarge=5;
        public PiloJugador()
        {
            InitializeComponent();
            piloPerRobar = new PiloDominion(dominion.ImatgesCartes.Revers);
            piloDescartades = new PiloDominion(dominion.ImatgesCartes.Revers);
            Controls.Add(piloPerRobar);
            Controls.Add(piloDescartades);
            OnResize(new EventArgs());
            BackColor = Color.Transparent;
        }
        protected override void OnResize(EventArgs e)
        {
            //base.OnResize(e);
          
            int marge=(int)(Width*(percentMarge/100.0));
            Width = Height / 2;
            piloDescartades.Height = (Height/2)-marge*3 ;
            piloDescartades.Width = Width - marge*2;
            piloPerRobar.Height = (Height/2) - marge*3;
            piloPerRobar.Width = Width - marge*2;
        

        
            piloPerRobar.Location = new Point(marge, 0);
            piloDescartades.Location = new Point(marge, piloDescartades.Height+marge*2);
 
        }
        public void PosarAlCimDelPilo(CartaDominion carta)
        {
            carta.CaraAmunt = false;
            carta.Refresh();
            piloPerRobar.Posar(carta);
        }
        public void PosarAlCimDeLesDescartades(CartaDominion carta)
        {
            carta.CaraAmunt = true;
            carta.Refresh();
            piloDescartades.Posar(carta);
        }
     
        public CartaDominion Robar()
        {
            CartaDominion carta=null;
            if (Count == 0)
                return carta;
           if (!piloPerRobar.Buida)
            {

                carta = piloPerRobar.Robar();
                carta.CaraAmunt = true;
            }
            else
            {
                PosarPiloDescartadesAPilo();
                piloPerRobar.Barrejar();
               carta= Robar();
            }
            return carta;
        }
        private void PosarPiloDescartadesAPilo()
        {
            while (!piloDescartades.Buida)
            {
                CartaDominion carta = piloDescartades.Robar();
                carta.CaraAmunt = false;
                piloPerRobar.Posar(carta);
            }
            
        }
     
        private int Count
        { get { return piloDescartades.NCartes + piloPerRobar.NCartes; } }
        public PiloDominion PiloDescartades { get { return piloDescartades; } }
        public List<CartaDominion> Robar(int numeroDeCartes)
        {
            List<CartaDominion> cartes = new List<CartaDominion>();
            int i;
          
            for(i=0;i<numeroDeCartes;i++)
                cartes.Add(Robar());
               
            
            return cartes;

        }
        public PiloDominion PiloPerRobar
        {
            get { return piloPerRobar; }
            set { piloPerRobar = value; }
        }
    
    }
}
