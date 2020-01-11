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
	public partial class searching : ContentPage
	{
        private SQLiteConnection _connection;
        public searching ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTable<Filiere>();
            _connection.CreateTable<Matiere>();
            _connection.CreateTable<Student>();
            //filiere
            List<Filiere> listf = _connection.Table<Filiere>().ToList();
            List<String> nomFiliere = new List<String>();
            foreach (Filiere f in listf)
            {
                nomFiliere.Add(f.Name);
            }
            filiere.ItemsSource = nomFiliere;
            //matiere
           List<Matiere> listm = _connection.Table<Matiere>().ToList();
            List<String> nomMatiere = new List<String>();
            foreach (Matiere m in listm)
            {
                nomMatiere.Add(m.Name);
            }
            matiere.ItemsSource = nomMatiere;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            String name = lastName.Text;
            String matiereSelected = matiere.SelectedItem.ToString();
            String filiereSelected = filiere.SelectedItem.ToString();
            Student student = _connection.Table<Student>().Where(i => i.LName == name && i.Option == filiereSelected).SingleOrDefault();
            if (student != null)
            {
                App.Current.MainPage = new modifierEtudiant(student);
            }
            else
            {
                DisplayAlert("Error", "Student not found", "Ok");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
        }
    }
}