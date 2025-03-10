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
            
            Databaze.ZjistiZDatabaze("select * from Ingredience");
            //ZjistiZDatabaze("select nazev_ingredience from Ingredience where id_ingredience = 1"); - nutnost parsovat jen string


            /*  odebrani z databaze
            *   VlozNeboUpravDataZDatabaze("delete from Sklad where id_skladu = 2");
            *   
            *   vlozeni do databaze
            *   VlozNeboUpravDataZDatabaze("insert into Sklad values(null, 'test')");
            */
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
                List<int> list = Databaze.ZjistiCislo($"select i.id_ingredience from Ingredience i where nazev_ingredience = \'{nazev}\'");
                if (list == null)
                {
                    //vloží ingredienci do tabulky Ingredience
                    Databaze.VlozNeboUpravDataZDatabaze($"INSERT INTO Ingredience VALUES (null ,\'{nazev}\')");
                    //vloží id ingredience - nyní už 100% existuje
                    list = Databaze.ZjistiCislo($"select i.id_ingredience from Ingredience i where nazev_ingredience = \'{nazev}\'");

                }
                int ingredience = list[0];
                //zkontrolovat, jestli je ve vazební tabulce a pak buď přidat, nebo změnit
                List<int> existuje = Databaze.ZjistiCislo($"select i.id_skladu from IngredienceVeSkladu i where i.id_ingredience = {ingredience}");
                if (existuje != null)
                {
                    //updatne ingredienci na danou hodnotu
                    //MessageBox.Show("ingredience existuje");
                    Databaze.VlozNeboUpravDataZDatabaze($"UPDATE IngredienceVeSkladu SET pocet = {pocet} WHERE id_ingredience = {ingredience} and id_skladu = 1");
                }
                else
                {
                    //vloží novou ingredienci do vazební tabulky IngredienceVeSKladu
                    Databaze.VlozNeboUpravDataZDatabaze($"INSERT INTO IngredienceVeSkladu VALUES ({ingredience}, 1 ,{pocet})");
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
            return Databaze.ZjistiNazevAPocetKs("select * from ViewNazevAPocetIngVeSkladu1");
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


        private void AktualizujListViewPokrmy()
        {
            List<string> list = Databaze.ZjistiNazevMoznehoJidla();
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
            if(listView_pokrmy.SelectedItems.Count > 0)
            {
                string nazevPokrmu = listView_pokrmy.SelectedItems[0].Text.Trim();
                FormJidlo formJidlo = new FormJidlo(nazevPokrmu);
                

                formJidlo.ShowDialog();
                AktualizujViews();
            }
            else
            {
                MessageBox.Show("Nevybrán žádný pokrm k úpravě", "Chyba!");
            }

            
        }

        private void listView_ingredience_DoubleClick(object sender, EventArgs e)
        {
            string nazev = zjistiNazevVybraneIngredience();
            
            if (nazev == null) {
                MessageBox.Show("Nevybrána žádná ingredience","Chyba!!");
            }

            List<(int, string)> list = Databaze.ZjistiIntAString($"select ivs.pocet, " +
                $"i.nazev_ingredience from IngredienceVeSkladu ivs left join Ingredience i using (id_ingredience) where i.nazev_ingredience = \'{nazev}\' ");

            if (list != null)
            {
                //proč nezjistím jen pocet a nazev neberu z proměnný? kdo ví. já ne
                int pocet = list[0].Item1;
                string nazevIngredience = list[0].Item2.ToString();
                Ingredience form = new Ingredience(nazevIngredience,pocet, VazebniTabuka.SKLAD);
                form.ShowDialog();
            }

            AktualizujViews();
        }

        private string zjistiNazevVybraneIngredience()
        {
            var items = listView_ingredience.SelectedItems;
            if (items != null)
            {
                int index = items[0].Text.IndexOf('-');
                string nazev = items[0].Text.Substring(0, index).Trim();
                return nazev;
            }
            return null;
        }

        private void listView_pokrmy_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button3_Click(sender, e);
        }
    }
}
