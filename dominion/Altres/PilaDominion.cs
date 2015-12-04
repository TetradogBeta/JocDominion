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
    public partial class PiloDominion : UserControl
    {
        private bool cartesCaraAmunt;
        private Stack<CartaDominion> pila;
        private int percentAmpladaNCartes;
        private bool mostraNumeroDeCartes;
        private Bitmap imatgeReversCartes;
        private Bitmap imatgeDeSobre;
        private Bitmap imatgeDeFons;

        public PiloDominion()
        {
            InitializeComponent();
            pila = new Stack<CartaDominion>();
            Width = (int)(Height * Carta.relacioAltAmple);
            BackColor = Color.Transparent;
        }

        public PiloDominion(Bitmap carta)
            : this()
        {
            imatgeDeFons = carta;
            BackgroundImageLayout = ImageLayout.Zoom;
        }

        /// <summary>
        /// Obté o estableix si les CartaDominion que componen la baralla cal mostrar-les cara amunt.
        /// </summary>
        public bool CartesCaraAmunt
        {
            get { return cartesCaraAmunt; }
            set { cartesCaraAmunt = value; }
        }

        /// <summary>
        /// Informa de si el piló de cartes está buit
        /// </summary>
        public bool Buida
        {
            get { return pila.Count == 0; }
        }
        
        /// <summary>
        /// Retorna la CartaDominion del cim de la PiloDominion, sense eliminar-la;
        /// </summary>
        public CartaDominion PrimeraCarta
        {
            get { if (!Buida)  return pila.Peek(); else return null; }
        }

        /// <summary>
        /// Obté o assigna la mida de l'indicador del número de cartes. La mida s'indica en forma de percentatge de l'amplada de la PiloDominion i cal establir-lo entre 5 i 35;
        /// </summary>
        public int PercentAmpladaNCartes
        {
            get { return (int)Carta.relacioAltAmple * 100; }
            set { Carta.relacioAltAmple = value / 100; }
        }

        /// <summary>
        /// Retorna quantes CartaDominion hi ha al PiloDominion
        /// </summary>
        public int NCartes
        {
            get
            {
                return pila.Count();
            }
        }

        /// <summary>
        /// Obté o assigna si la PiloDominion ha de mostrar un indicador gràfic de quantes cartes conté.
        /// </summary>
        public bool MostraNumeroDeCartes
        {
            get
            {
                return mostraNumeroDeCartes;


            }
            set { if (value != mostraNumeroDeCartes) { mostraNumeroDeCartes = value; Refresh(); } }
        }

        /// <summary>
        /// Obté o estableix la imatge que mostrarà quan la PiloDominion no és buida, i les cartes no estan cara amunt
        /// </summary>
        public Bitmap ImatgeReversCartes
        {
            get { return pila.Peek().ImatgeRevers; }
            set { imatgeReversCartes = value; }
        }

        /// <summary>
        /// Obté o estableix la imatge que mostrarà quan la PiloDominion no és buida, i les cartes estan cara amunt
        /// </summary>
        public Bitmap ImatgeDeSobre
        {
            get { return pila.Peek().ImatgeAnvers; }
            set { imatgeDeSobre = value; }
        }

        /// <summary>
        /// Obté o estableix la imatge que mostrarà quan la PiloDominion és buida, sense tenir en compte si les cartes estan o no cara amunt.
        /// </summary>
        public Bitmap ImatgeDeFons
        {
            get { return imatgeDeFons; }
            set { imatgeDeFons = value; }
        }

        public void Barrejar()
        {
            List<CartaDominion> copia = new List<CartaDominion>();
            copia.AddRange(pila);
            pila.Clear();
            Random r = new Random();
            int longitud = copia.Count;
            int carta = 0;
            for (int i = 0; i < longitud; i++)
            {
                carta = r.Next(0, copia.Count);
                pila.Push(copia.ElementAt(carta));
                copia.RemoveAt(carta);

            }
        }

        /// <summary>
        /// Obté un enumerador de CartaDominion 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<CartaDominion> GetEnumerator()
        {
            return pila.GetEnumerator();
        }

        /// <summary>
        /// Mantè la relació entre l'amplada i l'alçada de la PiloDominion
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
           // if (pila != null)
            {
              //  base.OnPaint(e);
                Graphics gr = e.Graphics;
              //  gr.FillRectangle(new SolidBrush(this.BackColor), ClientRectangle);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                if (!(Buida))
                {
                   
                    CartaDominion carta = PrimeraCarta;
              
                    if(carta.CaraAmunt)
                    BackgroundImage = carta.ImatgeAnvers;
                    else
                        BackgroundImage = carta.ImatgeRevers;
                }
                else
                {
                    BackgroundImage = ImatgeDeFons;
                }
                if (mostraNumeroDeCartes)
                {
                    gr.FillEllipse(new SolidBrush(this.ForeColor), (ClientRectangle.Width - (ClientRectangle.Width / 5)), (ClientRectangle.Top * 1.5f), ClientRectangle.Width / 5, ClientRectangle.Width / 5);
                    if (pila.Count > 0 && pila.Count <= 9)
                    {
                        gr.DrawString(pila.Count.ToString(), new Font("Arial", ((int)ClientRectangle.Width / 7)), new SolidBrush(Color.Green), (ClientRectangle.Width - (ClientRectangle.Width / 5.5f)), (ClientRectangle.Top * 1.5f));
                    }
                    else if (pila.Count >= 5)
                    {
                        gr.DrawString(pila.Count.ToString(), new Font("Arial", ((int)ClientRectangle.Width / 8)), new SolidBrush(Color.Green), (ClientRectangle.Width - (ClientRectangle.Width / 5.5f)), (ClientRectangle.Top * 1.5f));
                    }
                    else
                    {
                        gr.DrawString(pila.Count.ToString(), new Font("Arial", ((int)ClientRectangle.Width / 7)), new SolidBrush(Color.Red), (ClientRectangle.Width - (ClientRectangle.Width / 5.5f)), (ClientRectangle.Top * 1.5f));
                    }

                }
            }
        }

        /// <summary>
        /// Mantè la relació entre l'amplada i l'alçada de la PiloDominion
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            Width = (int)(Height * Carta.relacioAltAmple);
            Refresh();
        }

        /// <summary>
        /// Posa la CartaDominion especificada al cim de la PiloDominion.
        /// </summary>
        /// <param name="carta"></param>
        public virtual void Posar(CartaDominion carta)
        {
            pila.Push(carta);
            ImatgeDeFons =(Bitmap) carta.BackgroundImage;
            Refresh();
        }

        /// <summary>
        /// Elimina la CartaDominion del cim del PiloDominion. Si el PiloDominion és buit, genera una excepció.
        /// </summary>
        /// <returns></returns>
        public virtual CartaDominion Robar()
        {
            if (!(Buida))
            {

                CartaDominion carta = pila.Pop();
                Refresh();
                return carta;
            }
            return null;
        }
    }
}
