using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2_Problem___Search_max_element_of_unimodal_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();
            int x = 0;
            int y = a.Count - 1;
            Console.WriteLine(Qsearch(a, x, y));
            Console.ReadLine();
        }

        private static int Qsearch(List<int> a, int x, int y)
        {
            //basic case
            if ((y-x) <= 1)
            {
                if (a[x] > a[y])
                {
                    return x;
                }
                else
                {
                    return y;
                }
            }
            // recursion

            int z = (x + y) / 2;
            if (a[z] > a[z-1])
            {
                x = z;   
            }
            else
            {
                y = z;
            }
            return Qsearch(a, x, y);
        }
    }
}
