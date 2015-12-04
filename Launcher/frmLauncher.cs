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
    public partial class frmMain : Form
    {
        string[] noms;
        public frmMain()
        {
            InitializeComponent();

        }



        private void lstBxLlistaCartes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBxLlistaCartes.SelectedItem != null)
            {
                CartaDominion carta = (CartaDominion)dominion.CartaDominion.DonamCarta(lstBxLlistaCartes.SelectedItem.ToString());
                pbImatgeCarta.Image = (Image)carta.ImatgeAnvers;
                pbImatgeCarta.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }



        private List<string> DonamCartesQueEmFalten()
        {
            List<string> llista = new List<string>(25);
            string[] llistaCartes = Enum.GetNames(typeof(dominion.Altres.TipusSubministraments));
            foreach (string nomCarta in llistaCartes)
            {
                if (!lstLlistaMazoPersonalitzat.Items.Contains(nomCarta))
                {
                    llista.Add(nomCarta);
                }
            }
            return llista;
        }



        private void btnAfegirJugador_Click(object sender, EventArgs e)
        {
            if (lstBxLlistaJugador.Items.Count < 4 && txtBxNom.Text != "")
            {
                lstBxLlistaJugador.Items.Add(txtBxNom.Text);
                txtBxNom.Text = "";
            }
        }
        private void btnEsborrrar_Click(object sender, EventArgs e)
        {
            if (lstBxLlistaJugador.SelectedItem != null)
            {
                lstBxLlistaJugador.Items.Remove(lstBxLlistaJugador.SelectedItem);
            }
        }

        private void btnEscollirCartes_Click(object sender, EventArgs e)
        {
            lstBxLlistaCartes.Items.Clear();
            lstBxLlistaCartes.Items.AddRange(DonamCartesQueEmFalten().ToArray());
            lstBxLlistaMazos.Visible = false;
            lstBxLlistaCartes.Visible = true;

        }

        private void btbMazoPred_Click(object sender, EventArgs e)
        {
            lstBxLlistaMazos.Visible = true;
            lstBxLlistaCartes.Visible = false;
            lstBxLlistaMazos.Items.Clear();

            string[] llistaCartes = Enum.GetNames(typeof(dominion.Altres.TipusMazo));
            foreach (string nomCarta in llistaCartes)
            {
                if (!lstLlistaMazoPersonalitzat.Items.Contains(nomCarta))
                {
                    lstBxLlistaMazos.Items.Add(nomCarta);
                }
            }
        }

        private void btnComençar_Click(object sender, EventArgs e)
        {
            int numJugadors = lstBxLlistaJugador.Items.Count;
            if (lstLlistaMazoPersonalitzat.Items.Count != 10)
            {
                MessageBox.Show("Falten Cartes");
            }
            else if (numJugadors < 2)
            {
                MessageBox.Show("Falten Jugadors");
            }
            else
            {
                noms = new string[lstBxLlistaJugador.Items.Count];

                dominion.Altres.TipusSubministraments[] mazos = new dominion.Altres.TipusSubministraments[10];
                int i = 0;
                foreach (object s in lstLlistaMazoPersonalitzat.Items)
                    mazos[i++] = (dominion.Altres.TipusSubministraments)Enum.Parse(typeof(dominion.Altres.TipusSubministraments), s.ToString());
                i = 0;
                foreach (object s in lstBxLlistaJugador.Items)
                    noms[i++] = s.ToString();
                JocDominion.frmJocDominon form = new JocDominion.frmJocDominon();
               form.ComençaPartida(mazos, noms);
               this.Hide();
               form.Tag = this;
                form.ShowDialog();
                

            }
        }

        private void btnAfegirCarta_Click(object sender, EventArgs e)
        {
            if (lstLlistaMazoPersonalitzat.Items.Count < 10 && lstBxLlistaCartes.SelectedItem != null)
            {
                lstLlistaMazoPersonalitzat.Items.Add(lstBxLlistaCartes.SelectedItem);
                lstBxLlistaCartes.Items.Remove(lstBxLlistaCartes.SelectedItem);
            }
        }

        private void btnBorrarCarta_Click(object sender, EventArgs e)
        {
            if (lstLlistaMazoPersonalitzat.SelectedItem != null)
            {
                lstBxLlistaCartes.Items.Add(lstLlistaMazoPersonalitzat.SelectedItem);
                lstLlistaMazoPersonalitzat.Items.Remove(lstLlistaMazoPersonalitzat.SelectedItem);
            }

        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int i = lstLlistaMazoPersonalitzat.Items.Count;

            lstBxLlistaCartes.Items.Clear();
            lstBxLlistaCartes.Items.AddRange(DonamCartesQueEmFalten().ToArray());
            lstBxLlistaMazos.Visible = false;
            lstBxLlistaCartes.Visible = true;
            while (i < 10)
            {
                lstBxLlistaCartes.SelectedIndex = r.Next(lstBxLlistaCartes.Items.Count);
                lstLlistaMazoPersonalitzat.Items.Add(lstBxLlistaCartes.SelectedItem);
                lstBxLlistaCartes.Items.Remove(lstBxLlistaCartes.SelectedItem);
                i++;
            }

        }

        private void lstBxLlistaMazos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstLlistaMazoPersonalitzat.Items.Clear();
            List<string> llista = new List<string>(11);
            string[] llistaCartes = new string[11];
            if (lstBxLlistaMazos.SelectedItem.ToString() == "VillageSquare")
            {
                llistaCartes = Enum.GetNames(typeof(dominion.Altres.VillageSquare));
            }
            else if (lstBxLlistaMazos.SelectedItem.ToString() == "BigMoney")
            {
                llistaCartes = Enum.GetNames(typeof(dominion.Altres.BigMoney));
            }
            else if (lstBxLlistaMazos.SelectedItem.ToString() == "MidaDistorsio")
            {
                llistaCartes = Enum.GetNames(typeof(dominion.Altres.MidaDistorsio));
            }
            else if (lstBxLlistaMazos.SelectedItem.ToString() == "Interaccio")
            {
                llistaCartes = Enum.GetNames(typeof(dominion.Altres.Interaccio));
            }
            else
            {
                llistaCartes = Enum.GetNames(typeof(dominion.Altres.PrimerJoc));
            }

            foreach (string nomCarta in llistaCartes)
            {
                if (!lstLlistaMazoPersonalitzat.Items.Contains(nomCarta))
                {
                    lstLlistaMazoPersonalitzat.Items.Add(nomCarta);
                }
            }
        }

        private void lstLlistaMazoPersonalitzat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLlistaMazoPersonalitzat.SelectedItem != null)
            {
                CartaDominion carta = (CartaDominion)dominion.CartaDominion.DonamCarta(lstLlistaMazoPersonalitzat.SelectedItem.ToString());
                pbImatgeCarta.Image = (Image)carta.ImatgeAnvers;
                pbImatgeCarta.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        private void lstBxLlistaCartes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstLlistaMazoPersonalitzat.Items.Count < 10 && lstBxLlistaCartes.SelectedItem != null)
            {
                lstLlistaMazoPersonalitzat.Items.Add(lstBxLlistaCartes.SelectedItem);
                lstBxLlistaCartes.Items.Remove(lstBxLlistaCartes.SelectedItem);
            }
        }

        private void lstBxLlistaJugador_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstBxLlistaJugador.SelectedItem != null)
            {
                lstBxLlistaJugador.Items.Remove(lstBxLlistaJugador.SelectedItem);
            }
        }

        private void txtBxNom_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstBxLlistaJugador.Items.Count < 4 && txtBxNom.Text != "")
            {
                lstBxLlistaJugador.Items.Add(txtBxNom.Text);
                txtBxNom.Text = "";
            }
        }
    }
}
