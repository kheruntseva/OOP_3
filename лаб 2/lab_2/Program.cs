using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_2
{

    public class Stack
    {

        private List<double> stack;

        // Конструктор по умолчанию
        public Stack()
        {
            stack = new List<double>();
        }

        public double this[int index]
        {
            get
            {
                return stack[index];
            }

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
        public bool empty()
        {
            return stack.Count == 0;
        }

        public bool Negative()
        {
            foreach(double element in stack)
            {
                if (element < 0)
                {
                    return true;
                }
            }
            return false;
        }

        public double topelement()
        {
            return stack[stack.Count - 1];
        }

    }

    class Program
    {
        static void Main()
        {
            Stack[] massivestacks = new Stack[3];

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
                if (massivestacks[i].topelement() < mintop.topelement())
                {
                    mintop = massivestacks[i];
                    minIndex = i;  // Запоминаем индекс стека с наименьшим верхним элементом
                }

                if (massivestacks[i].topelement() > maxtop.topelement())
                {
                    maxtop = massivestacks[i];
                    maxIndex = i;  // Запоминаем индекс стека с наибольшим верхним элементом
                }
            }


            double number;

                if (massivestacks[0] !=null)
                {
                    number = 1;
                }
                if (massivestacks[1] != null)
                {
                    number = 2;
                }
                else number = 3;

            Console.WriteLine($"Стек с наибольшим верхним элементом ({maxtop.topelement()}): номер {maxIndex + 1}");
            Console.WriteLine($"Стек с наименьшим верхним элементом ({mintop.topelement()}): номер {minIndex + 1}");

            Console.WriteLine($"стеки, содержащие отрицательные элементы: ");
            foreach(var nstacks in massivestacks)
            {
                if (nstacks.Negative())
                {
                    Console.WriteLine($"стек {number-1} содержит отрицательные элементы");
                }
                number++;
            }

        }
    }
}
