using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();
            int counter = 0;
            int k = a.Count;
            counter++;
            counter++;
            for (int i = 0; i < k - 1; i++)
            {
                counter++;
                counter++;
                counter++;
                for (int j = 0; j < k - 1; j++)
                {
                    counter++;
                    counter++;
                    counter++;
                    if (a[j] > a [j + 1])
                    {
                        counter = counter + 3;
                        int temp = a[j + 1];
                        a[j + 1] = a[j];
                        a[j] = temp;

                    }
                }
            }
            foreach (int item in a)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}
