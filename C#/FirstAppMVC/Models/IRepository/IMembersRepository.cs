using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstAppMVC.Models
{
    public interface IMembersRepository
    {
        List<Member> GetMembers();
        Member GetMemberByIndex(int index);
        void AddMember(Member member);
        void DeleteMember(int index);
        Member UpdateMember(int index, Member member);
    }
}