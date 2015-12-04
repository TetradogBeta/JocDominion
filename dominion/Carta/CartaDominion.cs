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
  public  enum cartes
    {
        //accio 25
        Aldea, Aventurer, Banquet, Bibloteca, Bruxia, Burocrata, Canceller, Capella,
        Enviat, Espia, Ferreria, Festival, Fossat, Laboratoria, Lladre, Llenyataires,
        Mercat, Milicua, Mina, Prestador, Remodelar, SalaDelTron, SalaDelConcell, Soterrani, Taller,

        //tresor 3 
        Coure, Or, Plata,

        //Victoria 5
        Ducat, Finca, Jardins, Malediccio, Provincia

    }
    public  abstract partial class CartaDominion : Carta,IComparable<CartaDominion>

    {
        protected int cost;


        protected int valor;


        #region Propietats
        public int Valor
        {
            get { return valor; }

        }
        public int Cost
        {
            get { return cost; }

        }
        public abstract bool EsCartaDeAccio
        { get; }
        public abstract bool EsCartaDeTresor
        { get; }
        public abstract bool EsCartaDeVictoria
        { get; }
        #endregion
        public CartaDominion()
        {
            InitializeComponent();
            base.imatgeRevers = dominion.ImatgesCartes.Revers;
            DoubleBuffered = true;
            
        }
        public override string ToString()
        {
            string[] camps= base.ToString().Split('.');
            return camps[camps.Length - 1];
        }

        public int CompareTo(CartaDominion other)
        {
          //victoria,accio,tresor
            //de mes a menys punts de cost
            int valor;
            if (other.EsCartaDeVictoria)
            {
                if (EsCartaDeVictoria)
                    valor = cost - other.cost;
                else
                    valor = -1;

            }
            else if (other.EsCartaDeAccio)
            {
                if (EsCartaDeVictoria)
                    valor = 1;
                else if (EsCartaDeAccio)
                    valor = cost - other.cost;
                else
                    valor = -1;
            }
            else
            {
                if (EsCartaDeVictoria)
                    valor = 1;
                else if (EsCartaDeAccio)
                    valor = -1;
                else
                    valor = cost - other.cost;
            }
            return valor;

        }
      
        public static CartaDominion DonamCarta(string nomCarta)
        {
            string tipusCarta = "";
            switch (nomCarta)
            {
                case "Aldea":
                case "Aventurer":
                case "Banquet":
                case "Biblioteca":
                case "Bruixa":
                case "Burocrata":
                case "Canceller":
                case "Capella":
                case "Enviat":
                case "Espia":
                case "Ferreria":
                case "Festival":
                case "Fossat":
                case "Laboratori":
                case "Lladre":
                case "Llenyataires":
                case "Mercat":
                case "Milicia":
                case "Mina":
                case "Prestador":
                case "Remodelar":
                case "SalaDelConsell":
                case "SalaDelTron":
                case "Soterrani":
                case "Taller":
                    tipusCarta = "dominion.CartaAccio." + nomCarta + "." + nomCarta; break;
                case "Coure":
                case "Or":
                case "Plata":
                    tipusCarta = "dominion.CartaTresor." + nomCarta + "." + nomCarta; break;
                case "Ducat":
                case "Finca":
                case "Jardins":
                case "Malediccio":
                case "Provincia":
                    tipusCarta = "dominion.CartaVictoria." + nomCarta + "." + nomCarta; break;
            }


            Type tipus = Type.GetType(tipusCarta);
                CartaDominion carta = Activator.CreateInstance(tipus) as CartaDominion;
                return carta;
        }

    }
}
