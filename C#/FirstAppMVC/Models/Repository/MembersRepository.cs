using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAppMVC.Models
{
    public class MembersRepository : IMembersRepository
    {
       private static List<Member> members = new List<Member>(){
            new Member() { Name="Truong Cong Vinh",Phone="0123654789",Birthday="18/12/2001",Gender="Male",Email="asd12@gmail.com",BirthPlace="Hai Phong"}
            ,new Member() { Name="Truong Cong Minh",Phone="0123654789",Birthday="18/12/2000",Gender="Male",Email="asd2@gmail.com",BirthPlace="Ha Noi"}
            ,new Member() { Name="Truong Cong Tuan",Phone="0123654789",Birthday="18/12/1999",Gender="Male",Email="asd3@gmail.com" ,BirthPlace="Hai Phong"}
            ,new Member() { Name="Truong Cong Tu",Phone="0123654789",Birthday="18/12/1998",Gender="Male",Email="asd4@gmail.com",BirthPlace="Ha Noi"}
            ,new Member() { Name="Truong Cong Duc",Phone="0123654789",Birthday="18/12/2000",Gender="Male",Email="asd5@gmail.com",BirthPlace="Ha Nam"}
            };
        public List<Member> GetMembersByName(string searchString){
              if (String.IsNullOrEmpty(searchString))
              {
                  return members;
              }
              return members.Where(p=>p.Name.Contains(searchString)).ToList();
        }
        public void DeleteMember(int index){
            if (CheckIndexIsValid(index))
            {
                members.RemoveAt(index);
            }
        }

        public List<Member> GetMembers(){
             return members;
        } 
        public Member GetMemberByIndex(int index){
            if (!CheckIndexIsValid(index))
            {
                return null;
            }
            Member member = members[index];
            return member;
        }
        public void AddMember(Member member){
            members.Add(member);
        }

        bool CheckIndexIsValid(int index){
            return (index < members.Count && index >=0);
        }

        public Member UpdateMember(int index, Member member){
            if (CheckIndexIsValid(index))
            {
                members[index] = member;
            }
            return members[index];
        }

    }
}