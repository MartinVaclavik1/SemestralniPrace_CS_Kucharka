using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemestralniPrace
{
    public partial class FormKontrolaOdebraniIngredienci : Form
    {
        private string nazevPokrmu;
        private List<(int, string)> list;
        private int posledniEditovanaHodnota;
        public FormKontrolaOdebraniIngredienci()
        {
            InitializeComponent();
        }

        public FormKontrolaOdebraniIngredienci(string nazevPokrmu, List<(int, string)> list)
        {
            InitializeComponent();
            this.nazevPokrmu = nazevPokrmu;
            this.list = list;
            nastavGridView();
        }

        private void nastavGridView()
        {

            dataGridViewIngredience.Columns[1].ValueType = typeof(int);
            dataGridViewIngredience.Rows.Clear();
            foreach (var item in list)
            {
                dataGridViewIngredience.Rows.Add(item.Item2, item.Item1);
            }
        }

        private void dataGridViewIngredience_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Chyba v zadávání dat!");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewIngredience.Rows.Count; i++)
            {
                var radek = dataGridViewIngredience.Rows[i].Cells;
                string nazev = (string)radek[0].Value;
                int pocet = (int)radek[1].Value;

                if (pocet == 0)
                    continue;

                //nejdříve zkontroluje všechny hodnoty a až poté se je v jiném loopu pokusí odebrat ze skladu
                var hodnota = Databaze.ZjistiCislo($"select pocet from IngredienceVeSkladu " +
                    $"left join Ingredience using(id_ingredience) " +
                    $"left join Sklad using(id_skladu) " +
                    $"where nazev_ingredience = \"{nazev}\"");

                if (hodnota != null)
                {
                    if (!(pocet <= hodnota[0]))
                    {
                        MessageBox.Show($"Ve skladu není dostatek ingrediencí na odebrání: {nazev}, v počtu: {pocet}",
                            "Chyba");
                        DialogResult = DialogResult.Abort;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show($"Ve skladu není dostatek ingrediencí na odebrání: {nazev}, v počtu: {pocet}",
                            "Chyba");
                    DialogResult = DialogResult.Abort;
                    return;
                }
                
            }
            
            //TODO alter table set pocet_ing = pocet_ing - pocet where nazev
            for (int i = 0; i < dataGridViewIngredience.Rows.Count; i++)
            {
                var radek = dataGridViewIngredience.Rows[i].Cells;
                string nazev = (string)radek[0].Value;
                int pocet = (int)radek[1].Value;

                if(pocet == 0)
                    continue;

                Databaze.VlozNeboUpravDataZDatabaze($"UPDATE IngredienceVeSkladu " +
                    $"SET pocet = pocet - {pocet} " +
                    $"WHERE id_ingredience = " +
                    $"(select id_ingredience from Ingredience where nazev_ingredience = \"{nazev}\")");
            }
            //TODO
            
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridViewIngredience_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;

            var cell = dataGridViewIngredience.Rows[row].Cells;
            posledniEditovanaHodnota = (int)cell[column].Value; //100% jde o int, protože jiné columns nejdou editovat
        }

        private void dataGridViewIngredience_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;

            var cell = dataGridViewIngredience.Rows[row].Cells;

            if ((int)cell[column].Value < 0)
            {
                MessageBox.Show("Nelze zadávat záporné hodoty", "Chyba");
                cell[column].Value = posledniEditovanaHodnota;
            }
        }
    }
}
