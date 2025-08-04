using System.Collections.Generic;
using library_management.Models;

namespace library_management.Repositories
{
    public interface IMemberRepository // This interface defines the contract for member-related data operations.
    {
        List<Member> GetAll();
        Member GetById(string id);
        void Add(Member member);
        void Update(Member member);
    }
}
