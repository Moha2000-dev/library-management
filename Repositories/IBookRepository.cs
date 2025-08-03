using System.Collections.Generic;
using library_management.Models;

namespace library_management.Repositories
{
    public interface IBookRepository 
    {
        List<Book> GetAll();
        Book GetById(string id);
        void Add(Book book);
        void Update(Book book);
    }
}
