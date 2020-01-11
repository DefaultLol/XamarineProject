using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Absence.Models
{
    class Matiere
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public String Name { get; set; }
        public String NomFiliere { get; set; }
    }
}
