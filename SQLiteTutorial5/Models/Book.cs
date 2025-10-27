using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Renderscripts;
using SQLite;

namespace SQLiteTutorial5.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
