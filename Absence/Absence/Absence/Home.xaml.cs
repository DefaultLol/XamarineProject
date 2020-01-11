using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Absence
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new absence();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new add_a_student();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            App.Current.MainPage = new add_matiere();
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            App.Current.MainPage = new searching();
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            App.Current.MainPage = new login();
        }
    }
}