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
    public partial class FormPridatIngredience : Form
    {
        private int posledniIndex;
        public FormPridatIngredience()
        {
            InitializeComponent();
            NastavComboBox();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            string ingredience = null;
            int pocet = (int)numericUpDownPocet.Value;

            if (textBoxNovy.Visible)
            {
                //vytvořit novou ingredienci
                ingredience = textBoxNovy.Text.Trim();
                if (string.IsNullOrEmpty(ingredience))
                {
                    MessageBox.Show("Nelze vkládat prázdné hodoty", "CHYBA");
                    return;
                }
                if (Databaze.ZjistiNazev($"select nazev_ingredience from Ingredience " +
                    $"where nazev_ingredience=\"{ingredience}\"") == null)
                {
                    Databaze.VlozNeboUpravDataZDatabaze($"insert into Ingredience values(null, \"{ingredience}\")");
                }
            }
            else
            {
                ingredience = comboIngredience.SelectedItem.ToString().Trim();
            }



            //zkontrolovat, jestli existuje spojení mezi ingrediencí a skladem
            //jestli jo, tak UPDATE table
            //jestli ne, tak INSERT 
            if (Databaze.ZjistiNazev($"select i.nazev_ingredience from Ingredience i " +
                $"left join IngredienceVeSkladu ivs using(id_ingredience) " +
                $"where i.nazev_ingredience = \"{ingredience}\" and ivs.id_skladu = 1;") != null)
            {
                //spojení skladu a ingredience
                Databaze.VlozNeboUpravDataZDatabaze($"update IngredienceVeSkladu " +
                $"set pocet = {pocet} " +
                $"where id_ingredience = (select id_ingredience from Ingredience i where i.nazev_ingredience = \"{ingredience}\") " +
                $"and id_skladu = 1");
            }
            else
            {
                Databaze.VlozNeboUpravDataZDatabaze($"insert into IngredienceVeSkladu " +
                $"values((select id_ingredience from Ingredience i where i.nazev_ingredience = \"{ingredience}\"), " +
                $"1, {pocet})");
                textBoxNovy.Clear();
                numericUpDownPocet.Value = 0;
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NastavComboBox()
        {
            List<string> ingredience = Databaze.ZjistiNazev("select nazev_ingredience from Ingredience " +
                "except select i.nazev_ingredience from Ingredience i " +
                "left join IngredienceVeSkladu ivs using(id_ingredience) where ivs.pocet > 0");

            if(ingredience == null)
            {
                textBoxNovy.Width = comboIngredience.Width;
                comboIngredience.Visible = false;
                textBoxNovy.Visible = true;
                return;
            }


            foreach (var ing in ingredience)
            {
                comboIngredience.Items.Add(ing);
            }

            posledniIndex = comboIngredience.Items.Add("přidat novou ingredienci");
            comboIngredience.SelectedIndex = 0;
        }

        private void btnZpet_Click(object sender, EventArgs e)
        {
            comboIngredience.Visible = true;
            textBoxNovy.Visible = false;
            btnZpet.Visible = false;
            comboIngredience.SelectedIndex = 0;
        }

        private void comboIngredience_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboIngredience.SelectedIndex == posledniIndex)
            {
                comboIngredience.Visible = false;
                textBoxNovy.Visible = true;
                btnZpet.Visible = true;
            }
        }
    }
}
