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
    public partial class FormHledaniIngredienci: Form
    {
        private string nazevPokrmu;
        private int posledniIndex;
        public FormHledaniIngredienci(string nazevPokrmu)
        {
            InitializeComponent();
            this.nazevPokrmu = nazevPokrmu;
            NastavComboBox();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string ingredience = null;
            int pocet = (int)numericUpDownPocet.Value;
            if(comboIngredience.Visible == false)
            {
                
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
            //checknout, jestli už není přiřazeno id a pak přidat
            if(Databaze.ZjistiNazev($"select i.nazev_ingredience from Ingredience i " +
                $"left join IngredienceVJidle using(id_ingredience) " +
                $"left join Jidlo j using(id_jidla) " +
                $"where i.nazev_ingredience = \"{ingredience}\" and j.nazev = \"{nazevPokrmu}\";") == null)
            {
                //spojení jídla a ingredience
                Databaze.VlozNeboUpravDataZDatabaze($"insert into IngredienceVJidle " +
                $"values((select id_ingredience from Ingredience i where i.nazev_ingredience = \"{ingredience}\"), " +
                $"(select id_jidla from Jidlo where Jidlo.nazev = \"{nazevPokrmu}\"), {pocet})");
                
                this.Close();
            }
            else
            {
                MessageBox.Show("Tato ingredience je již přiřazena k aktuálně vybranému pokrmu", "Chyba!!");
                textBoxNovy.Clear();
                numericUpDownPocet.Value = 0;
            }
            
            
        }

        private void NastavComboBox()
        {
            List<string> ingredience = Databaze.ZjistiNazev($"select nazev_ingredience from Ingredience " +
                $"except select i.nazev_ingredience from Ingredience i " +
                $"left join IngredienceVJidle using(id_ingredience) " +
                $"left join Jidlo j using(id_jidla) where j.nazev = \"{nazevPokrmu}\";");
            
            if(ingredience == null)
            {
                MessageBox.Show("Žádné aktuální ingredience nezle přidat! (lze vytvořit novou)", "Chyba!");
            }

            foreach(var ing in ingredience){
                comboIngredience.Items.Add(ing);
            }

            posledniIndex = comboIngredience.Items.Add("přidat novou ingredienci");
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

        private void btnZpet_Click(object sender, EventArgs e)
        {
            comboIngredience.Visible = true;
            textBoxNovy.Visible = false;
            btnZpet.Visible = false;
            comboIngredience.SelectedIndex = 0;
        }
    }
}
