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
			InitializeComponent();
			var button = this.FindByName<Button>("button");
			button.Clicked += (sender, e) => button.Text = "Apasat";
		}
	}
}
