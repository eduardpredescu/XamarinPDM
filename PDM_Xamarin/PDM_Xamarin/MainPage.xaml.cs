using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml;
using System.IO;
using System.Globalization;
using Xamarin.Forms;

namespace PDM_Xamarin
{
	public partial class MainPage : ContentPage
	{
		List<CursValutar> listaValute;
		public MainPage()
		{
			listaValute = new List<CursValutar>();
			InitializeComponent();
			var button = this.FindByName<Button>("button");
			button.Clicked += loadData_Clicked;
			listView.ItemSelected += (sender, e) => Navigation.PushAsync(new PaginaDetaliiValuta());
		}

		private async void loadData_Clicked(object sender, EventArgs e)
		{
			HttpClient httpClient = new HttpClient();
			Stream fileStream = await httpClient.GetStreamAsync(new Uri("http://www.bnr.ro/nbrfxrates.xml"));
			XmlReader xmlReader = XmlReader.Create(fileStream);
			DateTime dataCurs = DateTime.Now;

			while (xmlReader.Read())
			{
				if (xmlReader.IsStartElement())
				{
					switch (xmlReader.Name)
					{
						case "Cube":
							String data = xmlReader["date"];
							dataCurs = DateTime.ParseExact(data, "yyyy-MM-dd", CultureInfo.InvariantCulture);
							break;

						case "Rate":
							CursValutar cursValutar = new CursValutar();
							cursValutar.DataCurs = dataCurs;
							cursValutar.DenumireValuta = xmlReader["currency"];
							if (xmlReader["multiplier"] != null)
							{
								cursValutar.Multiplicator = int.Parse(xmlReader["multiplier"]);
							}
							xmlReader.Read();
							cursValutar.ValoareMoneda = float.Parse(xmlReader.Value);
							listaValute.Add(cursValutar);
							break;
					}
				}
			}



			listView.ItemsSource = listaValute;
		}


		private void Convertor_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new PaginaConvertor());
		}

		private void Despre_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new PaginaDespre());
		}
	}
}
