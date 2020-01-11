using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Absence
{
    public class Prof
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public String Name { get; set; }
        [MaxLength(255)]
        public String Password { get; set; }
    }
}
