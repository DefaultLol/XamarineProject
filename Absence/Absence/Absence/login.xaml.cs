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
	public partial class login : ContentPage
	{
        private SQLiteConnection _connection;
        
		public login ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTable<Prof>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            String nom = username.Text;
            String pass = password.Text;
            int k = 0;
            List<Prof> list = new List<Prof>(_connection.Table<Prof>().ToList());
            foreach(Prof p in list)
            {
                if(p.Name.Equals(nom) && p.Password.Equals(pass))
                {
                    k = 1;
                }
            }
            if (k == 1)
            {
                DisplayAlert("Alert", "Logged in", "OK");
                App.Current.MainPage = new Home();
            }
            else
            {
                DisplayAlert("Alert", "Error in inputs", "OK");
            }
            
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new signup();
        }
    }
}