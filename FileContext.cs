using System.Collections.Generic;
using library_management.Models;
using library_management.Helpers;

public class FileContext
{
    public List<Book> Books { get; set; } = BookFileHelper.Load();
    public List<Member> Members { get; set; } = MemberFileHelper.Load();
    public List<BorrowRecord> BorrowRecords { get; set; } = BorrowRecordFileHelper.Load();
}
