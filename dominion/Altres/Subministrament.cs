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
    public partial class Subministrament : UserControl,IEnumerable<PiloSubministrament>
    {

        private Panel panellAccio;
        private Panel panellTresor;
        private Panel panellVictoria;
        private PiloSubministrament[] pilons;
        public event EventHandler clicCompra;
        public event EventHandler clicRegal;
        public Subministrament()
        {
            InitializeComponent();
            
            panellAccio = new Panel();
            panellTresor = new Panel();
            panellVictoria = new Panel();
            pilons = new PiloSubministrament[17];

            Controls.Clear();
            Controls.Add(panellVictoria);
            Controls.Add(panellAccio);
            Controls.Add(panellTresor);
            int i = 0;
            for (; i < 4; i++)
            {
                pilons[i] = new PiloSubministrament();
                pilons[i].clicRegal += new EventHandler(HanRegalat);
                pilons[i].clicCompra += new EventHandler(HanComprat);
                panellVictoria.Controls.Add(pilons[i]);
            }
            for (; i < 14; i++)
            {
                pilons[i] = new PiloSubministrament();
                panellAccio.Controls.Add(pilons[i]);
                pilons[i].clicRegal += new EventHandler(HanRegalat);
                pilons[i].clicCompra += new EventHandler(HanComprat);
            }
            for (; i < 17; i++)
            {
                pilons[i] = new PiloSubministrament();
                panellTresor.Controls.Add(pilons[i]);
                pilons[i].clicRegal += new EventHandler(HanRegalat);
                pilons[i].clicCompra += new EventHandler(HanComprat);
            }
  
            OnResize(new EventArgs());

        }

        private void HanComprat(object sender, EventArgs e)
        {
            if (clicCompra != null)
                clicCompra(sender,e);
        }

        private void HanRegalat(object sender, EventArgs e)
        {
            if (clicRegal != null)
                clicRegal(sender, e);
        }

        private Panel PanellVictoria
        {
            get { return panellVictoria; }
            set { panellVictoria = value; }
        }

        private Panel PanellAccio
        {
            get { return panellAccio; }
            set { panellAccio = value; }
        }
        private Panel PanellTresor
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
        public PiloSubministrament this[int index]//por mirar
        {
            get 
            { 
                    
                if(index<0||index==Count)
                    throw new Exception("Fora de rang");
   
                    return pilons[index];
            }
        }

        /// <summary>
        /// Deshabilita els compres de tots els pilons de subministrament.
        /// </summary>
        public void DeshabilitaCompres()
        {
            
                foreach(PiloSubministrament pila in this)
                pila.DeshabilitaCompra();
            
        }
        /// <summary>
        /// Deshabilita els regals de tots els pilons de subministrament.
        /// </summary>
        public void DeshabilitaRegals()
        {
            //amagar la imatge
            foreach (PiloSubministrament pila in this)
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
            foreach (PiloSubministrament pila in this)
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
            foreach (PiloSubministrament pila in this)
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
            foreach (PiloSubministrament pila in this)
            {
               
                    pila.HabilitaRegal(costMaxim);
                
            }
        }
    
     
        protected override void OnResize(EventArgs e)
        {
            int mf = Height / 15;
            int mi = Height / 30;
            int piloHeight = (Height - 2 * mf - mi) / 2;
            Width = (int)((mf * 2) * 3 + 6 * mi + (piloHeight* (Carta.RelacioAltAmple) * 9));
            int withTotal=mf;
            int withP = 0;
            int pilonsPanell = 0;
            foreach (Panel p in Controls)
            {
                pilonsPanell = p.Controls.Count;
                for (int i = 0; i < pilonsPanell / 2; i++)
                {
                    p.Controls[i].Location = new Point(withTotal, mf);
                    p.Controls[i].Height = piloHeight;
                    p.Controls[i + pilonsPanell / 2].Location = new Point(withTotal, mf + p.Controls[i].Height + mi);
                    p.Controls[i + pilonsPanell / 2].Height = piloHeight;
                    
              
                    withTotal += p.Controls[i].Width + mi;

                }
                p.Location = new Point(withP, 0);
                p.Width = withTotal + mf-mi;
                withP += p.Width;
                p.Height = Height;
                withTotal = mf;
            }
            Panel panel =(Panel) Controls[2];
            PiloSubministrament pilo = panel.Controls[2] as PiloSubministrament;
            withTotal += panel.Controls[1].Width ;
            pilo.Location = new Point(withTotal+mi, mf);
            pilo.Height = piloHeight;
            panel.Width=(int)(mf*2+mi+(piloHeight* (Carta.RelacioAltAmple)*2));
    

        }

        public IEnumerator<PiloSubministrament> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
