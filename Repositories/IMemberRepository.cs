using System.Collections.Generic;
using library_management.Models;

namespace library_management.Repositories
{
    public interface IMemberRepository
    {
        List<Member> GetAll();
        Member GetById(string id);
        void Add(Member member);
        void Update(Member member);
    }
}
