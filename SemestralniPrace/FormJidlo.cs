using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemestralniPrace
{
    public partial class FormJidlo: Form
    {
        private string nazevPokrmu;
        public FormJidlo()
        {
            InitializeComponent();
        }

        public FormJidlo(String nazev)
        {
            InitializeComponent();
            nazevPokrmu = textBoxNazevPokrmu.Text = nazev;
            AktualizujListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!nazevPokrmu.Equals(textBoxNazevPokrmu.Text))
            {
                if (MessageBox.Show($"Vypadá to, že jste změnil název pokrmu. Opravdu chcete přejmenovat \"{nazevPokrmu}\" na \"{textBoxNazevPokrmu.Text}\"  ? (všechna spojení na tuto ingredienci zůstanou stejná)", "Název změněn", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Databaze.VlozNeboUpravDataZDatabaze($"update Jidlo set nazev = \'{textBoxNazevPokrmu.Text}\' " +
                    $"where nazev = \'{nazevPokrmu}\'");
                    nazevPokrmu = textBoxNazevPokrmu.Text;
                }
            }

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnPridej_Click(object sender, EventArgs e)
        {
            //TODO nové vyskakovací okno s všemi možnými ingrediencemi mínus ty,
            //které už jsou přidány k receptu

            //string prikaz ="INSERT INTO IngredienceVJidle VALUES " +
            //    "((select id_ingredience from Ingredience where nazev_ingredience = \"cukr\")" +
            //    ",(select id_jidla from Jidlo where nazev = \"domaciPribinacek\")" +
            //    ",10)";
            //Databaze.VlozNeboUpravDataZDatabaze(prikaz);
            FormHledaniIngredienci form = new FormHledaniIngredienci(nazevPokrmu);
            form.ShowDialog();

            AktualizujListView();
        }

        private void AktualizujListView()
        {
            List<string> list = Databaze.ZjistiNazevAPocetKs($"select i.nazev_ingredience, ivj.pocet  from Jidlo j " +
                $"left join IngredienceVJidle ivj using(id_jidla) " +
                $"left join Ingredience i " +
                $"using (id_ingredience) " +
                $"where j.nazev=\"{nazevPokrmu}\"; ");

            listViewIngrediencePokrmu.Clear();

            if (list != null)
            {
                foreach (var item in list)
                {
                    listViewIngrediencePokrmu.Items.Add(new ListViewItem((string)item));
                }
            }
        }

        private void btnOdeber_Click(object sender, EventArgs e)
        {

            var items = listViewIngrediencePokrmu.SelectedItems;
            if (items.Count > 0)
            {
                int index = items[0].Text.IndexOf('-');
                string nazevIngredience = items[0].Text.Substring(0, index).Trim();
                Console.WriteLine(nazevIngredience);
                Databaze.VlozNeboUpravDataZDatabaze($"delete from IngredienceVJidle " +
                    $"where id_jidla = (select id_jidla from Jidlo " +
                    $"where nazev = \"{nazevPokrmu}\") " +
                    $"and id_ingredience = (select id_ingredience from Ingredience " +
                    $"where nazev_ingredience = \"{nazevIngredience}\")");
            }
            else
            {
                MessageBox.Show("Nevybrána žádná ingredience k odstranění", "Chyba!!");
            }

            AktualizujListView();
        }

        private void listViewIngrediencePokrmu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var items = listViewIngrediencePokrmu.SelectedItems;
            string nazevIngredience = null;
            if (items != null)
            {
                int index = items[0].Text.IndexOf('-');
                nazevIngredience = items[0].Text.Substring(0, index).Trim();
            }

            if (nazevIngredience == null)
            {
                MessageBox.Show("Nevybrána žádná ingredience", "Chyba!!");
            }

            List<(int, string)> list = Databaze.ZjistiIntAString($"select ivs.pocet, " +
                $"i.nazev_ingredience from IngredienceVJidle ivs left join Ingredience i using (id_ingredience) where i.nazev_ingredience = \'{nazevIngredience}\' ");

            if (list != null)
            {
                //proč nezjistím jen pocet a nazev neberu z proměnný? kdo ví. já ne
                int pocet = list[0].Item1;
                Ingredience form = new Ingredience(nazevIngredience, pocet, VazebniTabuka.POKRM);
                form.ShowDialog();
            }

            AktualizujListView();
        }
    }
}
