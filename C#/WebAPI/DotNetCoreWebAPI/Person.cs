using System;
namespace DotNetCoreWebAPI
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string BirthPlace { get; set; }
        public bool IsGraduated { get; set; }
    }
}