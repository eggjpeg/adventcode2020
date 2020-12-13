using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    class day8
    {
        public static List<string> getStrings(string file)
        {
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    if (!(String.IsNullOrEmpty(line)))
                        list.Add(line);
            }
            return list;
        }
        public static Tuple<string,int> parseLine(string line)
        {
            string[] ar = line.Split(' ');
            return new Tuple<string, int>(ar[0], int.Parse(ar[1]));
        }
        public static int changeCommands(List<string> list)
        {
            string[] originalAr = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                originalAr[i] = list[i];
            }
           List<string> original =  originalAr.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                original = originalAr.ToList();
                list = original; // copying issue
                var tup = parseLine(list[i]);
                if (tup.Item1.Equals("nop"))
                {
                    string s = list[i].Replace("nop", "jmp");
                    list[i] = s;
                   var tup1 = execute(list);
                    if (tup1.Item1)
                        return tup1.Item2;
                }
                else if (tup.Item1.Equals("jmp"))
                {
                    string s = list[i].Replace("jmp", "nop");
                    list[i] = s;
                    var tup2 = execute(list);
                    if (tup2.Item1)
                        return tup2.Item2;
                }
            }
            return -1;
        }
        public static Tuple<bool,int> execute(List<string> list)
        {
            List<int> visited = new List<int>();
            int acc = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (visited.Contains(i))
                    return new Tuple<bool,int>(false,0);
                visited.Add(i);

                var tup =  parseLine(list[i]);
                if (tup.Item1.Equals("nop"))
                    continue;
                else if (tup.Item1.Equals("acc"))
                    acc += tup.Item2;
                else if (tup.Item1.Equals("jmp"))
                    i += tup.Item2 - 1;
            }
            return new Tuple<bool,int>(true,acc);
        }

    }
}
