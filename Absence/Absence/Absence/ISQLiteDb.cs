using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Absence
{
   public interface ISQLiteDb
    {
        SQLiteConnection GetConnection();
    }
}
