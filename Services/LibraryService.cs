using System;
using library_management.Models;
using library_management.Repositories;


namespace library_management.Services
{
    
    public class LibraryService : ILibraryService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMemberRepository _memberRepo;
        private readonly IBorrowRecordRepository _recordRepo;

        public LibraryService(IBookRepository bookRepo, IMemberRepository memberRepo, IBorrowRecordRepository recordRepo)
        {
            _bookRepo = bookRepo;
            _memberRepo = memberRepo;
            _recordRepo = recordRepo;
        }
        /// Borrow a book from the library
        public void BorrowBook(string bookId, string memberId)
        {
            var book = _bookRepo.GetById(bookId);
            if (book == null || !book.IsAvailable)
            {
                Console.WriteLine("Book not available.");
                return;
            }

            book.IsAvailable = false;
            _bookRepo.Update(book);

            var record = new BorrowRecord
            {
                Id = Guid.NewGuid().ToString(),
                BookId = bookId,
                MemberId = memberId,
                BorrowDate = DateTime.Now
            };

            _recordRepo.Add(record);
        }
        /// Return a borrowed book
        public void ReturnBook(string bookId, string memberId)
        {
            var record = _recordRepo.GetAll()
                .Find(r => r.BookId == bookId && r.MemberId == memberId && r.ReturnDate == null);

            if (record == null)
            {
                Console.WriteLine("No active borrow record found.");
                return;
            }

            record.ReturnDate = DateTime.Now;
            _recordRepo.Update(record);

            var book = _bookRepo.GetById(bookId);
            if (book != null)
            {
                book.IsAvailable = true;
                _bookRepo.Update(book);
            }
        }
        /// View all available books in the library
        public void RegisterMember(Member member)
        {
            _memberRepo.Add(member);
        }

        public void AddBook(Book book)
        {
            _bookRepo.Add(book);
        }
    }
}
