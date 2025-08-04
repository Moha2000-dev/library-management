using System.Collections.Generic;
using System.Linq;
using library_management.Models;

namespace library_management.Repositories
{
    public class BorrowRecordRepository : IBorrowRecordRepository // This class implements the IBorrowRecordRepository interface to manage borrow records.
    {
        private readonly FileContext _context; 

        public BorrowRecordRepository(FileContext context) // Constructor that initializes the repository with a FileContext instance.
        {
            _context = context;
        }

        public List<BorrowRecord> GetAll() => _context.BorrowRecords; // This method retrieves all borrow records from the context.

        public void Add(BorrowRecord record) => _context.BorrowRecords.Add(record); // This method adds a new borrow record to the context.

        public void Update(BorrowRecord record) // This method updates an existing borrow record in the context.
        {
            var index = _context.BorrowRecords.FindIndex(r => r.Id == record.Id);
            if (index != -1)
                _context.BorrowRecords[index] = record;
        }
        public void ShowBorrowedBooks()// This method displays all borrowed books in the library.
        {
            var borrowed = _context.Books.Where(b => !b.IsAvailable).ToList();

            Console.WriteLine(" Borrowed Books:");
            if (borrowed.Count == 0)
                Console.WriteLine(" No borrowed books.");
            else
                foreach (var b in borrowed)
                    Console.WriteLine($"- {b.Id}: {b.Title} by {b.Author}");
        }


    }
}
