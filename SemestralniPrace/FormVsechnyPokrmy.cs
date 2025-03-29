using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemestralniPrace
{
    public partial class FormVsechnyPokrmy : Form
    {
        public FormVsechnyPokrmy()
        {
            InitializeComponent();
            AktualizujView();
        }

        private void btnUprav_Click(object sender, EventArgs e)
        {
            if (listView_pokrmy.SelectedItems.Count > 0)
            {
                string nazevPokrmu = listView_pokrmy.SelectedItems[0].Text.Trim();
                FormJidlo formJidlo = new FormJidlo(nazevPokrmu);


                formJidlo.ShowDialog();
                AktualizujView();
            }
            else
            {
                MessageBox.Show("Nevybrán žádný pokrm k úpravě", "Chyba!");
            }
        }

        private void AktualizujView()
        {
            List<string> list = Databaze.ZjistiNazev("select nazev from jidlo");
            listView_pokrmy.Clear();
            if (list != null)
            {
                foreach (var item in list)
                {
                    listView_pokrmy.Items.Add(new ListViewItem(item));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nazev = Interaction.InputBox("zadej nazev", "nazev").Trim();

            if (String.IsNullOrEmpty(nazev))
            {
                //MessageBox.Show("Nelze vkládat NULL", "chyba");
                return;
            }

            List<string> list = Databaze.ZjistiNazev("select nazev from Jidlo");

            foreach (var item in list)
            {
                if (nazev.Equals(item))
                {
                    MessageBox.Show("Pokrm již existuje v databázi", "chyba");
                    return;
                }
            }

            Databaze.VlozNeboUpravDataZDatabaze($"INSERT INTO Jidlo VALUES (null ,\"{nazev}\")");


            FormJidlo formJidlo = new FormJidlo(nazev);


            formJidlo.ShowDialog();
            AktualizujView();


            AktualizujView();
        }

        private void listView_pokrmy_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnUprav_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listView_pokrmy.SelectedItems.Count > 0)
            {
                string nazevPokrmu = listView_pokrmy.SelectedItems[0].Text.Trim();

                if (MessageBox.Show($"Opravdu chcete smazat pokrm {nazevPokrmu}?", "Smazání pokrmu", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Databaze.VlozNeboUpravDataZDatabaze($"delete from IngredienceVJidle where id_jidla = (select id_jidla from Jidlo where nazev = \"{nazevPokrmu}\")");
                    Databaze.VlozNeboUpravDataZDatabaze($"delete from Jidlo where nazev = \"{nazevPokrmu}\"");

                    AktualizujView();
                }
            }
            else
            {
                MessageBox.Show("Nevybrán žádný pokrm k odebrání", "Chyba!");
            }
        }
    }
}
