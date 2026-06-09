using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssingment
{
    internal class stringanagrams
    {
        public static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(" ");
            if(arr.Length<2)
            {
                Console.WriteLine("Please enter two strings");
                return;
            }
            if (string.IsNullOrWhiteSpace(arr[0]) || string.IsNullOrWhiteSpace(arr[1]))
            {
                Console.WriteLine("INvalid input");
                return;
            }
            char[] s1 = arr[0].Replace(" ","").ToLower().ToCharArray();
            char[] s2 = arr[1].Replace(" ","").ToLower().ToCharArray();
            
            Array.Sort(s1);
            Array.Sort(s2);
            if (s1.SequenceEqual(s2))
                Console.WriteLine("strings are anagrams");
            else {
                Console.WriteLine("strings are Not anagrams");
            }
        }
    
    }
}
