using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Absence.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDb))]
namespace Absence.Droid
{
    class SQLiteDb : ISQLiteDb
    {
        public SQLiteConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(documentsPath, "db.sqlite");
            return new SQLiteConnection(path);
        }
    }
}