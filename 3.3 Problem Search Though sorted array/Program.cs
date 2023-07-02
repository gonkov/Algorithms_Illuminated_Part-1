using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3_Problem_Search_Though_sorted_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();
            int x = 0;
            int y = a.Count - 1;
            if (a[x]>x || a[y] < y)
            {
                Console.WriteLine(false);
            }
            else
            {
                Console.WriteLine(Qsearch(a, x, y));
            }                      
            Console.ReadLine();
        }

        private static bool Qsearch(List<int> a, int x, int y)
        {
            if ((y-x) == 1)
            {
                if (a[y] == y || a[x] == x)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            int z = (x + y) / 2;
            if (a[z] > z)
            {
                y = z;
            }
            else if (a[z] < z)
            {
                x = z;
            }
            else
            {
                return true;
            }
            return Qsearch(a, x, y);
        }
    }
}
