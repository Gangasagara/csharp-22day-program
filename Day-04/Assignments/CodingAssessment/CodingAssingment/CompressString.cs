using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssingment
{
    internal class CompressString
    {
        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int count = 1;
            StringBuilder sb = new StringBuilder();
            for(int i = 1; i < str.Length; i++) 
            {
                if (str[i] == str[i - 1])
                    count++;
                else
                {
                    sb.Append(str[i - 1]);
                    sb.Append(count);
                    count = 0;
                }
            }
            if (sb.ToString().Length < str.Length)
                Console.WriteLine(sb.ToString());
            else
                Console.WriteLine(str);
        }
    }
}
