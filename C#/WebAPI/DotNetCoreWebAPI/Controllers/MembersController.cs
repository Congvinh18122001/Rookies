using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreWebAPI.Repository;
namespace DotNetCoreWebAPI.Controllers
{
    [Route("api/Members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private IMemberHandler _memberHandler;
        public MembersController(IMemberHandler memberHandler)
        {
            _memberHandler = memberHandler;
        }
        [HttpGet]
        [Route("FilterByGender/{gender}")]
        public List<Member> FilterMembersByGender(string gender)
        {
            return _memberHandler.FilterMembersByGender(gender);
        }
        [HttpGet]
        [Route("ReturnTheOldestMember")]
        public Member ReturnTheOldestMember()
        {
            return _memberHandler.ReturnTheOldestMember();
        }
        [HttpGet]
        [Route("GetFullNameMembers")]
        public List<string> GetFullNameMembers()
        {
            return _memberHandler.GetFullNameMembers();
        }
      
        [HttpGet]
        [Route("FilterMembersByBirthYear/{year}")]
        public List<Member> FilterMembersByBirthYear(int year)
        {
            return _memberHandler.FilterMembersByBirthYear(year);
        }
        [HttpGet]
        [Route("FilterMembersByBirthYearGreater/{year}")]
        public List<Member> FilterMembersByBirthYearGreaterYear(int year)
        {
            return _memberHandler.FilterMembersByBirthYearGreaterYear(year);
        }
        [HttpGet]
        [Route("FilterMembersByBirthYearLess/{year}")]
        public List<Member> FilterMembersByBirthYearLessYear(int year)
        {
            return _memberHandler.FilterMembersByBirthYearLessYear(year);
        }
        [HttpGet]
        [Route("FirstMemberInLocation/{location}")]
        public Member FirstMemberInLocation(string location)
        {
            return _memberHandler.FirstMemberInLocation(location);
        }
        [HttpGet]
        [Route("MemberJoinBefore22032021")]
        public List<Member> MemberJoinBefore22032021()
        {
            return _memberHandler.MemberJoinBefore22032021();
        }
        [HttpPost]
        public void Post([FromBody] Member member)
        {
            _memberHandler.AddMember(member);
        }

        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] Member member)
        // {
        // }

        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        //      _members.RemoveAll(p=>p.Id == id);
        // }
    }
}