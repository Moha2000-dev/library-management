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

        public List<Member> GetAll() => _context.Members;

        public Member GetById(string id) => _context.Members.FirstOrDefault(m => m.Id == id);

        public void Add(Member member) => _context.Members.Add(member);

        public void Update(Member member)
        {
            var index = _context.Members.FindIndex(m => m.Id == member.Id);
            if (index != -1)
                _context.Members[index] = member;
        }
    }
}
