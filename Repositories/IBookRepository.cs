using library_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management.Repositories
{
    interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(string id);
        void Add(Book book);
        void Update(Book book);

    }
}
