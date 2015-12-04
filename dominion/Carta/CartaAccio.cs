using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaAccio
{
    public delegate void FiExecutaAccio();
    public abstract partial class CartaAccio : CartaDominion
    {
        protected int accionsAdicionals;

        public event FiExecutaAccio fiAccio;
        protected int cartesAdicionals;


        protected int compresAdicionals;


        #region Propietats
        public int CompresAdicionals
        {
            get { return compresAdicionals; }
            set { compresAdicionals = value; }
        }
        public int CartesAdicionals
        {
            get { return cartesAdicionals; }
            set { cartesAdicionals = value; }
        }
        public int AccionsAdicionals
        {
            get { return accionsAdicionals; }
            set { accionsAdicionals = value; }
        }
        public override bool EsCartaDeAccio
        {
            get
            {
                return true;
            }
        }
        public override bool EsCartaDeTresor
        {
            get
            {
                return false;
            }
        }
        public override bool EsCartaDeVictoria
        {
            get
            {
                return false;
            }
        }
        public virtual bool EsCartaAtac
        {
            get { return false; }
        }
        public virtual bool EsCartaReaccio
        {
            get { return false; }
        }
        #endregion
        public CartaAccio()
        {
            InitializeComponent();
    
            
        }
        public abstract void ExecutaAccio(dominion.Altres.Partida partida);
       
            /*Roba del piló de cartes per robar tantes cartes como indiqui la i les afegeix
             * a la del jugador actual Després executa l'acció específica de la carta. I finalment executa el final de fase.*/
      

    }
}
