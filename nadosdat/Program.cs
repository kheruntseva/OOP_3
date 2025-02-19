using System;

namespace nadosdat
{
    //класс компьютер
    public class computer: IComparable<computer>
    {
        string PROCESSOR;
        string RAM;
        int PRICE;

        public computer(string processor,string ram,int price)
        {
            PROCESSOR = processor;
            RAM = ram;
            PRICE = price;
        }

        public static int CompareTo(computer Computer, computer other)
        {
           var sravn1 = (Computer.PROCESSOR, Computer.RAM, Computer.PRICE);
           var sravn2 = (other.PROCESSOR, other.RAM, other.PRICE);
           int nado= sravn1.CompareTo(sravn2);
           return nado;
        }

        public static bool operator true(computer p1, computer p2)
        {

            if (p1 == p2)
            {
                return true;
            }
            else return false;
        }
        public static bool operator false(computer p1, computer p2)
        {
            if (p1 == p2)
            {
                return false;
            }
            else return true;
        }

     
    }

    static class rashir
    {
        
        public static void covert(this computer Computer, string god, string valuta)
        {
            
            int price1=1;
            int god1 = Convert.ToInt32(god);
            if(god1 <2015&&valuta=="eur")
            {
                price1 = price1 * 2;
            }
            if (god1 < 2015 && valuta == "usd")
            {
                price1 = price1 * 3;
            }
            if (god1 < 2015 && valuta == "eur")
            {
                price1 = price1 * 4;
            }
            if (god1 < 2015 && valuta == "usd")
            {
                price1 = price1 * 5;
            }

        }
    }
    class Program
    {
        enum daysofweek
        {
            sunday,
            monday,
            tusday,
            thursday,
            friday,
            satarday,
            sundays
        }
        static void Main(string[] args)
        {
            foreach (var days in Enum.GetValues(typeof(daysofweek)))
            {
                Console.WriteLine(days);
            }

            //массив целых чисел + сумма
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int summa = 0;
            foreach(int nums in numbers)
            {
                summa += nums;
            }
            Console.WriteLine("${summa}");

 
        }
    }
}
