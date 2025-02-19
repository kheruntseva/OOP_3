using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    public class ParallelTask
    {
        public static void CyclesUpgrade()
        {
            int s = 1000000;
            int[] array = new int[s];

            Random r = new Random();

            void FillArray(int s)
            {
                array[s] = r.Next();
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Parallel.For(0, s, FillArray);

            Console.WriteLine($"Time of Parallel.For: {sw.Elapsed}");

            sw.Start();
            for (int i = 0; i < s; i++)
            {
                array[i] = r.Next();
            }
            Console.WriteLine($"Time of simple cycle for: {sw.Elapsed}");
        }
    }
}
