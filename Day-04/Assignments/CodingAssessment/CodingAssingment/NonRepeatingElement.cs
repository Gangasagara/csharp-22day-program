using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssingment
{
    internal class NonRepeatingElement
    {
        public static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            //int[] a = new int[str.Length];
            int xor = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int val = int.Parse(str[i]);
                xor ^= val;
            }
            Console.WriteLine(xor);
        }
    }
}
