using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAppMVC.Services
{
    public class TestService : ITestService
    {
       public List<string> ReturnListString(){
           return new List<string>(){
              "String 1","String 2" ,"String 3","String 4"
           };
       }
    }
}