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
	public partial class modifierEtudiant : ContentPage
	{
        private SQLiteConnection _connection;
        Student s;
        public modifierEtudiant (Student s)
		{
			InitializeComponent ();
            this.s = s;
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTable<Filiere>();
            List<Filiere> listf = _connection.Table<Filiere>().ToList();
            List<String> nomFiliere = new List<String>();
            foreach (Filiere f in listf)
            {
                nomFiliere.Add(f.Name);
            }
            option.ItemsSource=nomFiliere;
            int index = 0;
            foreach (Filiere f in listf)
            {
                if (f.Name.Equals(s.Option))
                {
                    option.SelectedIndex = index;
                }
                index++;
            }
            code.Text = s.CIN;
            fname.Text = s.FName;
            lname.Text = s.LName;
            email.Text = s.Email;
            phone.Text = s.Phone;
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Student student = _connection.Table<Student>().Where(i => i.CIN == s.CIN).SingleOrDefault();
            student.CIN = code.Text;
            student.FName = fname.Text;
            student.LName = lname.Text;
            student.Email = email.Text;
            student.Phone = phone.Text;
            student.Option = option.SelectedItem.ToString();
            _connection.Update(student);
            DisplayAlert("Success", "Student modifed Succeffully", "Ok");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new searching();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            App.Current.MainPage = new Resultsxaml(s);
        }
    }
}