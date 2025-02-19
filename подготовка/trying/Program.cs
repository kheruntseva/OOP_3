using System;

namespace trying
{

    //создать интерфейс IGraph с методом int First(). реализовать в point интерфейс(First должен подсчитывать количество точек в первой четверти). создать класс Line, который содержит 2 объкта типа pointи реализует IGraph

    public interface IGraph
    {
        int First();
    };

    public class Line: IGraph
    {
        public point POINT1;
        public point POINT2;

        public Line(point p1, point p2)
        {
            POINT1 = p1;
            POINT2 = p2;
        }
        public int First()
        {
            return POINT1.First() + POINT2.First();

        }

    }
    //создать класс point c координатами x,y,z. перезагрузить операции + и -. класс должен реализовывать интерфейс icomparable. создать 2 объекта и сравнить на =, >, <. проверить операции.

    public class point: IComparable<point>, IGraph
    {
     public int X;
     public int Y;
     public int Z;

    public point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public int First()
        {
            if (X > 0 && Y > 0) return 1;
            else return 0;

        }


        public int CompareTo(point other)
        {
            if (other == null) return 1;

            int srav1 = (X + Y + Z);
            int srav2 = (other.X + other.Y + other.Z);

            return srav1.CompareTo(srav2);
        }

        public static point operator +(point p1, point p2)
        {
            return new point(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }

        public static point operator -(point p1, point p2)
        {
            return new point(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

    }


    class Program
    {
        enum daysofweek
        {
            monday, tusday, wensday, thursday, friday, satarday, sunday
        }
        static void Main(string[] args)
        {
            //11

            //ввести с консоли 2 числа, сложить их и сохранить результат в строку.
            Console.WriteLine("введите первое чило");
            string num1 = Console.ReadLine();
            int num11 = int.Parse(num1);

            Console.WriteLine("введите второе число");
            string num2 = Console.ReadLine();
            int num22 = Convert.ToInt32(num2);

            int num33 = num11 + num22;

            string obsh = Convert.ToString(num33);

            //создать двумерный массив строк, инициализировать его и посчитать общее количество букв

            string[,] arraystring =
            {
                {"first", "second"},
                {"third", "fourth"}
            };

            int letters = 0;

            for (int i = 0; i < arraystring.GetLength(0); i++)
            {
                for (int k = 0; k < arraystring.GetLength(1); k++)
                {
                    letters += arraystring[i, k].Length;
                }
            }

            //создать класс point c координатами x,y,z. перезагрузить операции + и -. класс должен реализовывать интерфейс icomparable. создать 2 объекта и сравнить на =, >, <. проверить операции.
            point point1 = new point(1, 2, 3);
            point point2 = new point(4, 8, 6);

            int bolsh = point1.CompareTo(point2);

            if (bolsh > 0)
            {
                Console.WriteLine("point1>point2");
            }
            else if (bolsh < 0)
            {
                Console.WriteLine("point1<point2");
            }
            else if(bolsh==0)
            {
                Console.WriteLine("point1=point2");
            }
        

            // создайте перечисление с днями недели и выведете их на консоль
        
            foreach(var day in Enum.GetValues(typeof(daysofweek)))
            {
                Console.WriteLine(day);
            }

            // введите массив целых, объедените их в одно число

            Console.WriteLine("введите массив чисел через пробел");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            int[] nums = Array.ConvertAll(numbers, int.Parse);

            int kol = 0;

            foreach(int nus in nums)
            {
                kol = kol * 10 + nus;
            }


        }
    }
}
