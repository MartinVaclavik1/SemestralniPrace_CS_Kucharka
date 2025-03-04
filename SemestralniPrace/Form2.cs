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

        public (int,string) hodnota()
        {
            return (pocet,nazev);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pocet = (int)numericUpDown1.Value;
            nazev = textBox1.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
