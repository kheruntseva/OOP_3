using System;
using System.Linq;
using System.Collections.Generic;

namespace lab_linq
{
    public class Stack
    {
        private List<double> stack;
        private static readonly int maxexemplars = 1;
        private static int numberofexemlars = 0;
        private static int ObjectNumber = 0;

        public static int NumberOfExemplars
        {
            get { return numberofexemlars; }
        }

        public Stack()
        {
            stack = new List<double>();
            ObjectNumber++;
        }

        public Stack(int size)
        {
            stack = new List<double>();
            for (int i = 0; i < size; i++)
            {
                stack.Add(0);
            }
            ObjectNumber++;
        }

        static Stack()
        {
            numberofexemlars = 0;
        }

        private Stack(bool chtobubezoshibok)
        {
            numberofexemlars++;
        }

        public static Stack kzakrutomu()
        {
            if (numberofexemlars < maxexemplars)
            {
                return new Stack(true);
            }
            else
            {
                Console.WriteLine("Больше экземпляров создать нельзя");
            }
            return null;
        }

        public double this[int index]
        {
            get { return stack[index]; }
        }

        public double TopElement
        {
            get { return stack.Last(); }
        }


        public List<double> StackData
        {
            get { return stack; }
            set { stack = value; }
        }

        public void Push(double chislo)
        {
            stack.Add(chislo);
        }

        public double Pop()
        {
            double chislo = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return chislo;
        }

        public bool IsEmpty
        {
            get { return stack.Count == 0; }
        }

        public bool HasNegativeElements
        {
            get
            {
                return stack.Any(x => x < 0);
            }
        }

        public double Magnitude
        {
            get
            {
                return Math.Sqrt(stack.Sum(x => x * x));
            }
        }

        public static void ClassInfo()
        {
            Console.WriteLine($"Информация о классе Stack:");
            Console.WriteLine($"Количество созданных объектов: {ObjectNumber}");
        }

        public override bool Equals(object obj)
        {
            if (obj is Stack otherStack)
            {
                return stack.SequenceEqual(otherStack.stack);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var item in stack)
            {
                hash = hash * 31 + item.GetHashCode();
            }
            return hash;
        }

        public override string ToString()
        {
            return $"Стек с {stack.Count} элементами: [{string.Join(", ", stack)}]";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Массив месяцев
            string[] months =
            {
                "January", "February", "March", "April",
                "May", "June", "July", "August",
                "September", "October", "November", "December"
            };

            int n = 4;
            var lengthNMonths = months.Where(m => m.Length == n);
            Console.WriteLine($"Месяцы с длиной строки {n}: {string.Join(", ", lengthNMonths)}");

            var summerAndWinterMonths = months.Where(m =>
                m == "June" || m == "July" || m == "August" ||
                m == "December" || m == "January" || m == "February");
            Console.WriteLine($"Летние и зимние месяцы: {string.Join(", ", summerAndWinterMonths)}");

            var sortedMonths = months.OrderBy(m => m);
            Console.WriteLine($"Месяцы в алфавитном порядке: {string.Join(", ", sortedMonths)}");

            var filteredMonths = months.Where(m => m.Contains('u') && m.Length >= 4);
            Console.WriteLine($"Месяцы, содержащие букву 'u' и длиной не менее 4: {string.Join(", ", filteredMonths)}");

            // 2. Коллекция List<Stack>
            List<Stack> stacklist = new List<Stack>();

            for (int i = 0; i < 10; i++)
            {
                Stack stack = new Stack();
                stack.Push(i * 2 - 5); // Пример данных
                stack.Push(i - 3);
                stacklist.Add(stack);
            }

            Console.WriteLine("\nЭлементы коллекции List типа Stack:");
            foreach (var stack in stacklist)
            {
                Console.WriteLine(stack);
            }

            // Запросы LINQ
            int zeroCount = stacklist.Count(s => s.StackData.Contains(0));
            Console.WriteLine($"\nКоличество векторов, содержащих 0: {zeroCount}");

            var minMagnitudeStack = stacklist.OrderBy(s => s.Magnitude).FirstOrDefault();
            Console.WriteLine($"Стек с наименьшим модулем: {minMagnitudeStack}");

            var maxStack = stacklist.OrderByDescending(s => s.Magnitude).FirstOrDefault();
            Console.WriteLine($"Максимальный вектор: {maxStack}");

            var firstNegativeStack = stacklist.FirstOrDefault(s => s.HasNegativeElements);
            Console.WriteLine($"Первый стек с отрицательным значением: {firstNegativeStack}");

            var sortedStacks = stacklist.OrderBy(s => s.Magnitude);
            Console.WriteLine("\nУпорядоченные стеки по размеру:");
            foreach (var stack in sortedStacks)
            {
                Console.WriteLine(stack);
            }

            // Придуманный запрос
            var customQuery = stacklist
                .Where(s => s.StackData.Any(x => x < 0)) 
                .OrderByDescending(s => s.Magnitude)   
                .Select(s => new { s.TopElement, s.Magnitude }) 
                .Take(3);                             
            Console.WriteLine("\nПользовательский запрос (топ 3 стека):");
            foreach (var item in customQuery)
            {
                Console.WriteLine($"Top: {item.TopElement}, Magnitude: {item.Magnitude}");
            }

            // Join запрос
            var joinedQuery = months.Join(
                stacklist,
                month => month.Length,
                stack => stack.StackData.Count,
                (month, stack) => new { Month = month, Stack = stack }
            );
            Console.WriteLine("\nJoin запрос:");
            foreach (var pair in joinedQuery)
            {
                Console.WriteLine($"элементы Month: {pair.Month}, элементы Stack: {pair.Stack}");
            }
        }
    }
}
