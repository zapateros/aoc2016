using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1  = new int[] {0, 0, 0, 0, 0, 0, 0, 0};
            char[] array2 = { '0', '1', '2', '3', '4', '5', '6', '7' };
            string nums   = "01234567";
            string part1  = "";
            int i         = -1;
            int cnt       = 0;
            while (1 == 1)
            {
                i++;
                string password = @"uqwqemis";
                string v = String.Concat(password, i);
                byte[] encodedPassword = new UTF8Encoding().GetBytes(v);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string encoded = BitConverter.ToString(hash)
                   // without dashes
                   .Replace("-", string.Empty)
                   // make lowercase
                   .ToLower();

                 string fr = encoded.Substring(0, 5);
                if(fr == "00000")
                {
                    //Console.WriteLine(encoded);
                    cnt++;
                    part1 = String.Concat(part1, encoded[5]);
                    if(cnt == 8)
                    {
                        Console.WriteLine(String.Concat("Part 1: ", part1));
                    }
                    if (nums.Contains(encoded[5]))
                    {
                        int place = encoded[5] - '0';
                        if(array1[place] == 0)
                        {
                            array2[place] = encoded[6];
                            array1[place] = 1;
                            if(string.Join("", array1) == "11111111")
                            {
                                Console.WriteLine(String.Concat("Part 2: ", string.Join("", array2)));
                                break;
                            }
                        }
                    } 
                }
            }
            Console.ReadKey();
        }
    }
}
