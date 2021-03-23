using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Prime
{
    class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine("Prime Numbers between 1 to 100 : ");
             for (int i = 2; i <= 100; i++)
             {
                 if (IsPrime(i))
                 {
                     Console.Write("\t" + i); 
                 }
            }
             Console.ReadKey();
        }
        static async Task<bool> IsPrime(int num){
                for (int i = 2; i < Math.Sqrt(num); i++)// base logic for the primality
                 {
                     if (num % i == 0) //modulo operators employed
                    {
                          return false;
                    }
                 }
                 return true;
        }
    }
}
