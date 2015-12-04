using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion
{
    public partial class Subministrament : UserControl
    {
        private const int NPILONS= 17;
        private Panel panellAccio;
        private Panel panellTresor;
        private Panel panellVictoria;
        private int marge = 5;
        //private int percentMarge;
        private PiloSubministrament[] pilons;
        public Subministrament()
        {
            InitializeComponent();
            
            panellAccio = new Panel();
            panellTresor = new Panel();
            panellVictoria = new Panel();

            Controls.Add(panellAccio);
            Controls.Add(panellTresor);
            Controls.Add(panellVictoria);
            pilons = new PiloSubministrament[NPILONS];
            
            OnResize(new EventArgs());

            for (int i = 0; i < NPILONS; i++)
            {
                pilons[i] = new PiloSubministrament();
                if (i <= 3)
                    panellVictoria.Controls.Add(pilons[i]);
                else if (i <= 13)
                    panellAccio.Controls.Add(pilons[i]);
                else
                    PanellTresor.Controls.Add(pilons[i]);
            }

            

            Width = 7 * pilons[1].Width + marge *7;
            Height = 2 * pilons[1].Height + marge * 3;
        }

        public Panel PanellVictoria
        {
            get { return panellVictoria; }
            set { panellVictoria = value; }
        }
        public PiloSubministrament[] Pilons
        {
            get { return pilons; }
            set { pilons = value; }
        }
        public Panel PanellAccio
        {
            get { return panellAccio; }
            set { panellAccio = value; }
        }
        public Panel PanellTresor
        {
            get { return panellTresor; }
            set { panellTresor = value; }
        }

        public int Count
        {
            get
            {
                return pilons.Count();   
            } 
        }
        /// <summary>
        /// Obté el PiloSubministrament que està en el índex especificat
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PiloSubministrament this[int index]
        {
            get 
            { 
                if (index > pilons.Count() -1 && index < 0)
                    throw new Exception("Fora de rang"); 
                return pilons.ElementAt(index); 
            }
        }

        /// <summary>
        /// Deshabilita els compres de tots els pilons de subministrament.
        /// </summary>
        public void DeshabilitaCompres()
        {
            foreach (PiloSubministrament pila in pilons)
            {
                pila.DeshabilitaCompra();
            }
        }
        /// <summary>
        /// Deshabilita els regals de tots els pilons de subministrament.
        /// </summary>
        public void DeshabilitaRegals()
        {
            //amagar la imatge
            foreach (PiloSubministrament pila in pilons)
            {
                        
                pila.DeshabilitaRegal();
            }
        }

        /// <summary>
        /// Habilita els compres.
        /// </summary>
        /// <param name="costMaxim"></param>
        public void HabilitaCompres(int costMaxim)
        {
            //mostrar la imatge
            foreach (PiloSubministrament pila in pilons)
            {
                pila.HabilitaCompra(costMaxim);
            }
        }

        /// <summary>
        /// Habilita els regals.
        /// </summary>
        /// <param name="costMaxim"></param>
        public void HabilitaRegals(int costMaxim)
        {
            //mostrar la imatge
            foreach (PiloSubministrament pila in pilons)
            {
                pila.HabilitaRegal(costMaxim);
                
            }
        }

        /// <summary>
        /// Habilita els regals de tresors. És com l'habilita regals, però només activa els pilons de subministrament dels tresors.
        /// </summary>
        /// <param name="costMaxim"></param>
        public void HabilitaRegalsTresors(int costMaxim)
        {
            foreach (PiloSubministrament pila in pilons)
            {
                if(/*Esta a la panel de tresors*/true)
                {
                    pila.HabilitaRegal(costMaxim);
                }
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (panellAccio != null)
            {
                panellVictoria.Width = (Width / 4) - (marge);
                panellVictoria.Height = Height;
                panellVictoria.BackColor = Color.Blue;
                panellVictoria.Location = new Point(marge, 0);

                panellAccio.Width = Width / 2 - (marge);
                panellAccio.Height = Height;
                panellAccio.BackColor = Color.Violet;
                panellAccio.Location = new Point(panellVictoria.Width + marge + marge, 0);

                panellTresor.Width = Width / 4 - (marge);
                panellTresor.Height = Height;
                panellTresor.BackColor = Color.Red;
                panellTresor.Location = new Point(marge +panellVictoria.Width + marge + panellAccio.Width + marge, 0);
                
            }
            if (pilons[4] != null)
            {
                pilons[0].Location = new Point(marge, marge);
                pilons[1].Location = new Point(marge + pilons[1].Width, marge);
                pilons[2].Location = new Point(marge, marge + pilons[2].Height);
                pilons[3].Location = new Point(marge + pilons[2].Width, marge + pilons[2].Height);
                
                for (int i = 0; i < NPILONS; i++)
                {
                    pilons[i].Width = panellVictoria.Width / 2 - (marge * 2);
                }

            }
        }
    }
}
