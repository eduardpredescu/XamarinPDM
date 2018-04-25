using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PDM_Xamarin
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			List<CursValutar> listaValute = new List<CursValutar>{
				new CursValutar("EUR", 4.5f),
				new CursValutar("USD", 3.8f),
				new CursValutar("GBP", 6),
				new CursValutar("RON", 1),
				new CursValutar("HUF", 1.4f, 100)
			};
			InitializeComponent();
			var button = this.FindByName<Button>("button");
			button.Clicked += (sender, e) => listView.ItemsSource = listaValute;
			listView.ItemSelected += (sender, e) => Navigation.PushAsync(new PaginaDetaliiValuta());
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
