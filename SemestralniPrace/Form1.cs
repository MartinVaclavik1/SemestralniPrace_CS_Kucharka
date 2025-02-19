using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemestralniPrace
{
    public partial class Form1: Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZjistiZDatabaze("select * from Sklad");



            /*  odebrani z databaze
            *   VlozNeboUpravDataZDatabaze("delete from Sklad where id_skladu = 2");
            *   
            *   vlozeni do databaze
            *   VlozNeboUpravDataZDatabaze("insert into Sklad values(null, 'test')");
            */
        }
        /// <summary>
        /// Příkaz na zjištění dat z databáze ---TODO--- zatím vypisuje do cmd. pak předělat, ať vrací pole?
        /// </summary>
        /// <param name="prikaz">příkat, který chcete udělat nad databází</param>
        private void ZjistiZDatabaze(string prikaz)
        {
            //zjištění adresy, kde je uložen projekt a nalezení databáze
            string directory = Application.StartupPath;
            int odebrany = directory.IndexOf("\\SemestralniPrace\\bin\\Debug");
            directory = directory.Substring(0, odebrany) + "\\databaze.sqlite";
            //Console.WriteLine(directory);

            using (SQLiteConnection conn = new SQLiteConnection("data source=" + directory))
            {
                using (SQLiteCommand com = new SQLiteCommand())
                {
                    com.CommandText = prikaz;
                    com.Connection = conn;
                    conn.Open();
                    var reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var nazev = reader.GetString(1);
                        Console.WriteLine($"{id}, {nazev}");
                    }


                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Příkaz na vkládání/úpravy dat v databázi
        /// </summary>
        /// <param name="prikaz">příkat, který chcete udělat nad databází</param>
        private void VlozNeboUpravDataZDatabaze(string prikaz)
        {
            //zjištění adresy, kde je uložen projekt a nalezení databáze
            string directory = Application.StartupPath;
            int odebrany = directory.IndexOf("\\SemestralniPrace\\bin\\Debug");
            directory = directory.Substring(0, odebrany) + "\\databaze.sqlite";
            //Console.WriteLine(directory);

            using (SQLiteConnection conn = new SQLiteConnection("data source=" + directory))
            {
                using (SQLiteCommand com = new SQLiteCommand())
                {
                    com.CommandText = prikaz;
                    com.Connection = conn;
                    conn.Open();
                    com.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }
    }
}
