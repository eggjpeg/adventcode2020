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
            var list = day12.getStrings("files/day12input.txt");
            int r = day12.getPos(list);
            Console.WriteLine(r);
            Console.ReadLine();
        }
       
    }
}
