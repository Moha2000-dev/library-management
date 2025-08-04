using System.Collections.Generic;
using library_management.Models;

namespace library_management.Repositories
{
    public interface IBookRepository // This interface defines the contract for book-related data operations.
    {
        List<Book> GetAll();
        Book GetById(string id);
        void Add(Book book);
        void Update(Book book);
    }
}
