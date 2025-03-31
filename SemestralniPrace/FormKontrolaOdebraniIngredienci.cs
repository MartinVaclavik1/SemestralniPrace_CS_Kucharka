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
    public partial class FormKontrolaOdebraniIngredienci : Form
    {
        private string nazevPokrmu;
        private List<(int, string)> list;
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

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
