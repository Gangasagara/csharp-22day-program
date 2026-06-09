using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssingment
{
    internal class FirstRepeatingElement
    {
        public static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");

            int[] a = new int[str.Length];
            for(int i=0; i<str.Length; i++)
            {
                a[i] = int.Parse(str[i]);
            }
            Dictionary<int, int> di = new Dictionary<int, int>();
            foreach(var val in a)
            {
                if (di.ContainsKey(val))
                    di[val]++;
                else
                    di[val] = 1;
            }
            foreach(var val in a)
            {
                if (di[val]>1)
                {
                    Console.WriteLine(val);
                    break;
                }
            }
        }
    }
}
