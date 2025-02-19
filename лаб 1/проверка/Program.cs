using System;

namespace проверка
{
    class Program
    {
        static void Main(string[] args)
        {


            // Кортеж из 5 элементов с указанными типами
            (int, string, char, string, ulong) myTuple = (25, "Hello", 'A', "World", 1234567890UL);

            // Выводим кортеж целиком
            Console.WriteLine("Кортеж целиком:");
            Console.WriteLine(myTuple);

            // Выборочный вывод: 1, 3 и 4 элементы кортежа
            Console.WriteLine("\nВыборочные элементы кортежа:");
            Console.WriteLine($"1 элемент (int): {myTuple.Item1}");
            Console.WriteLine($"3 элемент (char): {myTuple.Item3}");
            Console.WriteLine($"4 элемент (string): {myTuple.Item4}");

            //Выполним распаковку кортежа в переменные
            var (age, greeting1, letter, word1, bigNumber) = myTuple;

            Console.WriteLine("\nРаспаковка кортежа:");
            Console.WriteLine($"Возраст: {age}, Приветствие: {greeting1}, Буква: {letter}, Слово: {word1}, Большое число: {bigNumber}");

            // Частичная распаковка с использованием _
            var (_, _, symbol, _, _) = myTuple;
            Console.WriteLine($"\nИспользование переменной '_': символ = {symbol}");

            //Сравним два кортежа
            var anotherTuple = (25, "Hello", 'A', "World", 1234567890UL);
            bool areTuplesEqual = myTuple == anotherTuple;
            Console.WriteLine($"\nСравнение кортежей: {areTuplesEqual}");

            // Сравним кортежи с другими значениями
            var differentTuple = (30, "Hi", 'B', "Earth", 9876543210UL);
            bool areTuplesDifferent = myTuple == differentTuple;
            Console.WriteLine($"Сравнение с другим кортежем: {areTuplesDifferent}");



        }
    }
}
