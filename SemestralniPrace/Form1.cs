using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemestralniPrace
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            AktualizujViews();
        }

        //TODO metoda na zjišťování dat z jakékoliv tabulky - zatím je jen ze skladu

        private void button1_Click(object sender, EventArgs e)
        {
            ZjistiZDatabaze("select * from Ingredience");
            //ZjistiZDatabaze("select nazev_ingredience from Ingredience where id_ingredience = 1"); - nutnost parsovat jen string


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
                        try
                        {
                            var id = reader.GetInt32(0);
                            var nazev = reader.GetString(1);
                            Console.WriteLine($"{id}, {nazev}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Chyba");
                        }
                    }


                    conn.Close();
                }
            }
        }

        private void ZjistiZVazebniTabulky(string prikaz)
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
                        try
                        {
                            var id1 = reader.GetInt32(0);
                            var id2 = reader.GetInt32(1);
                            var pocet = reader.GetInt32(2);
                            Console.WriteLine($"ingredience: {id1} sklad: {id2}, {pocet} ks/g");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Chyba");
                        }

                    }


                    conn.Close();
                }
            }
        }

        private List<string> ZjistiNazevAPocetKs(string prikaz)
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
                    List<string> pole = new List<string>();
                    while (reader.Read())
                    {
                        try
                        {
                            var nazev = reader.GetString(0);
                            var pocet = reader.GetInt32(1);
                            //Console.WriteLine($"nazev: {nazev}, {pocet} ks/g");
                            pole.Add($"{nazev} - {pocet} ks/g");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Chyba");
                        }

                    }


                    conn.Close();

                    if (pole.Count > 0)
                    {
                        return pole;
                    }
                    return null;
                }
            }
        }

        private List<string> ZjistiNazev(string prikaz)
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
                    List<string> pole = new List<string>();
                    while (reader.Read()) //TODO skáče pryč
                    {
                        try
                        {
                            var nazev = reader.GetString(0);
                            //Console.WriteLine($"nazev: {nazev}, {pocet} ks/g");
                            pole.Add(nazev);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Chyba");
                        }

                    }


                    conn.Close();

                    if (pole.Count > 0)
                    {
                        return pole;
                    }
                    return null;
                }
            }
        }

        private List<(int, string)> ZjistiIntAString(string prikaz)
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
                    List<(int,string)> pole = new List<(int,string)>();
                    while (reader.Read())
                    {
                        try
                        {
                            var id = reader.GetInt32(0);
                            var nazev = reader.GetString(1);
                            //Console.WriteLine($"nazev: {nazev}, {pocet} ks/g
                            pole.Add((id, nazev));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Chyba");
                        }

                    }


                    conn.Close();

                    if (pole.Count > 0)
                    {
                        return pole;
                    }
                    return null;
                }
            }
        }

        private List<int> ZjistiCislo(string prikaz)
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
                    List<int> pole = new List<int>();
                    while (reader.Read())
                    {
                        try
                        {
                            int cislo = reader.GetInt32(0);
                            pole.Add(cislo);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Chyba");
                        }

                    }


                    conn.Close();

                    if (pole.Count > 0)
                    {
                        return pole;
                    }
                    return null;
                }
            }
        }

        //HÁZELO CHYBU DATABASE IS LOCKED PŘI NÁSLEDNÉM POKUSU O ZMĚNU(UPDATE) DAT
        private bool Existuje(string prikaz)
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
                    try
                    {
                        com.CommandText = prikaz;
                        com.Connection = conn;
                        conn.Open();
                        var reader = com.ExecuteReader();
                        if (reader.Read())
                        {
                            conn.Close();
                            return true;
                        }

                        conn.Close();
                        return false;
                    }
                    catch (Exception)
                    {
                        conn.Close();
                        Console.WriteLine("Chyba");
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Příkaz na vkládání/úpravy dat v databázi
        /// </summary>
        /// <param name="prikaz">příkat, který chcete udělat nad databází</param>
        /// <returns>true/false, zda se vše vykonalo v pořádku</returns>
        private bool VlozNeboUpravDataZDatabaze(string prikaz)
        {

            //zjištění adresy, kde je uložen projekt a nalezení databáze
            string directory = Application.StartupPath;
            int odebrany = directory.IndexOf("\\SemestralniPrace\\bin\\Debug");
            directory = directory.Substring(0, odebrany) + "\\databaze.sqlite";
            //Console.WriteLine(directory);

            using (SQLiteConnection conn = new SQLiteConnection($"data source= {directory}"))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SQLiteCommand com = new SQLiteCommand())
                        {
                            com.Transaction = transaction;
                            com.CommandText = prikaz;
                            com.Connection = conn;
                            com.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch (Exception x)
                    {
                        transaction.Rollback();
                    Interaction.MsgBox(x.Message);
                        return false;
                    }
                    conn.Close();
                }

            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TODO vyskočí okno, které se zeptá co a kolik toho chce přidat
            //(jestli existuje v databázi, tak se jen přidá počet - buď se vytvoří relace do
            //IngredienceVeSkladu, nebo přidá do tabulky počet. jestli ne, tak se nejdřív zeptá,
            //jestli je název správně a pak vytvoří nový prvek v Ingredienci a )

            try
            {
                string nazev = Interaction.InputBox("zadej nazev", "nazev");
                nazev = nazev.Trim();
                //Console.WriteLine(nazev);
                int pocet = int.Parse(Interaction.InputBox("zadej pocet", "pocet"));
                //Console.WriteLine(pocet);

                //zjistí id dané ingredience (pokud existuje)
                List<int> list = ZjistiCislo($"select i.id_ingredience from Ingredience i where nazev_ingredience = \'{nazev}\'");
                if (list == null)
                {
                    //vloží ingredienci do tabulky Ingredience
                    VlozNeboUpravDataZDatabaze($"INSERT INTO Ingredience VALUES (null ,\'{nazev}\')");
                    //vloží id ingredience - nyní už 100% existuje
                    list = ZjistiCislo($"select i.id_ingredience from Ingredience i where nazev_ingredience = \'{nazev}\'");

                }
                int ingredience = list[0];
                //zkontrolovat, jestli je ve vazební tabulce a pak buď přidat, nebo změnit
                List<int> existuje = ZjistiCislo($"select i.id_skladu from IngredienceVeSkladu i where i.id_ingredience = {ingredience}");
                if (existuje != null)
                {
                    //updatne ingredienci na danou hodnotu
                    //Interaction.MsgBox("ingredience existuje");
                    VlozNeboUpravDataZDatabaze($"UPDATE IngredienceVeSkladu SET pocet = {pocet} WHERE id_ingredience = {ingredience} and id_skladu = 1");
                }
                else
                {
                    //vloží novou ingredienci do vazební tabulky IngredienceVeSKladu
                    VlozNeboUpravDataZDatabaze($"INSERT INTO IngredienceVeSkladu VALUES ({ingredience}, 1 ,{pocet})");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Chyba při zadávání");
            }

            AktualizujViews();
        }

        private List<string> ZjistiNazevIngredienceAPocetZeSkladu1()
        {
            return ZjistiNazevAPocetKs("select * from ViewNazevAPocetIngVeSkladu1");
            //return ZjistiNazevAPocetKs("select ing.nazev_ingredience, " +
            //"i.pocet from IngredienceVeSkladu i left join Ingredience ing " +
            //"where i.id_ingredience = ing.id_ingredience and i.id_skladu = 1");
        }
        private void AktualizujListViewIngredience()
        {
            List<string> list = ZjistiNazevIngredienceAPocetZeSkladu1();
            listView_ingredience.Clear();
            if (list != null)
            {
                foreach (var item in list)
                {
                    listView_ingredience.Items.Add(new ListViewItem((string)item));
                }
            }
        }
        private List<string> ZjistiNazevMoznehoJidla()
        {
            return ZjistiNazev("select distinct(j.nazev) from Jidlo j left join IngredienceVJidle ivj using (id_jidla) " +
                "left join(select * from IngredienceVeSkladu where id_skladu = 1) ivs using (id_ingredience) " +
                "except " +
                "select j.nazev from Jidlo j left join IngredienceVJidle ivj using (id_jidla) " +
                "left join " +
                "(select* from IngredienceVeSkladu where id_skladu = 1) ivs " +
                "using (id_ingredience) " +
                "where ivs.pocet < ivj.pocet; ");
        }

        private void AktualizujListViewPokrmy()
        {
            List<string> list = ZjistiNazevMoznehoJidla();
            listView_pokrmy.Clear();
            if (list != null)
            {
                foreach (var item in list)
                {
                    listView_pokrmy.Items.Add(new ListViewItem(item));
                }
            }
        }

        private void AktualizujViews()
        {
            AktualizujListViewIngredience();
            AktualizujListViewPokrmy();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void listView_ingredience_DoubleClick(object sender, EventArgs e)
        {
            string nazev = zjistiNazevVybraneIngredience();
            nazev = nazev.Trim();
            if (nazev == null) {
                Interaction.MsgBox("Nevybrána žádná ingredience");
            }

            //TODO vyskakovací okno s předvyplněnýma hodnotama pro úpravu počtu kusů
            //možná i pro změnu názvu
            //Interaction.MsgBox(nazev);
            List<(int, string)> list = ZjistiIntAString($"select ivs.pocet, " +
                $"i.nazev_ingredience from IngredienceVeSkladu ivs left join Ingredience i using (id_ingredience) where i.nazev_ingredience = \'{nazev}\' ");

            if (list != null)
            {
                //proč nezjistím jen pocet a nazev neberu z proměnný? kdo ví. já ne
                int pocet = list[0].Item1;
                string nazevIngredience = list[0].Item2.ToString();
                Form2 form = new Form2();
                form.textBox1.Text = nazevIngredience;
                form.numericUpDown1.Value = pocet;
                
                if(form.ShowDialog() == DialogResult.OK)
                {
                    (int, string) vysledek = form.hodnota();
                    Console.WriteLine(vysledek.Item1);
                    Console.WriteLine(vysledek.Item2);
                    if(vysledek.Item2.Equals(nazevIngredience))
                    {
                        //TODO vyskakovací okno, které se zeptá na změnu názvu ingredience

                        /*
                        VlozNeboUpravDataZDatabaze($"update Ingredience set nazev_ingredience = \'{vysledek.Item2}\' " +
                            $"where nazev_ingredience = \'{nazevIngredience}\'");
                        nazevIngredience = vysledek.Item2;
                        */
                    }
                    VlozNeboUpravDataZDatabaze($"update IngredienceVeSkladu set pocet = {vysledek.Item1} where id_ingredience = " +
                        $"(select i.id_ingredience from Ingredience i where i.nazev_ingredience = \'{nazevIngredience}\')");
                }
            }
            AktualizujViews();
        }

        private string zjistiNazevVybraneIngredience()
        {
            var items = listView_ingredience.SelectedItems;
            if (items != null)
            {
                int index = items[0].Text.IndexOf('-');
                string nazev = items[0].Text.Substring(0, index);
                //Console.WriteLine(nazev);
                return nazev;
            }
            return null;
        }
    }
}
