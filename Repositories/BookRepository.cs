using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using System.Collections.Generic;
using library_management.Models;



namespace library_management.Repositories
{
    public class BookRepository : IBookRepository // This class implements the IBookRepository interface to manage book data.
    {
        private readonly FileContext _context;

        public BookRepository(FileContext context)// Constructor that initializes the repository with a FileContext instance.
        {
            _context = context;
        }

        public List<Book> GetAll() => _context.Books; // This method retrieves all books from the context.

        public Book GetById(string id) => _context.Books.FirstOrDefault(b => b.Id == id); // This method retrieves a book by its ID from the context.

        public void Add(Book book) => _context.Books.Add(book); // This method adds a new book to the context.

        public void Update(Book book) // This method updates an existing book in the context.
        {
            var index = _context.Books.FindIndex(b => b.Id == book.Id); // Finds the index of the book in the context by its ID.
            if (index != -1)
                _context.Books[index] = book;
        }

        public void ShowAvailableBooks() // This method displays all available books in the library.
        {
            var available = _context.Books.Where(b => b.IsAvailable).ToList();

            Console.WriteLine(" Available Books:");
            if (available.Count == 0)
                Console.WriteLine(" No books available.");
            else
                foreach (var b in available)
                    Console.WriteLine($"- {b.Id}: {b.Title} by {b.Author}");
        }


    }
}
