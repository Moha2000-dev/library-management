using System.Collections.Generic;
using System.IO;
using System.Linq;
using library_management.Models;

namespace library_management.Helpers
{
    public static class BookFileHelper // This class handles the file operations for storing and retrieving book data.
    {
        private static readonly string filePath = "books.txt";

        public static void Save(List<Book> books)
        {
            var lines = books.Select(b => $"{b.Id}|{b.Title}|{b.Author}|{b.IsAvailable}");
            File.WriteAllLines(filePath, lines);
        }

        public static List<Book> Load() // This method loads book data from a file and returns a list of Book objects.
        {
            if (!File.Exists(filePath)) return new();
            return File.ReadAllLines(filePath)
                .Select(line =>
                {
                    var parts = line.Split('|');
                    return new Book
                    {
                        Id = parts[0],
                        Title = parts[1],
                        Author = parts[2],
                        IsAvailable = bool.Parse(parts[3])
                    };
                }).ToList();
        }
    }
}
