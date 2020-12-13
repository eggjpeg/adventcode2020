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
            var list = day10.getNumbers("files/adapters.txt");
            int r = day10.getNum(list);
            Console.WriteLine(r);
            Console.ReadLine();
        }
       
    }
}
