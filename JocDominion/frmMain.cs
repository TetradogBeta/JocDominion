using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace JocDominion
{
    public partial class frmJocDominon : Form
    {
   
        dominion.Altres.Partida partida;

        public frmJocDominon()
        {
    
            InitializeComponent();
           // BackgroundImageLayout = ImageLayout.Zoom;
         // DoubleBuffered = true;
          
        }

    
        public void ComençaPartida(dominion.Altres.TipusSubministraments[] mazos, string[] noms)
        {
            partida = new dominion.Altres.Partida();
            partida.ComençaPartida(noms, mazos);
            Controls.Add(partida);
            partida.Dock = DockStyle.Left;
            Width = partida.Width;
        }


        private void frmJocDominon_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f = Tag as Form;
            if(f!=null)
            f.Close();
        }


    }
}
