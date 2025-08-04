using System.Collections.Generic;
using System.IO;
using System.Linq;
using library_management.Models;

namespace library_management.Helpers
{
    public static class MemberFileHelper // This class handles saving and loading member data to and from a file.
    {
        private static readonly string filePath = "members.txt";

        public static void Save(List<Member> members)
        {
            var lines = members.Select(m => $"{m.Id}|{m.Name}");
            File.WriteAllLines(filePath, lines);
        }

        public static List<Member> Load() // This method loads member data from a file and returns a list of Member objects.
        {
            if (!File.Exists(filePath)) return new();
            return File.ReadAllLines(filePath)
                .Select(line =>
                {
                    var parts = line.Split('|');
                    return new Member
                    {
                        Id = parts[0],
                        Name = parts[1]
                    };
                }).ToList();
        }
    }
}
