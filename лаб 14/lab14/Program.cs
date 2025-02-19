using System;
using System.IO;
using System.Threading;

class Program
{
    private static readonly object syncLock = new object();
    private static readonly AutoResetEvent evenEvent = new AutoResetEvent(true);
    private static readonly AutoResetEvent oddEvent = new AutoResetEvent(false);


    static void Main(string[] args)
    {

        Console.ReadLine();

        Console.WriteLine("\nВведите n для вывода чисел поочередно (четное, нечетное): ");
        int n = int.Parse(Console.ReadLine());

        Thread evenThread = new Thread(() => WriteNumbersAlternately(n, true));  
        Thread oddThread = new Thread(() => WriteNumbersAlternately(n, false)); 

        evenThread.Start();
        oddThread.Start();

        evenThread.Join();
        oddThread.Join();

        Console.WriteLine("Нажмите Enter для завершения.");
        Console.ReadLine();
    }

    // Функция для вывода сначала четных, потом нечетных чисел
    static void WriteNumbers(int n, bool isEven)
    {
        string type = isEven ? "Четные" : "Нечетные";
        using (var writer = new StreamWriter($"{type}_numbers.txt"))
        {
            for (int i = 1; i <= n; i++)
            {
                if ((i % 2 == 0) == isEven)
                {
                    lock (syncLock)
                    {
                        Console.WriteLine(i);
                        writer.WriteLine(i);
                    }
                }
            }
        }
    }



    //вывод поочередно

    static void WriteNumbersAlternately(int n, bool isEven)
    {
        int start = isEven ? 2 : 1;  

        while (start <= n)
        {
          
            if (isEven)
            {
                evenEvent.WaitOne();
            }
            else
            {
                oddEvent.WaitOne(); 
            }

            Console.WriteLine(start);

            start += 2; 

          
            if (isEven)
            {
                oddEvent.Set();  
            }
            else
            {
                evenEvent.Set(); 
            }
        }
    }
}



