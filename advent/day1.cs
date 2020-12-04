using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
   public class day1
    {
         public static List<int> getNumbers(string file)
        {
            List<int> list = new List<int>();
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    list.Add(int.Parse(line));
            }
            return list;
        }
         public  static int getSolution(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
                for (int j = 0; j < list.Count - 1; j++)
                    for (int k = 0; k < list.Count - 1; k++)
                        if (list[i] + list[j] + list[k] == 2020)
                        {
                            Console.WriteLine(list[i] + " " + list[j] + " " + list[k]);
                            return list[i] * list[j] * list[k];
                        }
            return -1;
        }
    }
}
