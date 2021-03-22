using System;
using System.Collections.Generic;

namespace CSharpFundamental
{
    class Program
    {
        static List<Member> listMember = new List<Member>();
        static void Main(string[] args)
        {
            GetMembers();
           int c;
           do
           {
               menu();
               System.Console.WriteLine("Choose : ");
                c= Int32.Parse(Console.ReadLine());
               switch (c)
           {
               case 1:
            System.Console.WriteLine("1.Male Member : ");
            foreach (var item in GetMembersIsMale())
            {
                System.Console.WriteLine(item.toString());
            }
               break;
               case 2:
               System.Console.WriteLine("2.Oldest Member : "+OldestMember(listMember).toString());
               break;
               case 3:
                System.Console.WriteLine("3.List Fullname : ");
             foreach (var Member in listMember){
                  System.Console.WriteLine(Member.FullName());
             }
               break;
               case 4:
                            System.Console.WriteLine("4-1 . List Member BirthYear = 2000 : ");
             foreach (var Member in BirthYearIs2000()){
                  System.Console.WriteLine(Member.toString());
             }
               break;
               case 5:
                            System.Console.WriteLine("4-2 . List Member BirthYear < 2000 : ");
             foreach (var Member in BirthYearLess2000()){
                  System.Console.WriteLine(Member.toString());
             }
               break;
               case 6:
                            System.Console.WriteLine("4-3 . List Member BirthYear  > 2000 : ");
             foreach (var Member in BirthYearGreater2000()){
                  System.Console.WriteLine(Member.toString());
             }
               break;
               case 7:
                   System.Console.WriteLine("5 . Oldest Member who was born in Hn  : "+OldestMember(BirthPlaceInHN()).toString());
               break;
               case 8:
               System.Console.WriteLine("6 . List Member join before 22/03/2021 : ");
             foreach (var Member in JoinBefore22032021()){
                  System.Console.WriteLine(Member.toString());
             }
               break;
               case 9:
               System.Console.WriteLine("End");
               break;

               default:

               break;
           }
           } while (c!=9);  
        }
        static void menu(){
            System.Console.WriteLine("--------------------------------------");
              System.Console.WriteLine("1.Show Male Member");
              System.Console.WriteLine("2.Oldest Member ");
              System.Console.WriteLine("3. List Fullname of member");
              System.Console.WriteLine("4. List Member BirthYear = 2000 ");
              System.Console.WriteLine("5. List Member BirthYear > 2000 ");
              System.Console.WriteLine("6. List Member BirthYear < 2000 ");
              System.Console.WriteLine("7. Oldest Member who was born in Ha Noi  ");
              System.Console.WriteLine("8. List  Member Join before 22/03/2021 ");
              System.Console.WriteLine("--------------------------------------");  
        }
        static List<Member> BirthPlaceInHN(){
            return listMember.FindAll(p=>p.birthPlace=="Ha Noi");
        }
        static public List<Member> BirthYearGreater2000(){
                        return listMember.FindAll(p=>p.birthday.Year>2000);
        }
        static public List<Member> BirthYearLess2000(){
                        return listMember.FindAll(p=>p.birthday.Year<2000);
        }
        static public List<Member> BirthYearIs2000(){
            return listMember.FindAll(p=>p.birthday.Year==2000);
        }
        static public List<Member> GetMembersIsMale(){
             return listMember.FindAll(p=>p.gender=="Male");
        }
        static public Member OldestMember(List<Member> members){
            Member OldestMember = members[0];
             foreach (var Member in members)
            {

                if (OldestMember.birthday.CompareTo(Member.birthday)>0)
                {
                    OldestMember=Member;
                }
            }
            return OldestMember;
        }
        static public List<Member> JoinBefore22032021(){
            DateTime time = new DateTime(2021,03,22);
            return listMember.FindAll(p=>DateTime.Compare(p.startDate,time)<0);
        }
        static public void GetMembers(){
            List<Member> Member =  new  List<Member>(){
                new Member(){firstName="Tr",lastName="Cv01",birthday=Convert.ToDateTime("12/18/2001"),gender="Male",phone="012345678",isGraduated=true,birthPlace="Hai Phong",startDate=new DateTime(2021,03,22)}
                ,new Member(){firstName="Th",lastName="Cv02",birthday=Convert.ToDateTime("01/12/2000"),gender="Female",phone="012345678",isGraduated=true,birthPlace="Ha Noi",startDate=new DateTime(2021,03,21)}
                ,new Member(){firstName="Tv",lastName="Cv04",birthday=Convert.ToDateTime("08/12/1995"),gender="Female",phone="012345678",isGraduated=true,birthPlace="Ha Noi",startDate=new DateTime(2021,03,20)}
                ,new Member(){firstName="Tb",lastName="Cv03",birthday=Convert.ToDateTime("01/11/2001"),gender="Male",phone="012345678",isGraduated=true,birthPlace="Ha Noi",startDate=new DateTime(2021,03,19)}
                ,new Member(){firstName="Td",lastName="Cv04",birthday=Convert.ToDateTime("08/12/2002"),gender="Female",phone="012345678",isGraduated=true,birthPlace="Hai Phong",startDate=new DateTime(2021,03,20)}
                ,new Member(){firstName="Tv",lastName="Cv04",birthday=Convert.ToDateTime("08/12/1998"),gender="Female",phone="012345678",isGraduated=true,birthPlace="Hai Phong",startDate=new DateTime(2021,03,19)}
            };
            listMember.AddRange(Member); 
        }
    }
}
