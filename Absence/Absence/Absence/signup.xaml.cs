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
	public partial class signup : ContentPage
	{
        private SQLiteConnection _connection;
        public signup ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTable<Prof>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            String username = nom.Text;
            String password = pass.Text;
            String confirmPass = confirm.Text;
            if(username.Length>5 && password.Length>5 && confirmPass.Equals(password))
            {
                var p = new Prof { Name = username, Password = password };
                _connection.Insert(p);
                DisplayAlert("Success", "You have succeffully registered", "Ok");
            }
            else
            {
                DisplayAlert("Error", "Error input", "Ok");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new login();
        }
    }
}