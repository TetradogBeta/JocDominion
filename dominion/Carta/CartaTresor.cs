using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion.CartaTresor
{
    public abstract partial class CartaTresor : CartaDominion
    {
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
                return true;
            }
        }
        public override bool EsCartaDeVictoria
        {
            get
            {
                return false;
            }
        }
        #endregion
        public CartaTresor()
        {
            InitializeComponent();
        }
    }
}
