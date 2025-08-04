using System.Collections.Generic;
using System.Linq;
using library_management.Models;

namespace library_management.Repositories
{
    public class BorrowRecordRepository : IBorrowRecordRepository
    {
        private readonly FileContext _context;

        public BorrowRecordRepository(FileContext context)
        {
            _context = context;
        }

        public List<BorrowRecord> GetAll() => _context.BorrowRecords;

        public void Add(BorrowRecord record) => _context.BorrowRecords.Add(record);

        public void Update(BorrowRecord record)
        {
            var index = _context.BorrowRecords.FindIndex(r => r.Id == record.Id);
            if (index != -1)
                _context.BorrowRecords[index] = record;
        }
        public void ShowBorrowedBooks()
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
