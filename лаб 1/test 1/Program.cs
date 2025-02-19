using System;

namespace test_1
{
    class Program
    {
        static void Main()
        {
            int number = 10;
            Console.WriteLine($"Before: {number}"); // Вывод: Before: 10

            ModifyValue(number); // Передаем по ссылке

            Console.WriteLine($"After: {number}");  // Вывод: After: 20
        }

        static void ModifyValue( int value)
        {
            value = value * 2; // Изменяем значение переменной
        }

    }
}
