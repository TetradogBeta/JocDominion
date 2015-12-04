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
    public abstract partial class Carta : UserControl
    {
        protected bool caraAmunt;


        internal Bitmap imatgeAnvers;


        internal Bitmap imatgeRevers;


        public static float relacioAltAmple=0.7f;


        protected bool seleccionada;



        #region Propietats
        public bool Seleccionada
        {
            get { return seleccionada; }
            set { if(seleccionada!=value){seleccionada = value; Refresh();} }
        }
  
        public static float RelacioAltAmple
        {
            get { return relacioAltAmple; }
            set { relacioAltAmple = value; }
        }
     
        public Bitmap ImatgeRevers
        {
            get { return imatgeRevers; }
            set { imatgeRevers = value; }
        }
        public Bitmap ImatgeAnvers
        {
            get { return imatgeAnvers; }
            set { imatgeAnvers = value; }
        }
        public bool CaraAmunt
        {
            get { return caraAmunt; }
            set { if (caraAmunt != value) { caraAmunt = value; Refresh(); } }
        }
        #endregion  

        public Carta()
        {
            InitializeComponent();
            BackgroundImageLayout = ImageLayout.Stretch;
            Width =(int)( Height * Carta.relacioAltAmple);
        
           
            Refresh();
            
        }
        protected override void OnResize(EventArgs e)
        {
         
            Width = (int)(Height * Carta.relacioAltAmple);
            Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
          
          BackgroundImage = DonamImatge();
        
        
           
            if (seleccionada)
            {

                Graphics paper = this.CreateGraphics();
                paper.DrawRectangle(new Pen(new SolidBrush(Color.GreenYellow),10f), ClientRectangle);
            }
            

        }
        private Bitmap DonamImatge()
        {
            
            if (caraAmunt)
                return ImatgeAnvers;
            else
               return ImatgeRevers;
       
        }

    }
}
