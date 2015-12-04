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
    public partial class MostraPilo : UserControl
    {
        Panel pilo;

        public MostraPilo()
        {
            this.Visible = false;
            this.Dock = DockStyle.Fill;
        }

        private void pnlMostraCarta_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Visible = false;
        }

        public void PonerImagen(Object sender)
        {
            this.Visible = true;
            pilo = new Panel();
            pilo.Height = Height;
          
           Controls.Add(pilo);
            pilo.BackgroundImageLayout = ImageLayout.Stretch;
            pilo.BackgroundImage = ((CartaDominion)sender).imatgeAnvers;
            pilo.Width =(int) (Height * Carta.relacioAltAmple);
            pilo.Location = new Point(Width / 2-pilo.Width/2, 0);
            pilo.Click += new EventHandler(pnlMostraCarta_Click);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.BackColor = Color.FromArgb(75, Color.Black.R, Color.Black.G, Color.Black.B);
        }
    }
}
