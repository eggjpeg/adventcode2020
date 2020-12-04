using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = day4.getStrings("files/passports.txt");
           int p =  day4.getPassports(list);
            Console.WriteLine(p);
            Console.ReadLine();
        }
       
    }
}
