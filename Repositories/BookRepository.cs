using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using System.Collections.Generic;
using library_management.Models;
using library_management.Repositories.Interfaces;



namespace library_management.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly FileContext _context;

        public BookRepository(FileContext context)
        {
            _context = context;
        }

        public List<Book> GetAll() => _context.Books;

        public Book GetById(string id) => _context.Books.FirstOrDefault(b => b.Id == id);

        public void Add(Book book) => _context.Books.Add(book);

        public void Update(Book book)
        {
            var index = _context.Books.FindIndex(b => b.Id == book.Id);
            if (index != -1)
                _context.Books[index] = book;
        }
    }
}
