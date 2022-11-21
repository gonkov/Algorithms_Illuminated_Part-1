using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karatsuba_mult
{
    [Serializable]
    public class ErrorWhileMunising : Exception
    {
        public ErrorWhileMunising(string message)
            : base(message) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //input

            Console.WriteLine("Enter first number - a:");
            string xstring = Console.ReadLine();
            List<int> x = new List<int>();
            Console.WriteLine("Enter second number - b:");
            string ystring = Console.ReadLine();
            List<int> y = new List<int>();
            for (int i = 0; i < xstring.Length; i++)
            {
                x.Add(Convert.ToInt32(xstring[i].ToString()));
            }
            for (int i = 0; i < ystring.Length; i++)
            {
                y.Add(Convert.ToInt32(ystring[i].ToString()));
            }
            
            // main code

            List<int> KaratsubaMult = new List<int>();
            KaratsubaMult = Karatsuba(x,y);

            // output
            Console.WriteLine("a multiple b:");
            foreach (int item in KaratsubaMult)
            {
                Console.Write(item);
            }
            Console.ReadLine();
        }
        public static List<int> Karatsuba(List<int> x, List<int> y)
        {
            NormalizeTo_n2(x, y);
            int n = x.Count;
            List<int> result = new List<int>(); // here will be final result
            if (n == 1)
            {
                int mult = x[0] * y[0];
                result.Add(mult / 10);
                result.Add(mult % 10);
                return result;
            }
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            List<int> c = new List<int>();
            List<int> d = new List<int>();
            for (int i = 0; i < n/2; i++)
            {
                a.Add(x[i]);
                c.Add(y[i]);
            }
            for (int i = n/2; i < n ; i++)
            {
                b.Add(x[i]);
                d.Add(y[i]);
            }
            List<int> p = Plus(a,b);
            List<int> q = Plus(c,d);
            List<int> ac = new List<int>();
            ac = Karatsuba(a, c);
            List<int> bd = new List<int>();
            bd = Karatsuba(b, d);
            List<int> pq = new List<int>();
            pq = Karatsuba(p, q);
            List<int> adbc = new List<int>();
            adbc = Minus(pq, ac);
            adbc = Minus(adbc, bd);
            DeleteZeroS(adbc);
            for (int i = 0; i < n; i++)
            {
                ac.Add(0);
            }
            for (int i = 0; i < n / 2; i++)
            {
                adbc.Add(0);
            }

            result = Plus(ac,adbc);
            result = Plus(result, bd);
            DeleteZeroS(result);
            return result;

        }
        public static List<int> Plus (List<int> a, List<int> b) 
        {
            List<int> p = new List<int>();
            int perenos = 0;
            Normalize(a,b);
            for (int i = a.Count - 1; i > 0 - 1; i--)
            {
                p.Insert(0, a[i] + b[i]);
                if (perenos == 1)
                {
                    p[0] = p[0] + 1;
                    perenos --;
                }
                if (p[0] > 9)
                {
                    p[0] = p[0] - 10;
                    perenos ++;
                }
            }
            if (perenos == 1)
            {
                p.Insert(0, 1);
            }

            return p;
        }
        public static List<int> Minus(List<int> a, List<int> b) // a must be > than b.
        {
            List<int> p = new List<int>();
            Normalize(a,b);
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
                throw new ErrorWhileMunising("Error While minusing."); // Exception , if the result (p) is negative (<0).
            }
            return p;
        }
        public static void NormalizeTo_n2(List<int> x, List<int> y)
        {
            int xi = (int)Math.Log(x.Count, 2);
            if (Math.Pow(2,xi) < x.Count)
            {
                xi++;
            }
            int yi = (int)Math.Log(y.Count, 2);
            if (Math.Pow(2, yi) < y.Count)
            {
                yi++;
            }
            if (xi < yi)
            {
                xi = yi;
            }

            int xi_stepen = (int)Math.Pow(2, xi);

            while (xi_stepen > x.Count)
            {
                x.Insert(0,0);
            }
            while (xi_stepen > y.Count)
            {
                y.Insert(0, 0);
            }

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
        public static void DeleteZeroS(List<int> x)
        {
            while (x.Count > 0 && x[0] == 0)
            {
                x.RemoveAt(0);
            }

        }
    }
}
