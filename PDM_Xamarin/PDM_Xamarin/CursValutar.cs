using System;
using System.Collections.Generic;
using System.Text;

namespace PDM_Xamarin
{
    class CursValutar
    {
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
