using System;
using System.Collections.Generic;
using System.IO;

namespace lab3
{

    public class PO
    {
        public string NAME;
        public string VERSION;

        public PO(string _name, string _version)
        {
            NAME = _name;
            VERSION = _version;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Software Name: {NAME}, Version: {VERSION}");
        }
    }

    public interface IProcessor<T>
    {
        T Process(T item);
    }

    public class POProcessor<T> : IProcessor<T> where T : PO
    {
        public T Process(T item)
        {
            Console.WriteLine("Processing item...");
            item.DisplayInfo();
            return item; 
        }
    }


    public interface Myiner<T> 
    {

        T add(T item);
        T delete(T item);
        T watch(T nomer);
        
    }


    public class production
    {
        public production() { }

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

        public developer() { }
        string FIO, OTDEL;
        int ID;
        public developer(string fio,string otdel,int id)
        {
            FIO = fio;
            OTDEL = otdel;
            ID = id;
        }
    }

    public class array<T>: Myiner<T> 
    {
        public array() { }

        public T add(T item)
        {

         T[] newarr=new T[arr.Length + 1];
         for(int i=0;i<arr.Length;i++)
            {
                newarr[i] = arr[i];
            }
            newarr[arr.Length] = item;

            arr = newarr;

            return item;

        }

        public T delete(T item)
        {
            List<T> spisok = new List<T>();

            foreach(T element in arr)
            {
                if (!element.Equals(item))
                {
                    spisok.Add(element);
                }
            }

            arr = spisok.ToArray();

            return item;

        }

        public T watch(T number)
        {
            int nado = 0;
           for(int i=0;i<arr.Length;i++)
            {
                dynamic k = 1;
                if (number==k+1)
                {
                    nado = Convert.ToInt32(nado) + Convert.ToInt32(number);
                }
            }

            dynamic number1 = number;
            dynamic length = arr.Length;
            try
            {
                if(number1 > length)
                {
                    throw new ArgumentOutOfRangeException(number1, "введенный порядковый номер превышает длину массива");
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            finally
            {
                Console.WriteLine("обработка ошибки завершена");
            }

            return (T)Convert.ChangeType(nado, typeof(T));
        }

        public void WriteToFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Путь к файлу не может быть пустым или null.", nameof(filePath));
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (T item in arr)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }

        public void ReadFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Путь к файлу не может быть пустым или null.", nameof(filePath));
            }

            List<T> items = new List<T>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    items.Add((T)Convert.ChangeType(line, typeof(T)));
                }
            }

            arr = items.ToArray();
        }




        public production info{ get; set; }
        public developer information { get; set; }

        public T[] arr;
        private T[] elements;

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
            arr = new T[size];
        }

        public array(T[] Values)
        {
            arr = new T[Values.Length];
            for (int i = 0; i < Values.Length; i++)
            {
                arr[i] = Values[i];
            }
        }

        public T this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        public static array<T> operator *(array<T> first, array<T> second)
        {
            array<T> result = new array<T>(first.arr.Length);
            if (first.arr.Length == second.arr.Length)
            {
                for (int i = 0; i < first.arr.Length; i++)
                {
                    dynamic value1 = first.arr[i];
                    dynamic value2 = second.arr[i];
                    result[i] = value1 * value2;
                }
            }
            return result;
        }

        public static bool operator true(array<T> arr)
        {
            foreach (T element in arr.arr)
            {
                dynamic element1 = element;
                if (element1 < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator false(array<T> arr)
        {
            foreach (T element in arr.arr)
            {
                dynamic element1 = element;
                if (element1 < 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static explicit operator T(array<T> arr)
        {
            dynamic dlina = arr.arr.Length;
            return dlina;
        }

        public static bool operator ==(array<T> first, array<T> second)
        {
            if (first.arr.Length == second.arr.Length)
            {
                for (int i = 0; i < first.arr.Length; i++)
                {
                    dynamic firrst = first[i];
                    dynamic seccond = second[i];
                    if (firrst == seccond)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public static bool operator !=(array<T> first, array<T> second)
        {
            if (first.arr.Length == second.arr.Length)
            {
                for (int i = 0; i < first.arr.Length; i++)
                {

                    dynamic firrst = first[i];
                    dynamic seccond = second[i];
                    if (firrst == seccond)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return true;
        }

        public static bool operator >(array<T> first, array<T> second)
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
                dynamic sum11 = sum1;
                for (int k = 0; k < first.arr.Length; k++)
                {
                    sum11 = sum11 + first[k];
                }

                dynamic sum22 = sum2;
                for (int k = 0; k < second.arr.Length; k++)
                {
                    sum22 = sum22 + second[k];
                }

                if (sum11 > sum22)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool operator <(array<T> first, array<T> second)
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

                dynamic sum11 = sum1;
                dynamic sum22 = sum1;
                for (int k = 0; k < first.arr.Length; k++)
                {
                    sum11 = sum11 + first[k];
                }

                for (int k = 0; k < second.arr.Length; k++)
                {
                    sum22 = sum22 + second[k];
                }

                if (sum11 > sum22)
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

        public static int[] deleteNegative(this array<ThreadStaticAttribute> arr)
        {
            int positive = 0;
            dynamic arr1 = arr;

            for (int i = 0; i < arr.arr.Length; i++)
            {
                
                if (arr1 >= 0)
                {
                    positive++;
                }
            }

            int[] positivearr = new int[positive];
            int ind = 0;

            for (int i = 0; i < arr.arr.Length; i++)
            {

                if (arr1 >= 0)
                {
                    positivearr[ind] = arr1;
                    ind++;
                }
            }

            return positivearr;
        }

    }

    static class StatisticOperation
    {
        public static int sum(this array<int> arr)
        {
            int sum = 0;
            dynamic sum1 = sum;
            for(int i=0;i<arr.arr.Length;i++)
            {
                sum1 += arr[i];
            }
            return sum;
        }  

        public static int raznica(this array<int> arr)
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

        public static int podschet(this array<int> arr)
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
            array<double> array1 = new array<double>(new double[] { 1, 2, 3, 4, 5 });
            array<double> array2 = new array<double>(new double[] { 1, 2, 3, 4, -6 });

            bool sravnenie = array1 > array2;

            array<double> array3 = array1 * array2;

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

            array<production> informaton = new array<production>(172, "organizaciya");

            array<developer> info = new array<developer>("Херунцева Дарья Юрьевна", "разработка", 229);

            //для 7 лабы

            array<int> intArray = new array<int>(5);
            intArray.add(15);
            intArray.add(78);
            intArray.add(36);
            Console.WriteLine("Массив целых чисел:");
            for (int i = 0; i < intArray.arr.Length; i++)
            {
                Console.Write(intArray[i] + " ");
            }
            Console.WriteLine();

            array<double> doubleArray = new array<double>(3);
            doubleArray.add(1.5);
            doubleArray.add(2.5);
            doubleArray.add(3.5);
            Console.WriteLine("Массив вещественных чисел:");
            for (int i = 0; i < doubleArray.arr.Length; i++)
            {
                Console.Write(doubleArray[i] + " ");
            }
            Console.WriteLine();

            PO software1 = new PO("название", "1.0");

            POProcessor<PO> processor = new POProcessor<PO>();

            processor.Process(software1);

            software1.DisplayInfo();





            array<int> myArray = new array<int>();

            myArray.add(1);
            myArray.add(2);
            myArray.add(3);

            string filePath = "";

            myArray.WriteToFile(filePath);


            myArray.ReadFromFile(filePath);

            Console.WriteLine("Элементы массива после чтения из файла:");
            foreach (var item in myArray.arr)
            {
                Console.WriteLine(item);
            }

            

        }

    }

}
