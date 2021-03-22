using System;
namespace CSharpFundamental
{
    class  Member : Person
    {
       public DateTime startDate { get; set; }
       public DateTime endDate { get; set; }
        public Member() : base()
        {
            
        }
         
        public string toString()
        {
            return  "firstName : "+firstName+" "+"lastName :"+lastName+" , "+" gender :"+gender+", birthday: "+birthday + " ,birthPlace " +birthPlace + " ,startDate: " + startDate;
        }
        public string FullName(){
            return $"{firstName} {endDate}";
        }
    }
}