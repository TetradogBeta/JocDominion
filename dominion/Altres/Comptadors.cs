using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace dominion
{
    public partial class Comptadors : UserControl
    {
        #region Atributs
        int nAccions;
        int nMonedes;
        int nCompres;
        #endregion

        #region Propietats
        public int NAccions
        {
            get { return nAccions; }
            set { nAccions = value; Refresh(); }
        }

        public int NCompres
        {
            get { return nCompres; }
            set { nCompres = value; Refresh(); }
        }

        public int NMonedes
        {
            get { return nMonedes; }
            set { nMonedes = value; Refresh(); }
        }
        #endregion


        public Comptadors()
        {
            InitializeComponent();
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int pos1 = Width / 8 + (Width / 16) / 2;
            int pos2 = Width / 8 - (Width / 16) / 2 + (Width / 40) / 2;
            base.OnPaint(e);

            e.Graphics.FillPolygon(new SolidBrush(Color.Black), new Point[] { new Point(Width / 4, 0 + Height / 4 + (Height / 16) / 2 - Height / 16), new Point(Width / 2 - (Width / 16), (Height / 4 - (Width / 19)) + Height / 4 + (Height / 16) / 2 - Height / 16), new Point(Width / 4, (Height / 2 - Width / 9) + Height / 4 + (Height / 16) / 2 - Height / 16)/*, new Point(Width / 17, (Height / 4 - (Width / 19)) + Height / 4 + (Height / 16) / 2 - Height / 16)*/ });

            e.Graphics.FillPolygon(new SolidBrush(Color.Red), new Point[] { new Point(Width / 4, 0), new Point(Width / 2 - (Width / 16), Height / 4 - (Width / 19)), new Point(Width / 4, Height / 2 - Width / 9), new Point(Width / 17, Height / 4 - (Width / 19)) });
            e.Graphics.FillPolygon(new SolidBrush(Color.Red), new Point[] { new Point(Width / 4 + ((Width / 4) - (Width / 16) / 2), 0 + Height / 4 + (Height / 16) / 2 - Height / 16), new Point(Width / 2 - (Width / 16) + ((Width / 4) - (Width / 16) / 2), (Height / 4 - (Width / 19)) + Height / 4 + (Height / 16) / 2 - Height / 16), new Point(Width / 4 + ((Width / 4) - (Width / 16) / 2), (Height / 2 - Width / 9) + Height / 4 + (Height / 16) / 2 - Height / 16), new Point(Width / 17 + ((Width / 4) - (Width / 16) / 2), (Height / 4 - (Width / 19)) + Height / 4 + (Height / 16) / 2 - Height / 16) });
            e.Graphics.FillPolygon(new SolidBrush(Color.Red), new Point[] { new Point(Width / 4, 0 + (Height / 2 - ((Height / 8) / 2))), new Point(Width / 2 - (Width / 16), (Height / 4 - (Width / 19)) + (Height / 2 - ((Height / 8) / 2))), new Point(Width / 4, (Height / 2 - Width / 9) + (Height / 2 - ((Height / 8) / 2))), new Point(Width / 17, (Height / 4 - (Width / 19)) + (Height / 2 - ((Height / 8) / 2))) });



            if (NAccions <= 9)
                e.Graphics.DrawString(NAccions.ToString(), new Font("Arial", Width / 4 - (Width / 6) / 2 - (Width / 60), FontStyle.Bold), new SolidBrush(Color.Black), pos1, Height / 16 + (Width / 16) / 3);
            else
                e.Graphics.DrawString(NAccions.ToString(), new Font("Arial", Width / 4 - (Width / 6) / 2 - (Width / 60), FontStyle.Bold), new SolidBrush(Color.Black), pos2, Height / 16 + (Width / 16) / 3);

            if (NCompres <= 9)
                e.Graphics.DrawString(NCompres.ToString(), new Font("Arial", Width / 4 - (Width / 6) / 2 - (Width / 60), FontStyle.Bold), new SolidBrush(Color.Black), pos1 + Width / 4 - (Width / 40), Height / 2 - Height / 8 - (Height / 6) / 2);
            else
                e.Graphics.DrawString(NCompres.ToString(), new Font("Arial", Width / 4 - (Width / 6) / 2 - (Width / 60), FontStyle.Bold), new SolidBrush(Color.Black), pos2 + Width / 4 - (Width / 16) / 2, Height / 2 - Height / 8 - (Height / 6) / 2);


            if (NMonedes <= 9)
                e.Graphics.DrawString(NMonedes.ToString(), new Font("Arial", Width / 4 - (Width / 6) / 2 - (Width / 60), FontStyle.Bold), new SolidBrush(Color.Black), pos1, Height - Height / 2 + (Height / 30) / 2);
            else
                e.Graphics.DrawString(NMonedes.ToString(), new Font("Arial", Width / 4 - (Width / 6) / 2 - (Width / 60), FontStyle.Bold), new SolidBrush(Color.Black), pos2, Height - Height / 2 + (Height / 30) / 2);


            e.Graphics.DrawString("Accions", new Font("Arial", (Height / 8) / 2, FontStyle.Bold), new SolidBrush(Color.Black), Width / 2 - (Width / 8), (Height / 8) / 2);
            e.Graphics.DrawString("Compra", new Font("Arial", (Height / 8) / 2, FontStyle.Bold), new SolidBrush(Color.Black), Width / 2 + Width / 8 + (Width / 16) / 2, Height / 2 - Height / 8);
            e.Graphics.DrawString("Monedes", new Font("Arial", (Height / 8) / 2, FontStyle.Bold), new SolidBrush(Color.Black), Width / 2 - Width / 4 + Width / 8, Height - Height / 3);
        }

        protected override void OnResize(EventArgs e)
        {
            Width = Height;
            base.OnResize(e);
        }

    }
}
