using SQLite;
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
	public partial class Resultsxaml : ContentPage
	{
        public Resultsxaml (Student s)
		{
			InitializeComponent ();

            AbsentButton.Text = s.Abscence.ToString();
            PresentButton.Text = s.Presence.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
        }
    }
}