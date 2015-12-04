using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaVictoria
{
    public abstract partial class CartaVictoria : CartaDominion
    {
        protected int puntsDeVictoria;
        #region Propietats
        public override bool EsCartaDeAccio
        {
            get
            {
                return false;
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
                return true;
            }
        }
        public int PuntsDeVictoria
        {
            get { return puntsDeVictoria; }

        }
        #endregion
        public CartaVictoria()
        {
            InitializeComponent();
        }
    }
}
