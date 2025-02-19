using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab_2
{
    public partial class part
    {
        private const int file1 = 1;
        public void firstmetod()
        {
            Console.WriteLine($"метод, вызванный в {file1} файле");
        }
    }
    public class Stack
    {
        private List<double> stack;
        private static readonly int maxexemplars = 1;
        private static int numberofexemlars = 0;

        private static int ObjectNumber = 0;


        // Свойство только для чтения (ограниченный set)
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
                Console.WriteLine("больше экземпляров создать нельзя");
            }
            return null;
        }
        public double this[int index]
        {
            get { return stack[index]; }
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
                foreach (double element in stack)
                {
                    if (element < 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public double TopElement
        {
            get { return stack[stack.Count - 1]; }
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
            return $"Cтек с {stack.Count} элементами: [{string.Join(", ", stack)}]";
        }





    }

    class Program
    {
        private int newpole;

       public int new678
        {
            get { return newpole; }
            set{ newpole = value; }
        }
        public static void AnalyzeStack(ref Stack stack, out double maxElement)
        {
            maxElement = double.MinValue;


            foreach (var element in stack.StackData)
            {
                if (element > maxElement)
                {
                    maxElement = element;
                }
            }
        }
        static void Main()
        {
            Stack[] massivestacks = new Stack[3];

            Stack stack2 = new Stack(5);

            massivestacks[0] = new Stack();
            massivestacks[0].Push(42);
            massivestacks[0].Push(-3);
            massivestacks[0].Push(84);
            massivestacks[0].Push(9);

            massivestacks[1] = new Stack();
            massivestacks[1].Push(73.5);
            massivestacks[1].Push(78.4);
            massivestacks[1].Push(25.1);
            massivestacks[1].Push(55);
            massivestacks[1].Push(241);

            massivestacks[2] = new Stack();
            massivestacks[2].Push(63);
            massivestacks[2].Push(-1.1);
            massivestacks[2].Push(2.8);
            massivestacks[2].Push(-90);
            massivestacks[2].Push(33);
            massivestacks[2].Push(-56.2);
            massivestacks[2].Push(32.9);

            Stack mintop = massivestacks[0];
            Stack maxtop = massivestacks[0];

            double minIndex = 0, maxIndex = 0;

            for (int i = 0; i < massivestacks.Length; i++)
            {
                if (massivestacks[i].TopElement < mintop.TopElement)
                {
                    mintop = massivestacks[i];
                    minIndex = i;
                }

                if (massivestacks[i].TopElement > maxtop.TopElement)
                {
                    maxtop = massivestacks[i];
                    maxIndex = i;
                }
            }

            double number = 1;

            Console.WriteLine($"Стек с наибольшим верхним элементом ({maxtop.TopElement}): номер {maxIndex + 1}");
            Console.WriteLine($"Стек с наименьшим верхним элементом ({mintop.TopElement}): номер {minIndex + 1}");

            Console.WriteLine($"стеки, содержащие отрицательные элементы: ");
            foreach (var nstacks in massivestacks)
            {
                if (nstacks.HasNegativeElements)
                {
                    Console.WriteLine($"стек {number} содержит отрицательные элементы");
                }
                number++;
            }

            for (int i = 0; i < massivestacks.Length; i++)
            {
                Stack currentStack = massivestacks[i];
                double maxElement;

                AnalyzeStack(ref currentStack, out maxElement);

                Console.WriteLine($"максимальный элемент стека {i + 1}: {maxElement}");
            }

            Stack zakrut1 = Stack.kzakrutomu();
            Stack zakrut2 = Stack.kzakrutomu();

            Stack.ClassInfo();

            part partl = new part();
            partl.firstmetod();
            partl.secondmetod();

            Stack stack3 = new Stack();
            stack3.Push(1);
            stack3.Push(2);

            Stack stack4 = new Stack();
            stack4.Push(1);
            stack4.Push(2);

            Console.WriteLine(stack3.Equals(stack4));
            Console.WriteLine(stack3.GetHashCode());
            Console.WriteLine(stack3.ToString());

            Type thetype = massivestacks.GetType();
            Console.WriteLine($"тип созданных объектов: {thetype}");

            Stack newww = new Stack();
            newww.Push(3);
            newww.Push(4);
            newww.Push(5);

           Stack addd= Stack.kzakrutomu();

            var anonumus = new
            {
                StackData = new List<double> { 1, 2, 3 },
                ElementCount = 3,
                IsEmpty = false
            };

        }

    }

}