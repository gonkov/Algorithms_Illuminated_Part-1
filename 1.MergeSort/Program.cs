using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    class Program
    {


        public static void Main()
        {
            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

            a = Sorting(a);
            foreach (int item in a)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

        }
        public static List<int> Sorting(List<int> a)
        {
            List<int> b = new List<int>();
            List<int> c = new List<int>();

            for (int i = 0; i < a.Count / 2; i++)
            {
                b.Add(a[i]);
            }
            for (int i = a.Count / 2; i < a.Count; i++)
            {
                c.Add(a[i]);
            }

            if (b.Count > 1)
            {
                b = Sorting(b);
            }
            if (c.Count > 1)
            {
                c = Sorting(c);
            }
            a = Merge(b, c);
            return a;

        }
        public static List<int> Merge(List<int> b, List<int> c)
        {
            List<int> a = new List<int>();
            while (b.Count > 0 && c.Count > 0)
            {
                if (b[0] < c[0])
                {
                    a.Add(b[0]);
                    b.RemoveAt(0);
                }
                else
                {
                    a.Add(c[0]);
                    c.RemoveAt(0);
                }

            }
            if (b.Count == 0)
            {
                foreach (var item in c)
                {
                    a.Add(item);
                }
            }
            else
            {
                foreach (var item in b)
                {
                    a.Add(item);
                }
            }
            return a;
        }


    }
}  