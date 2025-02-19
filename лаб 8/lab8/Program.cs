using System;
using System.Collections.Generic;


namespace lab8
{
    public delegate void moving(int x, int y);
    public delegate void changing(double factor);


    public class User
    {
        public event moving move;
        public event changing change;

        public string Name { get; set; }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public double size { get; set; } = 1.0;

        public User(string name) => Name = name;

        public void tomove(int x, int y)
        {
            move?.Invoke(x, y);
        }

        public void tochange(double factor)
        {
            change?.Invoke(factor);
        }

        public void SubscribeToEvents()
        {
            move += (x, y) =>
            {
                X += x;
                Y += y;
                Console.WriteLine($"элемент [{Name}] Перемещён на расстояние X={X}, Y={Y}");
            };

            change += (factor) =>
            {
                size *= factor;
                Console.WriteLine($"Размер элемента [{Name}] изменён на {size:F2}");
            };
        }
    }

      class Program
    {

        public static Action<string> RemovePunctuation = input =>
        {
            char[] punctuation = { '.', ',', '!', '?', ';', ':' };
            foreach (var p in punctuation)
            {
                input = input.Replace(p.ToString(), "");
            }
            Console.WriteLine($"После удаления знаков препинания: {input}");
        };

        public static Func<string, string> AddExclamation = input =>
        {
            var result = input + "!";
            Console.WriteLine($"После добавления восклицательного знака: {result}");
            return result;
        };

        public static Func<string, string> ToUpperCase = input =>
        {
            var result = input.ToUpper();
            Console.WriteLine($"После преобразования в верхний регистр: {result}");
            return result;
        };

        public static Func<string, string> RemoveExtraSpaces = input =>
        {
            var result = string.Join(" ", input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine($"После удаления лишних пробелов: {result}");
            return result;
        };

        public static Predicate<string> ReplaceAWithO = input =>
        {
            if (input.Contains('a'))
            {
                var result = input.Replace('a', 'o');
                Console.WriteLine($"После замены 'a' на 'o': {result}");
                return true;
            }
            Console.WriteLine($"Замена не требуется: {input}");
            return false;
        };



        static void Main(string[] args)
        {
        var user1 = new User("User1");
        var user2 = new User("User2");
        var user3 = new User("User3");
        var user4 = new User("User4");

            user1.SubscribeToEvents();
            user2.SubscribeToEvents();
            user3.SubscribeToEvents();
            user4.SubscribeToEvents();

            Console.WriteLine("\nВызов события Move");
            user1.tomove(5, -3);
            user2.tomove(3, 2);
            user3.tomove(2, 2);
            user4.tomove(1, 1);

            Console.WriteLine("\nВызов события Compress");
            user1.tochange(0.5);
            user2.tochange(0.8);
            user3.tochange(0.7);
            user4.tochange(0.9);

  
            Console.WriteLine("\nСостояния объектов после событий:");
            var users = new List<User> { user1, user2, user3, user4 };
            foreach (var user in users)
            {
                Console.WriteLine($"[{user.Name}] Позиция: X={user.X}, Y={user.Y}, Размер: {user.size:F2}");
            }

            string inputString = "  какой-то текст для проверки работы функций ";

            RemovePunctuation(inputString);                
            string result1 = AddExclamation(inputString);    
            string result2 = ToUpperCase(result1);          
            string result3 = RemoveExtraSpaces(result2);     
            bool replaced = ReplaceAWithO(result3);         

            Console.WriteLine($"\nИтоговая строка после обработки: {result3}");
            Class1 newchto = new Class1();
            newchto.cgange(5, 6);
            newchto.newmethod(1, 3);
            newchto.classnewvyzov(5, 4);
        }


}



}
