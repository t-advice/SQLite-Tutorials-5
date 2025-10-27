using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SQLiteTutorial5.Models
{
    // This defines our book table with simple fields 
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
