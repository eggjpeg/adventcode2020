using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    class day3
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
        public static int checkList(List<string> list, int n)
        {
            int index = n;
            int trees = 0;
            for (int i = 1; i < list.Count; i++)
            {
                 if (list[i][index] == '#')
                      trees++;
                index += n;
                index %= list[i].Length;
            }
            return trees;
        }
        public static int checkListDownTwo(List<string> list, int n)
        {
            int index = n;
            int trees = 0;
            for (int i = 2; i < list.Count; i+=2)
            {
                if (list[i][index] == '#')
                    trees++;
                index += n;
                index %= list[i].Length;
            }
            return trees;
        }

    }
}
