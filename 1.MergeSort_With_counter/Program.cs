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
            int counter = 0;
            a = Sorting(a , ref counter);
            foreach (int item in a)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine(counter);
            Console.ReadKey();

        }
        public static List<int> Sorting(List<int> a , ref int counter)
        {
            List<int> b = new List<int>();
            List<int> c = new List<int>();
            counter = counter + 2;

            counter++;
            for (int i = 0; i < a.Count / 2; i++)
            {
                counter = counter + 3;
                b.Add(a[i]);
            }
            counter++;
            for (int i = a.Count / 2; i < a.Count; i++)
            {
                counter = counter + 3;
                c.Add(a[i]);
            }

            counter++;
            if (b.Count > 1)
            {
                b = Sorting(b , ref counter);
            }
            counter++;
            if (c.Count > 1)
            {                
                c = Sorting(c , ref counter);
            }
            a = Merge(b, c, ref counter);
            return a;

        }
        public static List<int> Merge(List<int> b, List<int> c, ref int counter)
        {
            counter++;
            List<int> a = new List<int>();
            while (b.Count > 0 && c.Count > 0)
            {
                counter = counter + 2;
                counter++;
                if (b[0] < c[0]) 
                {
                    counter = counter + 2;
                    a.Add(b[0]);
                    b.RemoveAt(0);
                }
                else
                {
                    counter = counter + 2;
                    a.Add(c[0]);
                    c.RemoveAt(0);
                }

            }
            counter++;
            if (b.Count == 0)
            {
                foreach (var item in c)
                {
                    counter++;
                    a.Add(item);
                }
            }
            else
            {
                foreach (var item in b)
                {
                    counter++;
                    a.Add(item);
                }
            }
            return a;
        }


    }
}