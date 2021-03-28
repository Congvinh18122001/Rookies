using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Repository
{
    public class MemberHandler : IMemberHandler
    {

        public MemberHandler()
        {
            SeedingData();
        }
         private static List<Member> _members = new List<Member>();
        // 1.	Return a list of members who is Male
         public List<Member> FilterMembersByGender(string gender){
               var members = _members.FindAll(p=>p.Gender==gender);
               return members;
         }
        //2.	Return the oldest one based on “Age”
        public  Member ReturnTheOldestMember(){
            var minDob = _members.Min(x=>x.Birthday);
               return  _members.FirstOrDefault(p=>p.Birthday==minDob);
         }
        //3.	Return a new list that contains Full Name only 
         public List<string> GetFullNameMembers(){
               return _members.Select(p=>p.Name).ToList();
         }
        //4.	Return 3 lists:
         //o	List of members who has birth year is 2000
         public List<Member> FilterMembersByBirthYear(int year){
               return _members.Where(p=>p.Birthday.Year==year).ToList();
         }
        //o	List of members who has birth year greater than 2000
         public List<Member> FilterMembersByBirthYearGreaterYear(int year){
               return _members.Where(p=>p.Birthday.Year>year).ToList();
         }
        //o	List of members who has birth year less than 2000
         public List<Member> FilterMembersByBirthYearLessYear(int year){
               return _members.Where(p=>p.Birthday.Year<year).ToList();
         }

        //5.	Return the first person who was born in Ha Noi.
       public  Member FirstMemberInLocation(string location){
               return _members.FirstOrDefault(p=>p.BirthPlace==location);
         }
         public void AddMember(Member member){
               if (member != null)
               {
                   _members.Add(member);
               }
         }
         //6.	Return List of member who join class before 22/03/2021.
      public  List<Member> MemberJoinBefore22032021(){
            return _members.FindAll(p=>p.StartDate < new DateTime(2021,3,22));
      }


         private void SeedingData(){
             _members.AddRange(
              new List<Member> 
              { 
              new Member {Id=1 ,Name="Truong Cong Vinh",Phone="0123654789",Birthday=DateTime.Now.AddYears(-27),Gender="Male",IsGraduated=true,BirthPlace="Hai Phong",StartDate=DateTime.Now.AddYears(-2),EndDate=DateTime.Now.AddYears(1)}
             ,new Member {Id=2 , Name="Vuong Cong Minh",Phone="0123654789",Birthday=DateTime.Now.AddYears(-25),Gender="Female",IsGraduated=true,BirthPlace="Ha Noi",StartDate=DateTime.Now.AddYears(-2),EndDate=DateTime.Now.AddYears(1)}
             ,new Member {Id=3 , Name="Kim Cong Tuan",Phone="0123654789",Birthday=DateTime.Now.AddYears(-21),Gender="Male",IsGraduated=true,BirthPlace="Hai Phong",StartDate=DateTime.Now.AddYears(-1),EndDate=DateTime.Now.AddYears(2)}
             ,new Member {Id=4 , Name="Truong Cong Tu",Phone="0123654789",Birthday=DateTime.Now.AddYears(-20),Gender="Female",IsGraduated=true,BirthPlace="Ha Noi",StartDate=DateTime.Now,EndDate=DateTime.Now.AddYears(3)}
             ,new Member {Id=5 , Name="Le Cong Duc",Phone="0123654789",Birthday=DateTime.Now.AddYears(-19),Gender="Male",IsGraduated=true,BirthPlace="Ha Nam",StartDate=DateTime.Now,EndDate=DateTime.Now.AddYears(3)}
             }
               );
         }
 
    }
}