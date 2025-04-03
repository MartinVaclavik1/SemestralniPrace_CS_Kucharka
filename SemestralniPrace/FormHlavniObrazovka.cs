using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemestralniPrace
{
    //TODO pridat automatické odebrání počtu použitých Ingrediencích (otevře se
    //okno se všemi ingrediencemi a počtem, kde by šlo změnit, kolik se toho použilo [0 pro nic]
    //a pak se to automaticky odebere ze skladu - update table pocet = pocet - pocet2 ve for loopu)
    public partial class FormHlavniObrazovka : Form
    {
        public static List<(string, string)> list = new List<(string, string)>();
        public FormHlavniObrazovka()
        {
            InitializeComponent();
            AktualizujViews();
            toolTip.SetToolTip(listView_pokrmy, "klikněte dvakrát na vybraný pokrm pro úpravu");
            toolTip.SetToolTip(listView_ingredience, "klikněte dvakrát na vybranou ingredienci pro úpravu");
            dataGridViewIngredience.Columns[1].ValueType = typeof(int);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                string nazev = Interaction.InputBox("zadej nazev", "nazev");
                nazev = nazev.Trim();
                //Console.WriteLine(nazev);

                //int pocet = int.Parse(Interaction.InputBox("zadej pocet", "pocet"));


                //zjistí id dané ingredience (pokud existuje)
                List<int> list = Databaze.ZjistiCislo($"select i.id_ingredience from Ingredience i where nazev_ingredience = \'{nazev}\'");
                if (list == null)
                {
                    //vloží ingredienci do tabulky Ingredience
                    Databaze.VlozNeboUpravDataZDatabaze($"INSERT INTO Ingredience VALUES (null ,\'{nazev}\')");
                    //vloží id ingredience - nyní už 100% existuje
                    list = Databaze.ZjistiCislo($"select i.id_ingredience from Ingredience i where nazev_ingredience = \'{nazev}\'");

                }
                int ingredience = list[0];
                //zkontrolovat, jestli je ve vazební tabulce a pak buď přidat, nebo změnit
                List<int> existuje = Databaze.ZjistiCislo($"select i.id_skladu from IngredienceVeSkladu i where i.id_ingredience = {ingredience}");
                Ingredience form;
                if (existuje != null)
                {
                    //updatne ingredienci na danou hodnotu
                    //MessageBox.Show("ingredience existuje");
                    //Databaze.VlozNeboUpravDataZDatabaze($"UPDATE IngredienceVeSkladu SET pocet = {pocet} WHERE id_ingredience = {ingredience} and id_skladu = 1");
                    List<int> pocet = Databaze.ZjistiCislo($"select i.pocet from IngredienceVeSkladu i where i.id_ingredience = {ingredience}");
                    form = new Ingredience(nazev, pocet[0], VazebniTabuka.SKLAD);
                }
                else
                {
                    //vloží novou ingredienci do vazební tabulky IngredienceVeSKladu

                    Databaze.VlozNeboUpravDataZDatabaze($"INSERT INTO IngredienceVeSkladu VALUES ({ingredience}, 1 ,0)");
                    form = new Ingredience(nazev, 0, VazebniTabuka.SKLAD);
                }


                form.ShowDialog();
            }
            catch (Exception)
            {
                Console.WriteLine("Chyba při zadávání");
            }
            */

            FormPridatIngredience form = new FormPridatIngredience();
            form.ShowDialog();

            AktualizujViews();
        }

        private List<string> ZjistiNazevIngredienceAPocetZeSkladu1()
        {
            return Databaze.ZjistiNazevAPocetKs("select * from ViewNazevAPocetIngVeSkladu1 where pocet > 0");
            //return ZjistiNazevAPocetKs("select ing.nazev_ingredience, " +
            //"i.pocet from IngredienceVeSkladu i left join Ingredience ing " +
            //"where i.id_ingredience = ing.id_ingredience and i.id_skladu = 1");
        }
        private void AktualizujListViewIngredience()
        {
            List<string> list = ZjistiNazevIngredienceAPocetZeSkladu1();
            listView_ingredience.Clear();
            if (list != null)
            {
                foreach (var item in list)
                {
                    listView_ingredience.Items.Add(new ListViewItem((string)item));
                }
            }


            List<(int, string)> list2 = Databaze.ZjistiIntAString("select pocet, nazev_ingredience from ViewNazevAPocetIngVeSkladu1 where pocet > 0");
            dataGridViewIngredience.Rows.Clear();
            if (list2 != null)
            {
                foreach (var item in list2)
                {
                    dataGridViewIngredience.Rows.Add(item.Item2, item.Item1);
                    //listView_ingredience.Items.Add(new ListViewItem((string)item));
                }
            }
        }


        private void AktualizujListViewPokrmy()
        {
            List<string> list = Databaze.ZjistiNazevMoznehoJidla();
            listView_pokrmy.Clear();
            if (list != null)
            {
                foreach (var item in list)
                {
                    listView_pokrmy.Items.Add(new ListViewItem(item));
                }
            }
        }

        private void AktualizujViews()
        {
            AktualizujListViewIngredience();
            AktualizujListViewPokrmy();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView_pokrmy.SelectedItems.Count > 0)
            {
                string nazevPokrmu = listView_pokrmy.SelectedItems[0].Text.Trim();
                FormJidlo formJidlo = new FormJidlo(nazevPokrmu);

                formJidlo.ShowDialog();
                AktualizujViews();
            }
            else
            {
                MessageBox.Show("Nevybrán žádný pokrm k úpravě", "Chyba!");
            }
        }

        private void listView_ingredience_DoubleClick(object sender, EventArgs e)
        {
            string nazev = zjistiNazevVybraneIngredience();

            if (nazev == null)
            {
                MessageBox.Show("Nevybrána žádná ingredience", "Chyba!!");
            }

            List<(int, string)> list = Databaze.ZjistiIntAString($"select ivs.pocet, " +
                $"i.nazev_ingredience from IngredienceVeSkladu ivs left join Ingredience i using (id_ingredience) where i.nazev_ingredience = \'{nazev}\' ");

            if (list != null)
            {
                //proč nezjistím jen pocet a nazev neberu z proměnný? kdo ví. já ne
                int pocet = list[0].Item1;
                string nazevIngredience = list[0].Item2.ToString();
                Ingredience form = new Ingredience(nazevIngredience, pocet, VazebniTabuka.SKLAD);
                form.ShowDialog();
            }

            AktualizujViews();
        }

        private string zjistiNazevVybraneIngredience()
        {
            var items = listView_ingredience.SelectedItems;
            if (items != null)
            {
                int index = items[0].Text.IndexOf('-');
                string nazev = items[0].Text.Substring(0, index).Trim();
                return nazev;
            }
            return null;
        }

        private void listView_pokrmy_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button3_Click(sender, e);
        }

        private void checkBoxTips_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTips.Checked)
            {
                toolTip.Active = false;
            }
            else
            {
                toolTip.Active = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //zobrazí list view se všemy pokrmy - double click => úprava (FormJidlo)
            //vlož pokrm => inputBox s názvem => zkontroluje, jestli už neexistuje a
            //když ne, tak vytvoří novou entitu a otevře FormJidlo s tím názvem
            FormVsechnyPokrmy pokrmy = new FormVsechnyPokrmy();
            pokrmy.ShowDialog();

            AktualizujViews();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView_ingredience.SelectedItems.Count > 0)
            {
                string nazevIngredience = zjistiNazevVybraneIngredience();

                Databaze.VlozNeboUpravDataZDatabaze($"delete from IngredienceVeSkladu where id_ingredience = (select id_ingredience from Ingredience where nazev_ingredience = \"{nazevIngredience}\")");

                AktualizujViews();
            }
            else
            {
                MessageBox.Show("Nevybrána žádná ingredience k odebrání", "Chyba!");
            }
        }

        private void dataGridViewIngredience_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewIngredience_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dataGridViewIngredience.Rows.Count > 0))
            {
                return;
            }
            //radek
            int radek = e.RowIndex;

            //sloupec - 0, nebo 1
            int sloupec = e.ColumnIndex;


            //dataGridViewIngredience.Columns;
            DataGridViewRow row = this.dataGridViewIngredience.Rows[radek];
            MessageBox.Show(row.Cells[sloupec].Value.ToString());

        }
    }
}
