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
			List<string> listaValute = new List<string>{
                "1 EUR = 4.7 RON",
                "1 USD = 3.8 RON",
                "1 GBP = 6 RON",
                "1 CAD = 3.5 RON",
                "1 BGN = 2.3 RON"
            };
			InitializeComponent();
			var button = this.FindByName<Button>("button");
			button.Clicked += (sender, e) => listView.ItemsSource = listaValute;
            listView.ItemSelected += (sender, e) => Navigation.PushAsync(new PaginaDetaliiValuta());
		}
	}
}
