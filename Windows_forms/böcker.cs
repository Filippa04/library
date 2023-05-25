using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_forms
{
    public class Book
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Recension { get; set; }

        public Book(string bookId, string bookAuthor, string bookName, int bookYear, string bookRecension)
        {
            Id = bookId;
            Author = bookAuthor;
            Name = bookName;
            Year = bookYear;
            Recension = bookRecension;
        }
    }
}
