using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace debug
{
    internal class Program
    {
        [Serializable]
        public class ErrorWhileMunising : Exception
        {
            public ErrorWhileMunising(string message)
                : base(message) { }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Ffirst number:");
            string xstring = Console.ReadLine();
            List<int> x = new List<int>();
            Console.WriteLine("Enter second number:");
            string ystring = Console.ReadLine();
            List<int> y = new List<int>();
            Console.WriteLine("Enter third number:");
            string zstring = Console.ReadLine();
            List<int> z = new List<int>();
            List<int> p = new List<int>();
            for (int i = 0; i < xstring.Length; i++)
            {
                x.Add(Convert.ToInt32(xstring[i].ToString()));
            }
            for (int i = 0; i < ystring.Length; i++)
            {
                y.Add(Convert.ToInt32(ystring[i].ToString()));
            }
            for (int i = 0; i < zstring.Length; i++)
            {
                z.Add(Convert.ToInt32(zstring[i].ToString()));
            }
            //p = Plus(x, y);
            //p = Minus(x, y);
            p = Minus(x, y);
            p = Minus(p, z);
            foreach (int item in p)
            {
                Console.Write(item);
            }
            Console.ReadLine();


        }
        public static List<int> Plus(List<int> a, List<int> b)
        {
            List<int> p = new List<int>();
            int perenos = 0;
            Normalize(a, b);
            for (int i = a.Count - 1; i > 0 - 1; i--)
            {
                p.Insert(0, a[i] + b[i]);
                if (perenos == 1)
                {
                    p[0] = p[0] + 1;
                    perenos--;
                }
                if (p[0] > 9)
                {
                    p[0] = p[0] - 10;
                    perenos++;
                }
            }
            if (perenos == 1)
            {
                p.Insert(0, 1);
            }

            return p;
        }
        public static void Normalize(List<int> x, List<int> y)
        {
            while (x.Count > y.Count)
            {
                y.Insert(0, 0);
            }
            while (y.Count > x.Count)
            {
                x.Insert(0, 0);
            }
        }
        public static List<int> Minus(List<int> a, List<int> b) // a must be > than b. There is no check of this condition in code.
        {
            List<int> p = new List<int>();
            Normalize(a, b);
            int perenos = 0;
            for (int i = a.Count - 1; i > 0 - 1; i--)
            {
                p.Insert(0, a[i] - b[i]);
                if (perenos == 1)
                {
                    p[0] = p[0] - 1;
                    perenos--;
                }
                if (p[0] < 0)
                {
                    p[0] = p[0] + 10;
                    perenos++;
                }
            }
            if (perenos != 0)
            {
                throw new ErrorWhileMunising("Error While minusing.");
            }
            return p;
        }
    }
}
