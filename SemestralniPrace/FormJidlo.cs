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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (!nazevPokrmu.Equals(textBoxNazevPokrmu.Text))
            {
                //když se změní název, tak vyhodit dialog, jestli ho chce změnit 
                //jinak zůstane stejný

            }

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void nastavListView()
        {
            
        }
    }
}
