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
	public partial class absence : ContentPage
	{
        private SQLiteConnection _connection;
        List<Student> abscence=new List<Student>();
        List<Student> presence = new List<Student>();
        List<Student> students;
        public absence ()
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


        private void Filiere_SelectedIndexChanged(object sender, EventArgs e)
        {
            String filiereSelected = filiere.SelectedItem.ToString();
            students = _connection.Table<Student>().Where(i=>i.Option==filiereSelected).ToList();
            listView.ItemsSource = students;

        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var selectedItem = ((Switch)sender).BindingContext as Student;
            var cell = ((Switch)sender).IsToggled;
            if (cell == true)
            {
                abscence.Add(selectedItem);
            }
            else
            {
                abscence.Remove(selectedItem);
            }
            DisplayAlert("lol", cell + " " + selectedItem.Presence, "Ok");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            presence = students.Except(abscence).ToList();
            foreach(Student student in abscence)
            {
                Student s = _connection.Table<Student>().Where(i => i.Id == student.Id).SingleOrDefault();
                s.Abscence += 1;
                _connection.Update(s);
            }
            foreach (Student student in presence)
            {
                Student s = _connection.Table<Student>().Where(i => i.Id == student.Id).SingleOrDefault();
                s.Presence += 1;
                _connection.Update(s);
            }
            DisplayAlert("Success", "Abscence Added", "Ok");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
        }
    }
}