using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_forms
{
    public class boksystem
    {
        private static boksystem? instance = null;
        private static string booksFilePath = "C:\\Users\\filippa.olsson7\\Desktop\\programmering2\\bibliotek\\böcker.txt";

        private List<Book> books = new List<Book>();

        public List<Book> GetBooks() { return books; }

        private boksystem()
        {
            LoadBooks();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Save();
        }

        public void Save()
        {

            string[] booksStringArr = books.Select(book => $"{book.Id} {book.Author} {book.Name} {book.Year} {book.Recension}").ToArray();


            File.WriteAllLines(booksFilePath, booksStringArr);
        }

        public static boksystem GetInstance()
        {
            if (instance == null)
            {
                instance = new boksystem();
            }
            return instance;
        }

        void LoadBooks()
        {
            string[] booksFromDb = File.ReadAllLines(booksFilePath);

            for (var i = 0; i < booksFromDb.Length; i++)
            {
                string bookStr = booksFromDb[i];
                string[] bookLineTokens = bookStr.Split(" ");
                string bookId = bookLineTokens[0];
                string bookAuthor = bookLineTokens[1];
                string bookName = bookLineTokens[2];
                int bookYear = Int32.Parse(bookLineTokens[3]);
                string recension = (bookLineTokens[4]);

                Book book = new Book(bookId, bookAuthor, bookName, bookYear, recension);
                books.Add(book);
            }
        }

        public List<Book> FindBook(string text)
        {
            var textLowerCase = text.ToLower();
            int maxDistance = 2;

            var result = new List<Book>();

            foreach (var book in books)
            {
                var authorDistance = LevenshteinDistance.GetDistance(book.Author.ToLower(), textLowerCase);
                var nameDistance = LevenshteinDistance.GetDistance(book.Name.ToLower(), textLowerCase);

                if (authorDistance <= maxDistance || nameDistance <= maxDistance)
                {
                    result.Add(book);
                }
            }

            return result;
        }
    }
}
