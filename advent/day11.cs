using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    class day11
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
        public static string EvaluateRow(string line)
        {
            char[] ar = line.ToCharArray();
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i].Equals('.'))
                    continue;
                else if(ar[i].Equals('L'))
                {
                    if (ar[i - 1] < 0)
                    {
                        if (ar[i + 1] != '#')
                            ar[i] = '#';
                    }
                        
                    else if (ar[i + 1] > ar.Length)
                    {
                        if (ar[i - 1] != '#')
                            ar[i] = '#';
                    }
                    else if (ar[i-1] != '#' && ar[i+1] != '#')
                    {
                        ar[i] = '#';
                    }
                }
                else if(ar[i].Equals('#'))
                {
                   
                }
            }
        }
        
    }
}
