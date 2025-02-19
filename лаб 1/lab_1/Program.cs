using System;
using System.Text;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            (int , string,int,string) tuple = (34, "ssss",54,"aaaa");
            string str333 = ($"{tuple.Item1}, {tuple.Item3}");
            Console.WriteLine(str333);

            (int firrst, _, int thirrd, _) = tuple;
            Console.WriteLine($"{firrst}, {thirrd}");
            int[,] Arr55 =
            {
                {1,2,3},
                {4,7,9}
            };
            for (int p = 0; p < Arr55.GetLength(0); p++)
            {
                for (int j = 0; j < Arr55.GetLength(1); j++)
                {
                    Console.Write(Arr55[p, j] + "\t");
                }
                Console.WriteLine();

            }
            byte b = 255;
            sbyte sb = -128;
            int i = 58;
            uint ui = 4294967295;
            short sh = 32;
            ushort us = 65;
            long lo = -9;
            ulong ul = 9;
            float fl = 0.9f;
            double Do = 3.14159;
            decimal De = 1000.25m;
            char Ch = 'A';
            string hello = "Hello";
            object a = 22;
            object c = "hello code";
            DateTime myDateTimeWithTime = new DateTime(2024, 9, 7, 14, 30, 0);
            DateTime currentDateTime = DateTime.Now;

            //неявное приведение
            int num = 2147483647;
            long bigNum = num;

            byte mybyte = 100;
            ulong myulong = mybyte;

            ushort myushort = 8;
            uint myuint = myushort;

            int myint = 30;
            float myfloat = myint;

            sbyte mysbyte = 127;
            double mydouble = mysbyte;

            //явные преобразования
            double x = 1234.7;
            int todo;
            todo = (int)x;

            long aaaa = 1000000;
            int bbbb = (int)aaaa;

            float ops = 3.14f;
            int popalsa = (int)ops;

            object myObject = "Hello, world!";
            string nado = (string)myObject;

            int tri = 256;
            byte ne = (byte)tri;

            //класс Convert

            // Преобразование строки в целое число
            string strNumber = "123";
            int number = Convert.ToInt32(strNumber);
            Console.WriteLine("Преобразование строки в целое: " + number);

            // Преобразование целого числа в строку
            int num3 = 456;
            string strFromNum = Convert.ToString(num3);
            Console.WriteLine("Преобразование числа в строку: " + strFromNum);

            // Преобразование булевого значения в строку
            bool boolValue = true;
            string strBool = Convert.ToString(boolValue);
            Console.WriteLine("Преобразование булевого значения в строку: " + strBool);

            //упаковка и распаковка значимых типов:
            int number5 = 123;
            object obj = number5; // Упаковка
            int unboxedNumber = (int)obj; // Распаковка

            byte chislo = 22;
            object nechislo = chislo;
            byte unboxedchislo = (byte)nechislo;

            //неявно типизированная переменная:
            var message = "Привет, мир!";
            Console.WriteLine($"Тип переменной 'message': {message.GetType()} - Значение: {message}");

            //пример работы с Nullable переменной 
            int? nullableNumber = null;

            if (nullableNumber.HasValue)
            {
                Console.WriteLine($"Значение nullableNumber: {nullableNumber.Value}");
            }
            else
            {
                Console.WriteLine("nullableNumber не имеет значения (null)");
            }

            nullableNumber = 100;

            if (nullableNumber.HasValue)
            {
                Console.WriteLine($"Теперь значение nullableNumber: {nullableNumber.Value}");
            }

            //задание f
            var number1 = 42;
            Console.WriteLine($"Тип переменной 'number': {number1.GetType()} - Значение: {number1}");

            //number1 = "Hello, world!";
            /* Ошибка: В C# переменные, объявленные с использованием ключевого слова var,
             * являются неявно типизированными. Это значит, что их тип выводится компилятором
             * на основе значения, присваиваемого им при инициализации. Однако, после того как тип
             * переменной был определён при первой инициализации, он не может измениться на другой.*/

            //объявление строковых литералов
            string str1 = "Hello, World!";
            string str2 = "Hello, World!";
            string str3 = "Hello, C#!";

            bool areEqual1 = str1 == str2;
            bool areEqual2 = str1 == str3;

            Console.WriteLine($"Строки str1 и str2 равны: {areEqual1}");
            Console.WriteLine($"Строки str1 и str3 равны: {areEqual2}");

            //три строки на основе String
            string str11 = "Hello";
            string str22 = "World";
            string str33 = "C# is awesome!";

            //Сцепление строк
            string concatenated = String.Concat(str11, " ", str22);
            Console.WriteLine("Сцепление строк: " + concatenated);

            //Копирование строки
            string copiedStr = String.Copy(str33);
            Console.WriteLine("Копирование строки: " + copiedStr);

            //Выделение подстроки
            string substring = str33.Substring(4, 2);
            Console.WriteLine("Выделение подстроки: " + substring);

            //Разделение строки на слова
            string[] words = str33.Split(' ');
            Console.WriteLine("Разделение строки на слова:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            //Вставка подстроки в заданную позицию с использованием интерполяции
            string inserted = $"{str3.Insert(3, "programming in ")}";
            Console.WriteLine($"Вставка подстроки: {inserted}");

            //Удаление подстроки с интерполяцией
            string removed = $"{str3.Remove(4, 3)}";
            Console.WriteLine($"Удаление подстроки: {removed}");

            // Создаем пустую строку и строку, равную null
            string emptyString = "";   // Пустая строка
            string nullString = null;  // Строка со значением null

            // Используем метод string.IsNullOrEmpty для проверки строк
            Console.WriteLine($"emptyString пустая или null: {string.IsNullOrEmpty(emptyString)}");
            Console.WriteLine($"nullString пустая или null: {string.IsNullOrEmpty(nullString)}");

            //разные операции с пустой и null строками

            //Получение длины строки
            Console.WriteLine($"Длина emptyString: {emptyString.Length}");

            //Конкатенация с другими строками
            string concatenatedEmpty = emptyString + "Hello";
            string concatenatedNull = nullString + "Hello";
            Console.WriteLine($"Конкатенация с emptyString: {concatenatedEmpty}");
            Console.WriteLine($"Конкатенация с nullString: {concatenatedNull}");

            //Сравнение пустой и null строки
            bool areEqual = emptyString == nullString;
            Console.WriteLine($"emptyString == nullString: {areEqual}");

            //Приведение строки к верхнему регистру (работает только с пустой строкой)
            string upperEmpty = emptyString.ToUpper();

            if (!string.IsNullOrEmpty(nullString))
            {
                string upperNull = nullString.ToUpper(); // Этот код не выполнится
            }
            Console.WriteLine($"upperEmpty (пустая строка): '{upperEmpty}'");

            //Замена символов
            string replacedEmpty = emptyString.Replace("a", "b");
            Console.WriteLine($"Замена символов в emptyString: '{replacedEmpty}'");

            // Создаем строку на основе StringBuilder
            StringBuilder sb1 = new StringBuilder("Hello, World!");

            // Выводим исходную строку
            Console.WriteLine($"Исходная строка: {sb1}");

            // 1. Удаляем определенные позиции
            // Удаляем символы с 5 по 7 (например, запятая и пробел после "Hello")
            sb1.Remove(5, 2);
            Console.WriteLine($"После удаления символов: {sb1}"); // Результат: "HelloWorld!"

            // 2. Добавляем новые символы в начало строки
            sb1.Insert(0, "Start: ");
            Console.WriteLine($"После добавления в начало: {sb1}"); // Результат: "Start: HelloWorld!"

            // 3. Добавляем новые символы в конец строки
            sb1.Append(" :End");
            Console.WriteLine($"После добавления в конец: {sb1}");

            // Создаем двумерный целый массив 3x3
            int[,] matrix =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

            // Выводим массив на консоль в отформатированном виде
            Console.WriteLine("Матрица:");
            for (int p = 0; p < matrix.GetLength(0); p++) // цикл по строкам
            {
                for (int j = 0; j < matrix.GetLength(1); j++) // цикл по столбцам
                {
                    Console.Write(matrix[p, j] + "\t"); // вывод элемента и табуляция для выравнивания
                }
                Console.WriteLine(); // переход на новую строку после вывода строки матрицы

            }

            //одномерный массив строк
            string[] fruits = { "Apple", "Banana", "Orange", "Grapes", "Mango" };

            // Выводим содержимое массива и его длину
            Console.WriteLine("Содержимое массива:");
            for (int z = 0; z < fruits.Length; z++)
            {
                Console.WriteLine($"Элемент {z}: {fruits[z]}");
            }
            Console.WriteLine($"Длина массива: {fruits.Length}");

            // Запрашиваем у пользователя позицию и новое значение
            Console.WriteLine("\nВведите позицию элемента, который хотите изменить (от 0 до 4):");
            int position = int.Parse(Console.ReadLine());

            if (position >= 0 && position < fruits.Length)
            {
                Console.WriteLine("Введите новое значение для выбранного элемента:");
                string newValue = Console.ReadLine();

                // Меняем значение элемента на выбранной позиции
                fruits[position] = newValue;

                // Выводим обновленное содержимое массива
                Console.WriteLine("\nОбновленное содержимое массива:");
                for (int l = 0; l < fruits.Length; l++)
                {
                    Console.WriteLine($"Элемент {l}: {fruits[l]}");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: введена некорректная позиция.");
            }

            //ступенчатый массив вещественных чисел
            double[][] jaggedArray = new double[3][];
            jaggedArray[0] = new double[2]; // Первая строка с 2 столбцами
            jaggedArray[1] = new double[3]; // Вторая строка с 3 столбцами
            jaggedArray[2] = new double[4]; // Третья строка с 4 столбцами

            for (int w = 0; w < jaggedArray.Length; w++)
            {
                Console.WriteLine($"Введите {jaggedArray[w].Length} элементов для строки {w + 1}:");
                for (int j = 0; j < jaggedArray[w].Length; j++)
                {
                    Console.Write($"Элемент [{w + 1}][{j + 1}]: ");
                    jaggedArray[w][j] = double.Parse(Console.ReadLine());
                }
            }

            // Вывод ступенчататого массива
            Console.WriteLine("\nСтупенчатый массив:");
            for (int w = 0; w < jaggedArray.Length;w++)
            {
                for (int j = 0; j < jaggedArray[w].Length; j++)
                {
                    Console.Write(jaggedArray[w][j] + "\t");
                }
                Console.WriteLine();
            }

            // Неявно типизированная переменная для хранения массива целых чисел
            var numbers = new[] { 1, 2, 3, 4, 5 };

            // Неявно типизированная переменная для хранения строки
            var greeting = "Hello, World!";

            // Выводим массив
            Console.WriteLine("Массив чисел:");
            foreach (var number2 in numbers)
            {
                Console.Write(number2 + " ");
            }
            Console.WriteLine();

            // Выводим строку
            Console.WriteLine("Строка: " + greeting);

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

            //задание 5
            int[] nums = { 10, 20, 5, 7, 100 };
            string inputString = "Hello";

            // Локальная функция
            (int max, int min, int sum, char firstLetter) AnalyzeArrayAndString(int[] arr, string str)
            {
                // Максимум и минимум
                int max = int.MinValue;
                int min = int.MaxValue;
                int sum = 0;

                // Найдем максимум, минимум и сумму элементов массива
                foreach (int numr in arr)
                {
                    if (numr > max) max = numr;
                    if (numr < min) min = numr;
                    sum += number;
                }

                // Первая буква строки
                char firstLetter = str.Length > 0 ? str[0] : '\0'; // Если строка пуста, вернем символ '\0'

                return (max, min, sum, firstLetter);
            }

            // Вызов локальной функции
            var result = AnalyzeArrayAndString(nums, inputString);

            // Вывод результата
            Console.WriteLine($"Максимальный элемент: {result.max}");
            Console.WriteLine($"Минимальный элемент: {result.min}");
            Console.WriteLine($"Сумма элементов: {result.sum}");
            Console.WriteLine($"Первая буква строки: {result.firstLetter}");

            //6 задание
            // Локальная функция с блоком checked
            void CheckedOverflow()
            {
                try
                {
                    checked
                    {
                        int maxInt = int.MaxValue;  // Максимальное значение int
                        Console.WriteLine($"Значение до переполнения (checked): {maxInt}");
                        maxInt++;  // Попытка переполнить
                        Console.WriteLine($"Значение после переполнения (checked): {maxInt}");
                    }
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Исключение переполнения (checked): {ex.Message}");
                }
            }

            // Локальная функция с блоком unchecked
            void UncheckedOverflow()
            {
                unchecked
                {
                    int maxInt = int.MaxValue;  // Максимальное значение int
                    Console.WriteLine($"Значение до переполнения (unchecked): {maxInt}");
                    maxInt++;  // Попытка переполнить
                    Console.WriteLine($"Значение после переполнения (unchecked): {maxInt}");
                }
            }

            // Вызов функции с checked
            Console.WriteLine("Вызов функции CheckedOverflow:");
            CheckedOverflow();

            // Вызов функции с unchecked
            Console.WriteLine("\nВызов функции UncheckedOverflow:");
            UncheckedOverflow();

        }
    }
}
