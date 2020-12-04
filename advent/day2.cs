using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    class day2
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
        //3-13 s: kwjbvbgxhwsbskjdkbv
        public static bool checkPassIndex(string line)
        {
            string[] pw = line.Split(':');
            string[] s = pw[0].Split(' ');
            char c = Convert.ToChar(s[1]);
            string[] range = s[0].Split('-');
            int first = Convert.ToInt32(range[0]);
            int second = Convert.ToInt32(range[1]);

            if (pw[1][first] == c ^ pw[1][second] == c)
                return true;
            return false;

        }
        public static int getPasswordsIndex(List<string> list)
        {
            int acc = 0;
            for (int i = 0; i < list.Count; i++)
                if (checkPassIndex(list[i]))
                    acc++;
            return acc;
        }
        public static int getPasswords(List<string> list)
        {
            int acc = 0;
            for (int i = 0; i < list.Count; i++)
                if (checkPass(list[i]))
                    acc++;
            return acc;
        }
        public static bool checkPass(string line)
        {
            string[] pw = line.Split(':');
            string[] s = pw[0].Split(' ');
            char c = Convert.ToChar(s[1]);
            string[] range = s[0].Split('-');
            int min = Convert.ToInt32(range[0]);
            int max = Convert.ToInt32(range[1]);
            int acc = 0;
            foreach (char ch in pw[1])
            {
               
                if (ch.Equals(c))
                    acc++;
                if (acc > max)
                    return false;
            }
            if (acc < min)
                return false;
            return true;
        }
    }
}
