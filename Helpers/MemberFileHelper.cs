using System.Collections.Generic;
using System.IO;
using System.Linq;
using library_management.Models;

namespace library_management.Helpers
{
    public static class MemberFileHelper
    {
        private static readonly string filePath = "members.txt";

        public static void Save(List<Member> members)
        {
            var lines = members.Select(m => $"{m.Id}|{m.Name}");
            File.WriteAllLines(filePath, lines);
        }

        public static List<Member> Load()
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
