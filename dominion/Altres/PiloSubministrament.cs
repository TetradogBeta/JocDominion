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
    public partial class PiloSubministrament : PiloDominion
    {
        internal Button compra;
        internal Button regal;
        public event EventHandler clicCompra;
        public event EventHandler clicRegal;
        
        public PiloSubministrament()
        {
            InitializeComponent();

            regal = new Button();
            regal.Tag = this;
            regal.Visible = false;
            Controls.Add(regal);
            compra = new Button();
            compra.Click += new EventHandler(clikCompra);
            regal.Click += new EventHandler(clikRegal);
            compra.Tag = this;
            BackColor = Color.Transparent;
            MostraNumeroDeCartes = true;
            Controls.Add(compra);
            compra.Visible = false;
            BackgroundImage = dominion.CartesIMG.Revers;
            BackgroundImageLayout = ImageLayout.Stretch;
            regal.BackgroundImageLayout = ImageLayout.Stretch;
            regal.BackgroundImage = (Bitmap)dominion.CartesIMG.Regal;
            compra.BackgroundImage = (Bitmap)dominion.CartesIMG.Compra;

            compra.BackgroundImageLayout = ImageLayout.Stretch;
            OnResize(new EventArgs());
        }

        private void clikRegal(object sender, EventArgs e)
        {
            if(clicRegal!=null)
            clicRegal(new object(), new EventArgs()); 
        }

        private void clikCompra(object sender, EventArgs e)
        {
            if(clicCompra!=null)
            clicCompra(new object(), new EventArgs());
        }

     
        public Button Regal
        {
            get { return regal; }
            set { regal = value; }
        }
        public Button Compra
        {
            get { return compra; }
            set { compra = value; }
        }
        /// <summary>
        /// Amaga el botó de compra
        /// </summary>
        public void DeshabilitaCompra()
        {
            compra.Visible = false;
        }
        /// <summary>
        /// Amaga el botó de compra
        /// </summary>
        public void DeshabilitaRegal()
        {
            regal.Visible = false;
        }
        /// <summary>
        /// Mostra el botó si el el PiloSubministrament no està buit i si les CartaDominion que conté no tenen un cost superior al preu que se li passa.
        /// </summary>
        /// <param name="preuMaxim">Preu màxim que han de tenir les CartaDominion que componen el PiloSubministrament.</param>
        public void HabilitaCompra(int preuMaxim)
        {
            CartaDominion carta = PrimeraCarta;
            if(carta!=null)
            if (carta.Cost <= preuMaxim)//cost
            {
                compra.Visible = true;
            }
        }
        /// <summary>
        /// Mostra el botó si el el PiloSubministrament no està buit i si les CartaDominion que conté no tenen un cost superior al preu que se li passa.
        /// </summary>
        /// <param name="preuMaxim">Preu màxim que han de tenir les CartaDominion que componen el PiloSubministrament.</param>
        public void HabilitaRegal(int preuMaxim)
        {
             CartaDominion carta=PrimeraCarta;

             if (carta.Cost <= preuMaxim)//cost
             {
                 regal.Visible = true;
             }
        }
        /// <summary>
        /// Mantè la relació entre l'amplada i l'alçada de la PiloDominion i manté l'aspecte del botó de compra o del de regal
        /// </summary>
        /// <param name="e">Un En líneaEventArgs que conté les dades de l'esdeveniment.</param>
        protected override void OnResize(EventArgs e)
        {

            base.OnResize(e);
            if (compra != null)
            {
               
                compra.Height = Width / 2;
                compra.Width = Width / 2;
                compra.Location = new Point(Width/20, Height - compra.Height);
                

                  
                regal.Height = Width / 2;
                regal.Width = Width / 2;
                regal.Location = new Point(Width - regal.Height - Width / 20, Height - compra.Height);
             
             
            }
        }
        public override void Posar(CartaDominion carta)
        {
            carta.CaraAmunt = true;
            base.Posar(carta);
        }
        /// <summary>
        /// Elimina la CartaDominion del cim del PiloSubministrament. Si el PiloSubministrament és buit, genera una excepció.
        /// </summary>
        /// <returns></returns>
     
    }
}
