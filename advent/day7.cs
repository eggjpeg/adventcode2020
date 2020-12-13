using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    class day7
    {

        public static List<string> getStrings(string file)
        {
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    list.Add(line);
            }
            return list;
        }
        public static Tuple<string,List<string>> processLine(string line)
        {
            line.Trim(',');
            List<string> children = new List<string>();
            string parent = "";
            string[] ar = line.Split(' ');
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = 0; j < ar[i].Length; j++)
                {
                    if (int.TryParse(ar[i], out int r))
                    {
                        children.Add(ar[i + 1] + " " + ar[i+2] + " " +ar[i+3]);
                        i += 4;
                    }
                    if (ar[i].Equals("contain"))
                    {
                        parent = ar[i - 1] + " " + ar[i - 2] + " " + ar[i - 3];
                    }

                }

            }
            return new Tuple<string, List<string>>(parent, children);
        }
        public static void BuildTree(List<string> list, int n)
        {
            var tup = processLine(list[n]);
        }


    }
    class Node
    {
        public string parent;
        public string children;
        public string color;

    }
}
    