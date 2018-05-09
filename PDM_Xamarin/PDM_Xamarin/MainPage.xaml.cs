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
		CursValutarDAO cursDao;
		List<string> listaDate;
		string dataSelectata;
		public MainPage()
		{
			cursDao = new CursValutarDAO();
			listaValute = new List<CursValutar>();
			listaDate = new List<string>();
			InitializeComponent();
			var button = this.FindByName<Button>("button");
			button.Clicked += loadData_Clicked;
			listView.ItemSelected += (sender, e) => Navigation.PushAsync(new PaginaDetaliiValuta());
			listaDate = cursDao.getDates();
			var picker = this.FindByName<Picker>("datePicker");
			picker.SelectedIndexChanged += onPickerChangedIndex;
			picker.ItemsSource = listaDate;
			listView.ItemsSource = listaValute;
		}

		private async void loadData_Clicked(object sender, EventArgs e)
		{
			List<CursValutar> list = new List<CursValutar>();
			list = cursDao.getLista();
			HttpClient httpClient = new HttpClient();
			Stream fileStream = await httpClient.GetStreamAsync(new Uri("http://www.bnr.ro/nbrfxrates.xml"));
			XmlReader xmlReader = XmlReader.Create(fileStream);
			DateTime dataCurs = DateTime.Now;
			if (list.Count == 0)
			{
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
								cursDao.insertCursValutar(cursValutar);
								break;
						}
					}
				}
				Console.WriteLine("Internet info");
			} else
			{
				listaValute.AddRange(list);
				Console.WriteLine("DB info");
			}
		}

		private void onPickerChangedIndex(object sender, EventArgs e)
		{
			var picker = (Picker)sender;
			int selectedIndex = picker.SelectedIndex;
			dataSelectata = listaDate[selectedIndex];
			listaValute.AddRange(cursDao.getListByDate(DateTime.Parse(dataSelectata)));
			listView.ItemsSource = null;
			listView.ItemsSource = listaValute;
			Console.WriteLine("Nu a crapat!");
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
