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

            AktualizujListView();
        }

        private void AktualizujListView()
        {
            List<string> list = Databaze.ZjistiNazev($"select i.nazev_ingredience from Jidlo j " +
                $"left join IngredienceVJidle ivj\r\nusing(id_jidla) " +
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
    }
}
