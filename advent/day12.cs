using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    class day12
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
        public static int getNav(List<string> list)
        {
            int dir = 90;
            int ns = 0;
            int ew = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i][0].Equals('F'))
                {
                    if (dir.Equals(90) || dir.Equals(-270))
                    {
                        string[] ar = list[i].Split('F');
                        ew += int.Parse(ar[1]);

                    }
                    else if (dir.Equals(270) || dir.Equals(-90))
                    {
                        string[] ar = list[i].Split('F');
                        ew -= int.Parse(ar[1]);

                    }
                    else if (dir.Equals(0))
                    {
                        string[] ar = list[i].Split('F');
                        ns += int.Parse(ar[1]);

                    }
                    else if (dir.Equals(180) || dir.Equals(-180))
                    {
                        string[] ar = list[i].Split('F');
                        ns -= int.Parse(ar[1]);

                    }
                }
                else if (list[i][0].Equals('N'))
                {
                    string[] ar = list[i].Split('N');

                    ns += int.Parse(ar[1]);
                }
                else if (list[i][0].Equals('S'))
                {
                    string[] ar = list[i].Split('S');

                    ns -= int.Parse(ar[1]);
                }
                else if (list[i][0].Equals('E'))
                {
                    string[] ar = list[i].Split('E');

                    ew += int.Parse(ar[1]);
                }
                else if (list[i][0].Equals('W'))
                {
                    string[] ar = list[i].Split('W');

                    ew -= int.Parse(ar[1]);
                }
                else if (list[i][0].Equals('R'))
                {
                    string[] ar = list[i].Split('R');
                    dir += int.Parse(ar[1]);
                    dir %= 360;
                }
                else if (list[i][0].Equals('L'))
                {
                    string[] ar = list[i].Split('L');
                    dir -= int.Parse(ar[1]);
                    dir %= 360;
                }
            }

            return Math.Abs(ns) + Math.Abs(ew);
        }
        public static int getPos(List<string> list)
        {
            int dir = 0;
            List<int> shipPos = new List<int>();
            shipPos.Add(0);
            shipPos.Add(0);
            List<int> waypoint = new List<int>();
            waypoint.Add(1);
            waypoint.Add(10);
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i][0].Equals('F'))
                {
                    string[] ar = list[i].Split('F');
                    shipPos[0] += waypoint[0] * int.Parse(ar[1]);
                    shipPos[1] += waypoint[1] * int.Parse(ar[1]);
                }
                else if (list[i][0].Equals('N'))
                {
                    string[] ar = list[i].Split('N');
                    waypoint[0] += int.Parse(ar[1]);
                }
                else if (list[i][0].Equals('S'))
                {
                    string[] ar = list[i].Split('S');
                    waypoint[0] -= int.Parse(ar[1]);
                }
                else if (list[i][0].Equals('E'))
                {
                    string[] ar = list[i].Split('E');
                    waypoint[1] += int.Parse(ar[1]);
                }
                else if (list[i][0].Equals('W'))
                {
                    string[] ar = list[i].Split('W');
                    waypoint[1] -= int.Parse(ar[1]);
                }
                else if (list[i][0].Equals('R'))
                {
                    string[] ar = list[i].Split('R');
                        dir += int.Parse(ar[1]);
                    dir %= 360;
                    if (dir == 90|| dir == -270)
                    {
                        int temp = waypoint[0];
                        waypoint[0] = -waypoint[1];
                        waypoint[1] = temp;
                    }
                    else if(dir==180)
                    {
                        waypoint[0] = -waypoint[0];
                        waypoint[1] = -waypoint[1];
                    }
                    else if (dir==270 || dir == -90)
                    {
                        int temp = waypoint[0];
                        waypoint[0] = waypoint[1];
                        waypoint[1] = -temp;
                    }
                }
                else if (list[i][0].Equals('L'))
                {
                    string[] ar = list[i].Split('L');
                    dir -= int.Parse(ar[1]);
                    dir %= 360;
                    if (dir == 270 || dir == -90)
                    {
                        int temp = waypoint[0];
                        waypoint[0] = -waypoint[1];
                        waypoint[1] = temp;
                    }
                    else if (dir == 180)
                    {
                        waypoint[0] = -waypoint[0];
                        waypoint[1] = -waypoint[1];
                    }
                    else if (dir == 90 || dir == -270)
                    {
                        int temp = waypoint[0];
                        waypoint[0] = waypoint[1];
                        waypoint[1] = -temp;
                    }
                }
            }
            return Math.Abs(shipPos[0]) + Math.Abs(shipPos[1]);
        } // 13340
    }
}
