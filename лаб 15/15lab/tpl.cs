using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    public class Tpl
    {
        public static void MultiplyVector(double[] vector, double multiplier)
        {
            Parallel.For(0, vector.Length, i =>
            {
                vector[i] *= multiplier;
            });
        }
        public static void Task3()
        {
            Task<int> task1 = Task.Run(() => CalculateSum(1000));
            Task<int> task2 = Task.Run(() => CalculateSum(1000));
            Task<int> task3 = Task.Run(() => CalculateSum(10));

            var res = Task.WhenAll(task1, task2, task3).ContinueWith(t =>
            {
                int sum = t.Result[0];
                int average = t.Result[1];
                int product = t.Result[2];
                int all;
                return all = sum + average + product;
            });
            Console.WriteLine($"Result of task 3-4: {res.Result}");
        }
        static int CalculateSum(int count)
        {
            return Enumerable.Range(1, count).Sum();
        }
        public static async Task Wait()
        {
            var firstTask = PrintNameAsync("first");
            var secondTask = PrintNameAsync("second");
            var thirdTask = PrintNameAsync("third");

            await firstTask;
            await secondTask;
            await thirdTask;
            // определение асинхронного метода
            async Task PrintNameAsync(string name)
            {
                await Task.Delay(3000);     // имитация продолжительной работы
                Console.WriteLine(name);
            }
        }
    }
}
