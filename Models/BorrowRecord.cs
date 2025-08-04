using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management.Models
{
    public class BorrowRecord // This class represents a record of a book borrowed by a member in the library.
    {
        public string Id { get; set; }
        public string MemberId { get; set; }
        public string BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
