using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    class day9
    {
        public static List<long> getNums(string file)
        {
            List<long> list = new List<long>();
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    if (!(String.IsNullOrEmpty(line)))
                        list.Add(long.Parse(line));
            }
            return list;
        }
        // 35 20 15 25 47 40
        public static bool checkPrevNums(List<long> prev, long n)
        {
            for (int i = 0; i < prev.Count; i++)
            {
                for (int j = i; j < prev.Count; j++)
                {
                    if (prev[i] + prev[j] == n)
                        return true;
                }
            }
            return false;
        }
        //22477624
        public static long findContiguous(List<long> list, long n)
        {
            long acc = 0;
            List<long> lst = new List<long>();
            for (int i = 0; i < list.Count; i++)
            {
                acc = 0;
                lst.Clear();
                for (int j = i; j < list.Count; j++)
                {
                    acc += list[j];
                    lst.Add(list[j]);
                    if (acc > n)
                        break;
                    if(acc == n)
                    {
                        long max = lst[0];
                        long min = lst[0];
                        for (int k = 1; k < lst.Count; k++)
                        {
                            if (lst[k] > max)
                                max = lst[k];
                            if (lst[k] < min)
                                min = lst[k];
                        }
                        return min + max;
                    }
                }
            }
            return -1;
        }
        public static long findNumber(List<long> list)
        {
            List<long> previous = new List<long>();
            for (int i = 0; i < 25; i++)
                previous.Add(list[i]);
            for (int i = 25; i < list.Count; i++)
            {
                if (!(checkPrevNums(previous, list[i])))
                    return list[i];
                previous.RemoveAt(0);
                previous.Add(list[i]);
            }
                
            return -1;
        }
    }
}
