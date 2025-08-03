using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_management.Models;

namespace library_management.Services
{

   

    public interface ILibraryService
    {
        void BorrowBook(string bookId, string memberId);
        void ReturnBook(string bookId, string memberId);
        void RegisterMember(Member member);
        void AddBook(Book book);
    }

}
