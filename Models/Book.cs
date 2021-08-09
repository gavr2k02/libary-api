using System;

namespace APILibary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}