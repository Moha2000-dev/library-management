using System.Collections.Generic;
using library_management.Models;

namespace library_management.Repositories
{
    public interface IBorrowRecordRepository
    {
        List<BorrowRecord> GetAll();
        void Add(BorrowRecord record);
        void Update(BorrowRecord record);
    }
}
