using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    class day5
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
        public static int getRow(string line)
        {
            int min, max;
            min = (line[0].Equals('B')) ? 63 : 0;
            max = (min == 63) ? 127 : 63;
            for (int i = 1; i < 7; i++)
            {
                if(i == 6)
                {
                    if (line[i].Equals('F'))
                        return min;
                    return max;
                }
                if (line[i].Equals('F'))
                {
                    max = (min + max + 1) / 2;
                }
                else if(line[i].Equals('B'))
                {
                    min = (min + max + 1) / 2;
                }
            }
            return -1;
        }
        public static int getId(string line)
        {
           return getRow(line) * 8 + getCol(line);
        }
        public static int findHighest(List<string> list)
        {
            int highest = getId(list[0]);
            for (int i = 1; i < list.Count; i++)
            {
                if (getId(list[i]) > highest)
                    highest = getId(list[i]);
            }
            return highest;
        }       
        public static int findMySeat(List<string> list)
        {
            List<int> idList = new List<int>();
            for (int i = 1; i < list.Count - 1; i++)
            {
                idList.Add(getId(list[i]));
            }
            idList.Sort();
            for (int i = 0; i < idList.Count; i++)
            {
                if (idList[i] + 1 != idList[i + 1])
                    return idList[i] + 1;
            }
            return -1;
        }
        //BBBBFFBRRR
        public static int getCol(string line)
        {
            int min, max;
            min = (line[7].Equals('R')) ? 4 : 0;
            max = (min == 4) ? 7 : 3;
            for (int i = 8; i < 10; i++)
            {
                if (i == 9)
                {
                    if (line[i].Equals('L'))
                        return min;
                    return max;
                }
                if (line[i].Equals('L'))
                {
                    max = (min + max) / 2;
                }
                else if (line[i].Equals('R'))
                {
                    min = (min + max) / 2;
                }
            }
            return -1;
        }
    }
}
