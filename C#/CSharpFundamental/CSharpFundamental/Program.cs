using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpFundamental
{
    class Program
    {
        static void Main(string[] args)
        {


            System.Console.WriteLine("1.Male Member : ");
            foreach (var item in GetMembersIsMale())
            {
                System.Console.WriteLine(item.toString());
            }

            System.Console.WriteLine("2.Oldest Member : "+OldestMember(GetMembers()).toString());

            System.Console.WriteLine("3.List Fullname : ");
             foreach (var Member in GetMembers()){
                  System.Console.WriteLine(Member.FullName());
             }
             System.Console.WriteLine("4-1 . List BirthYear of Member = 2000 : ");
             foreach (var Member in BirthYearIs2000()){
                  System.Console.WriteLine(Member.toString());
             }
             System.Console.WriteLine("4-2 . List BirthYear of Member < 2000 : ");
             foreach (var Member in BirthYearLess2000()){
                  System.Console.WriteLine(Member.toString());
             }
             System.Console.WriteLine("4-3 . List BirthYear of Member > 2000 : ");
             foreach (var Member in BirthYearGreater2000()){
                  System.Console.WriteLine(Member.toString());
             }
             System.Console.WriteLine("5 . Oldest Member who was born in Hn  : "+OldestMember(BirthPlaceInHN()).toString());
             

            
        }
        static List<Member> BirthPlaceInHN(){
              List<Member> members=new List<Member>();
                foreach (var Member in GetMembers())
            {

                if (Member.BirthPlace=="Ha Noi")
                {
                    members.Add(Member);
                }
            }
            return members;
        }
        static public List<Member> BirthYearGreater2000(){
            List<Member> members=new List<Member>();
                foreach (var Member in GetMembers())
            {

                if (Member.Birthday.Year>2000)
                {
                    members.Add(Member);
                }
            }
            return members;
        }
        static public List<Member> BirthYearLess2000(){
            List<Member> members=new List<Member>();
                foreach (var Member in GetMembers())
            {

                if (Member.Birthday.Year<2000)
                {
                    members.Add(Member);
                }
            }
            return members;
        }
        static public List<Member> BirthYearIs2000(){
            List<Member> members=new List<Member>();
                foreach (var Member in GetMembers())
            {

                if (Member.Birthday.Year==2000)
                {
                    members.Add(Member);
                }
            }
            return members;
        }
        static public List<Member> GetMembersIsMale(){
            List<Member> members=new List<Member>();
                foreach (var Member in GetMembers())
            {

                if (Member.Gender=="Male")
                {
                    members.Add(Member);
                }
            }
            return members;
            
        }

        static public Member OldestMember(List<Member> members){
            Member OldestMember = members[0];
             foreach (var Member in members)
            {

                if (OldestMember.Birthday.CompareTo(Member.Birthday)>0)
                {
                    OldestMember=Member;
                }
            }
            return OldestMember;
        }
        
        static public List<Member> GetMembers(){
            return new  List<Member>(){
                new Member(){FirstName="Tr",LastName="Cv01",Birthday=Convert.ToDateTime("12/18/2002"),Gender="Male",Phone="012345678",IsGraduated=true,BirthPlace="Hai Phong"}
                ,new Member(){FirstName="Th",LastName="Cv02",Birthday=Convert.ToDateTime("01/12/2000"),Gender="Female",Phone="012345678",IsGraduated=true,BirthPlace="Ha Noi"}
                ,new Member(){FirstName="Tv",LastName="Cv04",Birthday=Convert.ToDateTime("08/12/1995"),Gender="Female",Phone="012345678",IsGraduated=true,BirthPlace="Ha Noi"}
                ,new Member(){FirstName="Tb",LastName="Cv03",Birthday=Convert.ToDateTime("01/11/2001"),Gender="Male",Phone="012345678",IsGraduated=true,BirthPlace="Ha Noi"}
                ,new Member(){FirstName="Td",LastName="Cv04",Birthday=Convert.ToDateTime("08/12/2002"),Gender="Female",Phone="012345678",IsGraduated=true,BirthPlace="Hai Phong"}
                ,new Member(){FirstName="Tv",LastName="Cv04",Birthday=Convert.ToDateTime("08/12/1998"),Gender="Female",Phone="012345678",IsGraduated=true,BirthPlace="Hai Phong"}
            };
        }

    }
    class  Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }  
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string BirthPlace { get; set; }
        public bool IsGraduated { get; set; }   

         
        public string toString()
        {
            return FirstName+" "+LastName+" , "+Gender+" , "+Birthday + " , " +BirthPlace;
        }
        public string FullName(){
            return FirstName+" "+LastName;
        }
    }
}
