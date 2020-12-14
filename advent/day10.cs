using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    class day10
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
        //public static int findArrangements(List<int> list)
        //{
        //    int[] originalAr = new int[list.Count];
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        originalAr[i] = list[i];
        //    }
        //    List<int> original = originalAr.ToList();
        //    for (int i = 0; i < list.Count; i++)
        //    {q
        //        original = originalAr.ToList();
        //        list = original;
        //        list.Remove()
        //    }
        //}
        public static int getNum(List<int> list)
        {
            int one = 0;
            int three = 0;
            list.Sort();
            list.Add(list[list.Count - 1] + 3);

            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    if (list[i] == 1)
                        one++;
                    else if (list[i] == 3)
                        three++;
                }
                 if(i+1 < list.Count)
                 {
                    if (list[i] + 1 == list[i + 1])
                        one++;
                    else if (list[i] + 3 == list[i + 1])
                        three++;
                 }
               
                    
            }
            return three * one;
        }

    }
}
