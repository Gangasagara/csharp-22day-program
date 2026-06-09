using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssingment
{
    internal class LeaderElement
    {
        public static List<int> FindLeader(int[] a)
        {
            List<int> li = new List<int>();
            int n = a.Length;
            li.Add(a[n - 1]);
           for(int i=n-2; i>=0; i--)
            {
                bool isleader = true;
                for(int j=i+1; j<n; j++)
                {
                    if (a[i] <= a[j])
                    {
                        isleader = false;
                        break;
                    }
                }
                if(isleader)
                 li.Add(a[i]);

            }
            return li;
        }
        public static void Main(string[] args)
        {
            string[] str= Console.ReadLine().Split(" ");
            int[] a = new int[str.Length];
            for(int i=0; i<str.Length; i++)
            {
                a[i] = int.Parse(str[i]);
            }
            List<int> ans = FindLeader(a);
            ans.Reverse();
            foreach(var val in ans)
            {
                Console.Write(val + " ");
            }
        }
    }
}
