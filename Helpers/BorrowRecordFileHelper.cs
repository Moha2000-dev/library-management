using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using library_management.Models;

namespace library_management.Helpers
{
    public static class BorrowRecordFileHelper // This class handles saving and loading borrow records to and from a file.
    {
        private static readonly string filePath = "records.txt";

        public static void Save(List<BorrowRecord> records)
        {
            var lines = records.Select(r =>
                $"{r.Id}|{r.MemberId}|{r.BookId}|{r.BorrowDate:yyyy-MM-dd}|{(r.ReturnDate.HasValue ? r.ReturnDate.Value.ToString("yyyy-MM-dd") : "")}");
            File.WriteAllLines(filePath, lines);
        }

        public static List<BorrowRecord> Load() // This method loads borrow records from a file and returns a list of BorrowRecord objects.
        {
            if (!File.Exists(filePath)) return new();
            return File.ReadAllLines(filePath)
                .Select(line =>
                {
                    var parts = line.Split('|');
                    return new BorrowRecord
                    {
                        Id = parts[0],
                        MemberId = parts[1],
                        BookId = parts[2],
                        BorrowDate = DateTime.Parse(parts[3]),
                        ReturnDate = string.IsNullOrEmpty(parts[4]) ? null : DateTime.Parse(parts[4])
                    };
                }).ToList();
        }
    }
}
