using library_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FileContext.cs
namespace library_management
{
    public class FileContext
    {
        public List<Book> Books { get; set; } = new();
        public List<Member> Members { get; set; } = new();
        public List<BorrowRecord> BorrowRecords { get; set; } = new();
    }
}
