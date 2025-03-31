using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum VazebniTabuka
{
    SKLAD,
    POKRM
}

namespace SemestralniPrace
{
    public partial class Ingredience: Form
    {
        private int pocet;
        private string nazev;
        private VazebniTabuka tabulka;
        public Ingredience()
        {
            InitializeComponent();
        }

        public Ingredience(string nazev, int pocet, VazebniTabuka tabulka)
        {
            InitializeComponent();
            textBox1.Text = this.nazev = nazev;
            numericUpDown1.Value = this.pocet = pocet;
            this.tabulka = tabulka;
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
                if(tabulka == VazebniTabuka.SKLAD)
                {
                    Databaze.VlozNeboUpravDataZDatabaze($"update IngredienceVeSkladu set pocet = {(int)numericUpDown1.Value} where id_ingredience = " +
                       $"(select i.id_ingredience from Ingredience i where i.nazev_ingredience = \'{nazev}\')");
                }
                else
                {
                    Databaze.VlozNeboUpravDataZDatabaze($"update IngredienceVJidle set pocet = {(int)numericUpDown1.Value} where id_ingredience = " +
                       $"(select i.id_ingredience from Ingredience i where i.nazev_ingredience = \'{nazev}\')");
                }
               
            }

            
            this.Close();
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, null);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, null);
            }
        }
    }
}
