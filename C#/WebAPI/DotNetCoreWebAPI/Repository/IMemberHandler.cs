using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace DotNetCoreWebAPI.Repository
{
    public interface IMemberHandler
    {
        // 1.	Return a list of members who is Male

         List<Member> FilterMembersByGender(string gender);
        //2.	Return the oldest one based on “Age”
         Member ReturnTheOldestMember();
        //3.	Return a new list that contains Full Name only 
         List<string> GetFullNameMembers();
        //4.	Return 3 lists:
         //o	List of members who has birth year is 2000
         List<Member> FilterMembersByBirthYear(int year);
        //o	List of members who has birth year greater than 2000
         List<Member> FilterMembersByBirthYearGreaterYear(int year);
        //o	List of members who has birth year less than 2000
         List<Member> FilterMembersByBirthYearLessYear(int year);

        //5.	Return the first person who was born in Ha Noi.
        Member FirstMemberInLocation(string location);
        // Add Member
        void AddMember(Member member);

         //6.	Return List of member who join class before 22/03/2021.
        List<Member> MemberJoinBefore22032021();

    }
}