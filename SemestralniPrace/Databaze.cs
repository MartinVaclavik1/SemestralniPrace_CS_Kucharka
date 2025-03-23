using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemestralniPrace
{
    class Databaze
    {
        /// <summary>
        /// vypíše všechny ingredience z databáze
        /// </summary>
        /// <param name="prikaz"></param>
        public static void ZjistiZDatabaze(string prikaz)
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

        public static void ZjistiZVazebniTabulky(string prikaz)
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

        /// <summary>
        /// spojí string a int do jednoho strignu, který vrátí a připíše na konec -ks/g
        /// </summary>
        /// <param name="prikaz"></param>
        /// <returns></returns>
        public static List<string> ZjistiNazevAPocetKs(string prikaz)
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

        public static List<string> ZjistiNazev(string prikaz)
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

        public static List<(int, string)> ZjistiIntAString(string prikaz)
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
                    List<(int, string)> pole = new List<(int, string)>();
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

        public static List<int> ZjistiCislo(string prikaz)
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

        public static bool VlozNeboUpravDataZDatabaze(string prikaz)
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
                        MessageBox.Show(x.Message, "Chyba!");
                        return false;
                    }
                    conn.Close();
                }

            }

            return true;
        }

        public static List<string> ZjistiNazevIngredienceAPocetZeSkladu1()
        {
            return ZjistiNazevAPocetKs("select * from ViewNazevAPocetIngVeSkladu1");
            //return ZjistiNazevAPocetKs("select ing.nazev_ingredience, " +
            //"i.pocet from IngredienceVeSkladu i left join Ingredience ing " +
            //"where i.id_ingredience = ing.id_ingredience and i.id_skladu = 1");
        }

        public static List<string> ZjistiNazevMoznehoJidla()
        {
            return ZjistiNazev("select distinct(j.nazev) from Jidlo j left join IngredienceVJidle ivj using (id_jidla) " +
                "left join(select * from IngredienceVeSkladu where id_skladu = 1) ivs using (id_ingredience) " +
                "except select j.nazev from Jidlo j left join IngredienceVJidle ivj using (id_jidla) " +
                "left join " +
                "(select* from IngredienceVeSkladu where id_skladu = 1) ivs " +
                "using (id_ingredience) " +
                "where ivs.pocet < ivj.pocet or ivj.id_ingredience not in (select id_ingredience from IngredienceVeSkladu); ");
        }

        /// <summary>
        /// HÁZELO CHYBU DATABASE IS LOCKED PŘI NÁSLEDNÉM POKUSU O ZMĚNU(UPDATE) DAT
        /// </summary>
        /// <param name="prikaz"></param>
        /// <returns></returns>
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

    }
}
