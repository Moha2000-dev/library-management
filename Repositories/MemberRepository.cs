using System.Collections.Generic;
using System.Linq;
using library_management.Models;

namespace library_management.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly FileContext _context;

        public MemberRepository(FileContext context)
        {
            _context = context;
        }

        public List<Member> GetAll() => _context.Members; // This method retrieves all members from the context.

        public Member GetById(string id) => _context.Members.FirstOrDefault(m => m.Id == id); // This method retrieves a member by their ID from the context.

        public void Add(Member member) => _context.Members.Add(member);// This method adds a new member to the context.

        public void Update(Member member)// This method updates an existing member in the context.
        {
            var index = _context.Members.FindIndex(m => m.Id == member.Id);// Finds the index of the member in the context by their ID.
            if (index != -1)
                _context.Members[index] = member;// If the member exists, it updates the member at that index with the new member data.
        }
    }
}
