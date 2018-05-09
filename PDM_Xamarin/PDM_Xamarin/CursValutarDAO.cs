using System;
using SQLite;
using System.Collections.Generic;

namespace PDM_Xamarin
{
    class CursValutarDAO
    {
        private SQLiteConnection conn;

        public CursValutarDAO()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(folder, "./cursValutar.db"));
            conn.CreateTable<CursValutar>();
        }

        public List<CursValutar> getLista()
        {
            List<CursValutar> listaCursuriValutare = new List<CursValutar>();
            var query = conn.Query<CursValutar>("SELECT * from CursuriValutare");
            foreach(var element in query)
            {
                listaCursuriValutare.Add(element);
            }
            return listaCursuriValutare;
        }

        public void insertCursValutar(CursValutar cv)
        {
            conn.Insert(cv);
        }

        public List<string> getDates()
        {
            List<string> listaDate = new List<string>();
            var query = conn.Query<CursValutar>("SELECT DISTINCT data_curs from CursuriValutare");
            foreach(var element in query)
            {
                listaDate.Add(element.DataCurs.ToString());
            }
            return listaDate;
        }

        public List<CursValutar> getListByDate(DateTime date)
        {
            List<CursValutar> listaCursuriValutare = new List<CursValutar>();
            var query = conn.Query<CursValutar>("SELECT * from CursuriValutare WHERE data_curs=?",date);
            foreach (var element in query)
            {
                listaCursuriValutare.Add(element);
                Console.WriteLine(element);
            }
            return listaCursuriValutare;
        }
    }
}
