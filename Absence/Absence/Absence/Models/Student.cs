using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Absence
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public String CIN { get; set; }
        [MaxLength(255)]
        public String FName { get; set; }
        [MaxLength(255)]
        public String LName { get; set; }
        [MaxLength(255)]
        public String Email { get; set; }
        [MaxLength(255)]
        public String Phone { get; set; }
        [MaxLength(255)]
        public String Option { get; set; }
        public int Abscence { get; set; }
        public int Presence { get; set; }
    }
}
