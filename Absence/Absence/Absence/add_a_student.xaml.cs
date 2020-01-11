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
	public partial class add_a_student : ContentPage
	{
        private SQLiteConnection _connection;
        public add_a_student()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTable<Student>();
            _connection.CreateTable<Filiere>();
            List<Filiere> listf = _connection.Table<Filiere>().ToList();
            List<String> nomFiliere = new List<String>();
            foreach (Filiere f in listf)
            {
                nomFiliere.Add(f.Name);
            }
            option.ItemsSource = nomFiliere;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            String cin = code.Text;
            String name = fname.Text;
            String last = lname.Text;
            String tele = phone.Text;
            String mail = email.Text;
            String fil = option.SelectedItem.ToString();
            if(cin.Length>5 && name.Length>5 && last.Length > 5)
            {
                Student s = new Student { CIN = cin, FName = name, LName = last, Phone = tele, Email = mail, Option = fil,Abscence=0,Presence=0 };
                _connection.Insert(s);
                DisplayAlert("Success", "You have succeffully added a student", "Ok");
            }
            else
            {
                DisplayAlert("Error", "Input Error", "Ok");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
        }
    }
}