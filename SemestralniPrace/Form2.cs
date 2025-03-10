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
    public partial class Form2: Form
    {
        private int pocet;
        private string nazev;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string nazev, int pocet)
        {
            InitializeComponent();
            textBox1.Text = this.nazev = nazev;
            numericUpDown1.Value = this.pocet = pocet;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!nazev.Equals(textBox1.Text))
            {
                if(MessageBox.Show($"Vypadá to, že jste změnil název ingredience. Opravdu chcete přejmenovat \"{nazev}\" na \"{textBox1.Text}\"  ? (všechna spojení na tuto ingredienci zůstanou stejná)", "Název změněn", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Databaze.VlozNeboUpravDataZDatabaze($"update Ingredience set nazev_ingredience = \'{textBox1.Text}\' " +
                    $"where nazev_ingredience = \'{nazev}\'");
                    nazev = textBox1.Text;
                }
            }

            if (pocet != (int)numericUpDown1.Value) {
                Databaze.VlozNeboUpravDataZDatabaze($"update IngredienceVeSkladu set pocet = {(int)numericUpDown1.Value} where id_ingredience = " +
                        $"(select i.id_ingredience from Ingredience i where i.nazev_ingredience = \'{nazev}\')");
            }

            
            this.Close();
        }
    }
}
