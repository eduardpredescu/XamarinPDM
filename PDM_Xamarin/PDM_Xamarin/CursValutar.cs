using System;
using SQLite;

namespace PDM_Xamarin
{
    [Table("CursuriValutare")]
    class CursValutar
    {
        private int _id;
        private DateTime dataCurs;
        private int multiplicator;
        private string denumireValuta;
        private float valoareMoneda;

        public CursValutar()
        {
            this.Multiplicator = 1;
        }

        public CursValutar(DateTime dataCurs, int multiplicator, string denumireValuta, float valoareMoneda)
        {
            this.DataCurs = dataCurs;
            this.Multiplicator = multiplicator;
            this.DenumireValuta = denumireValuta;
            this.ValoareMoneda = valoareMoneda;
        }

        public CursValutar(DateTime dataCurs, string denumireValuta, float valoareMoneda)
        {
            this.DataCurs = dataCurs;
            this.Multiplicator = 1;
            this.DenumireValuta = denumireValuta;
            this.ValoareMoneda = valoareMoneda;
        }

        public CursValutar(string denumireValuta, float valoareMoneda)
        {
            this.DataCurs = DateTime.Now;
            this.Multiplicator = 1;
            this.DenumireValuta = denumireValuta;
            this.ValoareMoneda = valoareMoneda;
        }

        public CursValutar(string denumireValuta, float valoareMoneda, int multiplicator)
        {
            this.DataCurs = DateTime.Now;
            this.Multiplicator = multiplicator;
            this.DenumireValuta = denumireValuta;
            this.ValoareMoneda = valoareMoneda;
        }

        public string Drapel
        {
            get
            {
                return denumireValuta.Substring(0, 2).ToLower() + ".png";
            }
        }

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        [Column("data_curs")]
        public DateTime DataCurs
        {
            get
            {
                return dataCurs;
            }

            set
            {
                dataCurs = value;
            }
        }

        [Column("multiplicator")]
        public int Multiplicator
        {
            get
            {
                return multiplicator;
            }

            set
            {
                multiplicator = value;
            }
        }

        [Column("denumire_valuta")]
        public string DenumireValuta
        {
            get
            {
                return denumireValuta;
            }

            set
            {
                denumireValuta = value;
            }
        }

        [Column("valoare_moneda")]
        public float ValoareMoneda
        {
            get
            {
                return valoareMoneda;
            }

            set
            {
                valoareMoneda = value;
            }
        }

        public override string ToString()
        {
            return multiplicator + " " + denumireValuta + " = " + valoareMoneda + " RON";
        }
    }
}
