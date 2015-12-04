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
    /// <summary>
    /// Retorna les cartes que hi ha en la pregunta i diu quin butó han clicat
    /// </summary>
    /// <param name="cartes"></param>
    /// <param name="clicatBtn1">si es true vol dir que han fet clic en el btn1 sino es el btn2</param>
    public enum TipusDeCartes
    {accio,tressor,victoria}
    public delegate void PreguntaEventHandler(dominion.Altres.MaDominion cartes,bool clicatBtn1);
    public delegate bool EsDelTipusEvenHandler(TipusDeCartes tipus);
    public partial class Pregunta : UserControl
    {
       internal Button btnA;
       internal Button btnB;
        public event PreguntaEventHandler clicBtnEvent;
        MaDominion cartes;
        Panel panellPregunta;
        RichTextBox text;
        int numMaxSeleccionades = 0;
        int numSeleccionades = 0;
        int minCartesSelecionades = 0;
        public event EsDelTipusEvenHandler esDelTipus;
        bool acabat = false;
        private TipusDeCartes tipusEsperat;

        internal TipusDeCartes TipusEsperat
        {
            get { return tipusEsperat; }
            set { tipusEsperat = value; }
        }
        
        internal int MinCartesSelecionades
        {
            get { return minCartesSelecionades; }
            set { minCartesSelecionades = value; }
        }
        internal int NumMaxSeleccionades
        {
            get { return numMaxSeleccionades; }
            set { if (value != NumMaxSeleccionades) { numMaxSeleccionades = value; foreach (CartaDominion carta in cartes)if (carta.Seleccionada)carta.Seleccionada = false; numSeleccionades = 0; } }
        }
        public Pregunta()
        {
            InitializeComponent();
            btnA = new Button();
            btnB = new Button();
            btnA.Tag = true;
            btnB.Tag = false;
            btnA.Click += new EventHandler(ClickBtn);
            btnB.Click += new EventHandler(ClickBtn);
            panellPregunta = new Panel();
            this.Visible=false;
            text = new RichTextBox();
            panellPregunta.Controls.Add(text);
            text.Dock = DockStyle.Fill;
            cartes = new MaDominion();
            cartes.Animacio = false;
            Controls.Add(btnA);
            Controls.Add(btnB);
            Controls.Add(panellPregunta);
            Controls.Add(cartes);
            BackColor = Color.Black;
            //de mentres
        //    btnB.Visible = false;
          
            btnA.BackColor = SystemColors.Control;
            btnB.BackColor = SystemColors.Control;
            text.ReadOnly = true;
      
            OnResize(new EventArgs());
        }

        private void ClickBtn(object sender, EventArgs e)
        {
            bool fer = true;
            foreach (CartaDominion carta in cartes)
                if (carta.Seleccionada)
                    if (carta.EsCartaDeAccio)
                        tipusEsperat = TipusDeCartes.accio;
                    else if (carta.EsCartaDeTresor)
                        tipusEsperat = TipusDeCartes.tressor;
                    else
                        tipusEsperat = TipusDeCartes.victoria;

            if (esDelTipus != null)
                fer = esDelTipus(tipusEsperat);
            if(fer)
            if (clicBtnEvent != null && NumCartesSeleccionades() >= minCartesSelecionades)
            {
                bool clicBtn1;
                Button buto = sender as Button;
                clicBtn1 = (bool)buto.Tag;

                foreach (CartaDominion carta in cartes)
                {
                    carta.Click -= SeleccionaCartaAlFerClic;
                    
                }
                 acabat = true;
                clicBtnEvent(cartes, clicBtn1);

                if (acabat)
                {
                    cartes.Neteja();
                    this.Visible = false;
                    minCartesSelecionades = 0;
                }
            }
        }

        private int NumCartesSeleccionades()
        {
            int contador = 0;
            foreach (CartaDominion carta in cartes)
                if (carta.Seleccionada)
                    contador++;
            return contador;
        }
        public int NSeleccionades
        {
            get
            {
                int numeroS = 0;
                foreach (CartaDominion carta in cartes)
                    if (carta.Seleccionada)
                        numeroS++;
                return numeroS;
            }
        }
        internal void RestablirBTN()
        {
            btnA = new Button();
            btnB = new Button();
        }
        public string Texte
        {
            get { return text.Text; }
            set { text.Text = value; }
        }
            public void FesPregunta(MaDominion ma,string pregunta,string textBtn1,string textBtn2,bool dosBtn)
            {
                this.Visible = true;
                this.BringToFront();
                acabat = false;
                numSeleccionades = 0;
                Texte = pregunta;
                cartes.Neteja();
                if (ma != null)
                {

                    foreach (CartaDominion carta in ma)
                    {
                        carta.Click += new EventHandler(SeleccionaCartaAlFerClic);
                        carta.Seleccionada = false;
                        cartes.Afegir(carta);
                        carta.CaraAmunt = true;
                    }
                    ma.Neteja();
                   
                }
                if (!dosBtn)
                    btnB.Visible = false;
                else
                {
                    btnB.Text = textBtn2;
                    btnB.Visible = true;
                }
                btnA.Text = textBtn1;
                OnResize(new EventArgs());
             

            }
        
            private void SeleccionaCartaAlFerClic(object sender, EventArgs e)
            {
                CartaDominion carta = sender as CartaDominion;
                if (carta != null)
                {
                    if (carta.Seleccionada)
                    {
                        numSeleccionades--;
                        carta.Seleccionada = !carta.Seleccionada;
                    }
                    else
                        if (numSeleccionades < numMaxSeleccionades)
                        {
                            numSeleccionades++;
                            carta.Seleccionada = !carta.Seleccionada;
                        }
                }
            }
        protected override void OnResize(EventArgs e)
        {
            //base.OnResize(e);
            panellPregunta.Height = (Height / 3);
           
            int marge = (Height / 2) - panellPregunta.Height;

            cartes.Height = Height / 4;
            btnA.Height = cartes.Height / 2;
            int zoom=panellPregunta.Height / 35>1?panellPregunta.Height / 35:1;
            text.ZoomFactor =zoom ;
            btnB.Height = btnA.Height;
            int marge2 = btnA.Height / 2;
            panellPregunta.Location = new Point(marge/2, marge);
            cartes.Location = new Point(marge/2, panellPregunta.Height+marge);
            btnA.Location = new Point(marge/2, cartes.Location.Y + cartes.Height + marge2);
            btnB.Location = new Point(Width-marge-btnB.Width,btnA.Location.Y);
            Width =  cartes.Width + marge*2;
            panellPregunta.Width = Width - marge ;
            if (!btnB.Visible)
                btnA.Width = panellPregunta.Width;
            else
            {
                btnA.Width = (int)(Carta.relacioAltAmple * cartes.Height);
                btnA.Width *= 2;
                btnB.Width = btnA.Width;
            }
        }

       
    }
}