using System.Diagnostics;
using System.Threading.Tasks;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Threading;


namespace lab15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int vectorSize = 100000;
            double[] vector = Enumerable.Range(1, vectorSize).Select(i => (double)i).ToArray();
            double multiplier = 2.5;

            Stopwatch sw = Stopwatch.StartNew();
            Task multiplyTask = new Task(() =>
            {
                Tpl.MultiplyVector(vector, multiplier);
            });
            multiplyTask.Start();
            Task.Run(() =>
            {
                while (!multiplyTask.IsCompleted)
                {
                    Console.WriteLine($"Is done: {multiplyTask.Status}");
                    Task.Delay(500).Wait();
                }
                Console.WriteLine($"Is done: {multiplyTask.Status}");
            });

            multiplyTask.Wait();
            sw.Stop();
            //
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task multiplyTaskCopy = new Task(() =>
            {
                Tpl.MultiplyVector(vector, multiplier);
            });
            multiplyTaskCopy.Start();
            Task.Run(() =>
            {
                while (!multiplyTask.IsCompleted)
                {
                    Console.WriteLine($"Is done: {multiplyTask.Status}");
                    Task.Delay(500).Wait();
                }
                Console.WriteLine($"Is done: {multiplyTask.Status}");
            });
            Thread.Sleep(1000);

            // после задержки по времени отменяем выполнение задачи
            cancelTokenSource.Cancel();
            Thread.Sleep(1000);
            Console.WriteLine($"Task Status: {multiplyTaskCopy.Status}");
            cancelTokenSource.Dispose();

            Console.WriteLine($"Умножение завершено за {sw.Elapsed}");
            Console.WriteLine($"Task Id: {multiplyTask.Id}");

            Tpl.Task3();

            ParallelTask.CyclesUpgrade();

            Products product = new Products("item1", 120);
            Producer MilkaMaker = new Producer("trash", product, 52, 5);
            Buyer buyer = new Buyer("DK", product, 3);
            Warehouse warehouse = new Warehouse("WarehouseName");
            warehouse.RunStore(MilkaMaker, buyer);

            Tpl.Wait();
            Thread.Sleep(10000);
        }
    }
}