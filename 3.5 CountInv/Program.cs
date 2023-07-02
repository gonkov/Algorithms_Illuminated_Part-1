using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._5_CountInv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>();
            StreamReader sr = new StreamReader("C:\\test\\Sample.txt");
            string line;
            line = sr.ReadLine();
            while (line != null)
            {
                a.Add(Convert.ToInt32(line));
                line = sr.ReadLine();

            }
            sr.Close();

            ulong inversions = 0;
            a = SortAndCountInv(a,ref inversions);
            Console.WriteLine(inversions);

            Console.ReadKey();
        }
        public static List<int> SortAndCountInv(List<int> a, ref ulong inversions)
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
                b = SortAndCountInv(b, ref inversions);
            }
            if (c.Count > 1)
            {
                c = SortAndCountInv(c, ref inversions);
            }
            a = MergeAndCountSplitInv(b, c , ref inversions);
            return a;

        }
        public static List<int> MergeAndCountSplitInv(List<int> b, List<int> c, ref ulong inversions)
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
                    inversions = inversions + Convert.ToUInt64(b.Count);
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
