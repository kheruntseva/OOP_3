using System;

namespace lab3
{
    public class production
    {
        public double ID;
        public string NAME;
        public production(double id, string name)
        {
            ID = id;
            NAME = name;
        }
    }

    public class developer
    {
        string FIO, OTDEL;
        int ID;
        public developer(string fio,string otdel,int id)
        {
            FIO = fio;
            OTDEL = otdel;
            ID = id;
        }
    }

    public class array
    {
        public production info{ get; set; }
        public developer information { get; set; }

        public int[] arr;
        private int[] elements;

        public array(double id,string name)
        {
            info = new production(id, name);
        }

        public array(string fio, string otdel, int id)
        {
            information = new developer(fio, otdel, id);
        }
        public array(int size)
        {
            arr = new int[size];
        }

        public array(int[] Values)
        {
            arr = new int[Values.Length];
            for (int i = 0; i < Values.Length; i++)
            {
                arr[i] = Values[i];
            }
        }

        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        public static array operator *(array first, array second)
        {
            array result = new array(first.arr.Length);
            if (first.arr.Length == second.arr.Length)
            {
                for (int i = 0; i < first.arr.Length; i++)
                {
                    result[i] = first[i] * second[i];
                }
            }
            return result;
        }

        public static bool operator true(array arr)
        {
            foreach (int element in arr.arr)
            {
                if (element < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator false(array arr)
        {
            foreach (int element in arr.arr)
            {
                if (element < 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static explicit operator int(array arr)
        {
            int dlina = arr.arr.Length;
            return dlina;
        }

        public static bool operator ==(array first, array second)
        {
            if (first.arr.Length == second.arr.Length)
            {
                for (int i = 0; i < first.arr.Length; i++)
                {
                    if (first[i] == second[i])
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public static bool operator !=(array first, array second)
        {
            if (first.arr.Length == second.arr.Length)
            {
                for (int i = 0; i < first.arr.Length; i++)
                {
                    if (first[i] == second[i])
                    {
                        return false;
                    }
                    return true;
                }
            }
            return true;
        }

        public static bool operator >(array first, array second)
        {
            if (first.arr.Length > second.arr.Length)
            {
                return true;
            }

            if (first.arr.Length < second.arr.Length)
            {
                return false;
            }

            if (first.arr.Length == second.arr.Length)
            {
                int sum1 = 0; int sum2 = 0;
                for (int k = 0; k < first.arr.Length; k++)
                {
                    sum1 = sum1 + first[k];
                }

                for (int k = 0; k < second.arr.Length; k++)
                {
                    sum2 = sum2 + second[k];
                }

                if (sum1 > sum2)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool operator <(array first, array second)
        {
            if (first.arr.Length > second.arr.Length)
            {
                return false;
            }

            if (first.arr.Length < second.arr.Length)
            {
                return true;
            }

            if (first.arr.Length == second.arr.Length)
            {
                int sum1 = 0; int sum2 = 0;
                for (int k = 0; k < first.arr.Length; k++)
                {
                    sum1 = sum1 + first[k];
                }

                for (int k = 0; k < second.arr.Length; k++)
                {
                    sum2 = sum2 + second[k];
                }

                if (sum1 > sum2)
                {
                    return false;
                }
                return true;
            }
            return true;
        }


    }

    public static class rashiren
    {
        public static bool ischar(this string str, char letter)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == letter)
                {
                    return true;
                }
            }
            return false;
        }

        public static int[] deleteNegative(this array arr)
        {
            int positive = 0;
            for (int i = 0; i < arr.arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    positive++;
                }
            }

            int[] positivearr = new int[positive];
            int ind = 0;

            for (int i = 0; i < arr.arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    positivearr[ind] = arr[i];
                    ind++;
                }
            }

            return positivearr;
        }

    }

    static class StatisticOperation
    {
        public static int sum(this array arr)
        {
            int sum = 0;
            for(int i=0;i<arr.arr.Length;i++)
            {
                sum += arr[i];
            }
            return sum;
        }  

        public static int raznica(this array arr)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i=0;i<arr.arr.Length;i++)
            {
                if(arr[i]<min)
                {
                    min = arr[i];
                }

                if(arr[i]>max)
                {
                    max = arr[i];
                }
            }
            return max - min;
        }

        public static int podschet(this array arr)
        {
            return arr.arr.Length;
        }

        public static int CountSymbols(this string str)
        {
            int count = 0;
            foreach (char c in str)
            {
                count++;
            }
            return count;
        }

    }
    class Program
     {

        static void Main(string[] args)
        { 
            array array1 = new array(new int[] { 1, 2, 3, 4, 5 });
            array array2 = new array(new int[] { 1, 2, 3, 4, -6 });

            bool sravnenie = array1 > array2;

            array array3 = array1 * array2;

            Console.WriteLine($"умножение 2 - ух массивов: ");
              for (int i = 0; i<array1.arr.Length; i++)
           {
              Console.WriteLine($"{array3[i]}");
           }

            Console.WriteLine($"array1>array2: {sravnenie} ");

            if (array2)
            {
                Console.WriteLine("array2 не содержит отрицательные элементы.");
            }
            else
            {
                Console.WriteLine("array2 содержит отрицательные элементы.");
            }

            int razmer=(int)array1;
            Console.WriteLine(razmer);

            bool ravenstvo = array1 == array2;
            Console.WriteLine(ravenstvo);

            array informaton = new array(172, "organizaciya");

            array info = new array("Херунцева Дарья Юрьевна", "разработка", 229);
           

        }

    }

}
