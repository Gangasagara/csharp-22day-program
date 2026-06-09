using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssingment
{
    internal class DuplicateAndMissing
    {
        public static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int[] a = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                a[i] = int.Parse(str[i]);
            }
            int[] ans = new int[a.Length + 1];
            foreach(var val in a)
            {
                ans[val]++;
            }
            int duplicate = -1;
            int missing = -1;
            for(int i=1; i<ans.Length; i++)
            {
                if (ans[i] == 0)
                    missing = i;
                if (ans[i] == 2)
                    duplicate = i;
            }
            Console.WriteLine($"duplicate : {duplicate}, missing : {missing}");
        }
    }
}
