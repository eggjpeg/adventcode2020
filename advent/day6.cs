using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    class day6
    {
        public static List<List<string>> getStrings(string file)
        {
            List<List<string>> list = new List<List<string>>();
            List<string> subList = new List<string>();
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (String.IsNullOrEmpty(line))
                    {
                        list.Add(subList);
                        subList = new List<string>();
                    }
                    else
                        subList.Add(line);
                }
            }
            return list;
        }
        public static int countGroup(List<string> list)
        {
            List<char> chars = new List<char>();
            int total = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    if (chars.Contains(list[i][j]))
                        continue;
                    else
                    {
                        total++;
                        chars.Add(list[i][j]);
                    }
                }
            }
            return total;
        }
        public static int countGroupEveryone(List<string> list)
        {
            List<char> chars = new List<char>();
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    if (!(list[0].Contains(list[i][j])))
                    {
                        if(!(chars.Contains(list[i][j])))
                            chars.Add(list[i][j]);
                    }
                }
            }
            return list[0].Length - chars.Count;
        }
        public static int countGroups(List<List<string>> list)
        {
            int total = 0;
            for (int i = 0; i < list.Count; i++)
                total += countGroupEveryone(list[i]);
            return total;
        }
    }
}
