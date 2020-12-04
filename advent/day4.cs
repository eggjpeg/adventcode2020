using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent
{
    class day4
    {
        public static List<string> getStrings(string file)
        {
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(file))
            {
                StringBuilder sb = new StringBuilder();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if(String.IsNullOrEmpty(line))
                    {
                        list.Add(sb.ToString());
                        sb.Clear();
                    }
                    else
                        sb.Append(line + " ");
                }
            }
            return list;
        }
        public static bool checkValidation(string passportInfo)
        {
            string[] info = passportInfo.Split(' ');
            foreach (var item in info)
            {
               string [] moreInfo =  item.Split(':');
                if(moreInfo[0].Equals("byr"))
                {
                     int.TryParse(moreInfo[1], out int r);
                    if (r < 1920 && r > 2020)
                        return false;
                }
                else if(moreInfo[0].Equals("iyr"))
                {
                    int.TryParse(moreInfo[1], out int r);
                    if (r < 2010 && r > 2020)
                        return false;
                }
                else if (moreInfo[0].Equals("eyr"))
                {
                    int.TryParse(moreInfo[1], out int r);
                    if (r < 2020 && r > 2030)
                        return false;
                }
                else if (moreInfo[0].Equals("hgt"))
                {
                    StringBuilder sb = new StringBuilder();
                    if (moreInfo[1].Contains("in") || moreInfo[1].Contains("cm"))
                        Console.WriteLine("yeet"); 
                    else
                    {
                        return false;
                    }

                    for (int i = 0; i < moreInfo[1].Length; i++)
                    {
                        if(int.TryParse(moreInfo[1][i].ToString(), out int r))
                        {
                            sb.Append(r.ToString());
                        }
                        if (moreInfo[1][i] == 'c' && moreInfo[1][i+1] == 'm')
                        {
                            if (int.TryParse(sb.ToString(),out int h))
                            {
                                if (h < 150 || h > 193)
                                    return false;
                            }
                        }
                        if (moreInfo[1][i] == 'i' && moreInfo[1][i+1] == 'n')
                        {
                            if (int.TryParse(sb.ToString(), out int h))
                            {
                                if (h < 59 || h > 76)
                                    return false;
                            }
                        }
                    }
                }
                else if (moreInfo[0].Equals("hcl"))
                {
                    bool isHex;
                    foreach (var c in moreInfo[1])
                    {
                        if (moreInfo[1][0] == '#' && c == '#')
                            continue;
                        else
                        {
                            isHex = ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'));

                            if (!isHex)
                                return false;
                        }
                    }
                }
                else if (moreInfo[0].Equals("ecl"))
                {
                    if (moreInfo[1].Equals("amb") || moreInfo[1].Equals("blu") || moreInfo[1].Equals("brn") || moreInfo[1].Equals("gry") || moreInfo[1].Equals("grn") || moreInfo[1].Equals("hzl") || moreInfo[1].Equals("oth"))
                        continue;
                    else
                        return false;
                }
                else if (moreInfo[0].Equals("pid"))
                {
                    if (moreInfo[1].Length != 9)
                        return false;
                    if (!long.TryParse(moreInfo[1], out long r))
                        return false;
                }
            }
            return true;
        }
        public static int getPassports(List<string> list)
        {
            int acc = 0;
            foreach (var p in list)
            {
                if (checkPassport(p) && checkValidation(p))
                    acc++;
            }
            return acc;
        }
        public static bool checkPassport(string passportInfo)
        {
             return passportInfo.Contains("ecl") && passportInfo.Contains("pid") && passportInfo.Contains("hgt") && passportInfo.Contains("hcl") && passportInfo.Contains("eyr") && passportInfo.Contains("iyr") && passportInfo.Contains("byr");
        }
    }
}
