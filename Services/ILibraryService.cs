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
        void BorrowBook(string bookId, string memberId);// Borrow a book from the library
        void ReturnBook(string bookId, string memberId);// Return a borrowed book
        void RegisterMember(Member member);// Register a new member in the library
        void AddBook(Book book);// Add a new book to the library
    }

}
