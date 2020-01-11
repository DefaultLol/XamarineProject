using Absence.Models;
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
	public partial class add_matiere : ContentPage
	{
        private SQLiteConnection _connection;
        public add_matiere ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTable<Matiere>();
            _connection.CreateTable<Filiere>();

            /*Filiere f0 = new Filiere { Name = "Informatique" };
            Filiere f1 = new Filiere { Name = "Industriel" };
            Filiere f2 = new Filiere { Name = "Procedes" };
            Filiere f3 = new Filiere { Name = "Gtr" };
            _connection.Insert(f0);
            _connection.Insert(f1);
            _connection.Insert(f2);
            _connection.Insert(f3);*/

            List<Filiere> listf = _connection.Table<Filiere>().ToList();
            List<String> nomFiliere = new List<String>();
            foreach(Filiere f in listf)
            {
                nomFiliere.Add(f.Name);
            }
            filiere.ItemsSource = nomFiliere;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            String nom = matiere.Text;
            if (nom != "")
            {
                Matiere s = new Matiere { Name = nom };
                _connection.Insert(s);
                DisplayAlert("Succcess", "Matiere added succefully", "Ok");
            }
            else
            {
                DisplayAlert("Error", "Field should not be empty", "Ok");
            }
           
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
        }
    }
}