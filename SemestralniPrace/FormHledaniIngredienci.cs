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
            if(comboIngredience.Visible == false)
            {
                //TODO uložit data z textboxu + checknout, jestli to už neexistuje v db a pak přidat
            }

            string ingredience = comboIngredience.SelectedItem.ToString().Trim();
            //Databaze.VlozNeboUpravDataZDatabaze("");
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
