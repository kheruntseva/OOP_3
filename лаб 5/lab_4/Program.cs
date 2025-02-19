using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_4
{

    public enum SoftwareType
    {
        TextProcessor,
        Game,
        Virus,
        Utility
    }

    public struct DeveloperInfo
    {
        public string Name;
        public string Country;
        public DeveloperInfo(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }

    public class Controller
    {

        public Computer computer;
    public Controller()
        {
            computer = new Computer();
        }

        public void InstallSoftware(PO software)
        {
            computer.AddSoftware(software);
            Console.WriteLine($"Установлено ПО: {software.NAME}");
        }

        public PO FindGame(string name)
        {
            foreach (PO software in computer.SoftwareList)
            {
                if (software is Game game)
                {
                    if (game.NAME.Equals(name))
                    {
                        return game;
                    }
                }
            }
            return null;
        }

        public PO FindTextProcessor(string version)
        {
            foreach(PO software in computer.SoftwareList)
            {
                if (software is TextProcessor textProcessor)
                {
                    if(textProcessor.VERSION.Equals(version))
                    {
                        return textProcessor;
                    }
                }
            }
            return null;
        }

        public void alfavit()
        {
            var sortedSoftware = computer.SoftwareList.OrderBy(software => software.NAME).ToList();
            Console.WriteLine("Список ПО в алфавитном порядке:");
            foreach (var software in sortedSoftware)
            {
                Console.WriteLine(software.ToString());
            }
        }

    }


    public class Computer
    {
        public List<PO> SoftwareList { get; set; } = new List<PO>();

        public void AddSoftware (PO software)
        {
            SoftwareList.Add(software);
        }
        public void RemoveSoftware (PO software)
        {
            SoftwareList.Remove(software);
        }

        public void PrintSoftwareList()
        {
            Console.WriteLine("Список установленного ПО:");
            foreach (var software in SoftwareList)
            {
                Console.WriteLine(software.ToString());
            }
        }

    }

    public class Printer
    {
        public void IAmPrinting(PO someObj)
        {
            if (someObj != null)
            {
                Console.WriteLine(someObj.ToString());
            }
        }
    }

    public interface vuzov
    {
        void vuzvat();
    }

    public abstract class PO
    {
        public string NAME;
        public string VERSION;

        public PO(string _name, string _version)
        {
            NAME = _name;
            VERSION = _version;
        }

        public override string ToString()
        {
            return $"имя ПО: {NAME}, версия ПО: {VERSION} ";
        }

        public override bool Equals(object obj)
        {
            if (obj is PO other)
            {
                return NAME == other.NAME && VERSION == other.VERSION;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return NAME.GetHashCode() ^ VERSION.GetHashCode();
        }

        public virtual void Display()
        {
            Console.WriteLine("Вызов виртуального метода из базового класса");
        }

        public abstract void vuzvat();
    }

    public partial class TextProcessor : PO, vuzov
    {
         void vuzov.vuzvat()
        {
            Console.WriteLine("Метод из интерфейса вызван в классе TextProcessor");
        }

        public override void vuzvat()
        {
            Console.WriteLine("Абстрактный метод из базового класса вызван в классе TextProcessor");
        }

        string DEVELOPER;
        public TextProcessor(string _name, string _version, string _developer) : base(_name, _version)
        {
            DEVELOPER = _developer;
        }

    }

    public class Word : TextProcessor
    {
        string LANGUAGE;

        public Word(string _name, string _version, string _developer, string _language)
            : base(_name, _version, _developer)
        {
            LANGUAGE = _language;
        }

        public override string ToString()
        {
            return $"имя: {NAME}, версия: {VERSION}, язык: {LANGUAGE}";
        }
    }

    public abstract class Game : PO
    {
        int PING;

        public Game(string _name, string _version, int _ping) : base(_name, _version)
        {
            PING = _ping;
        }

        public override string ToString()
        {
            return $"имя: {NAME}, версия: {VERSION}, пинг: {PING}";
        }
    }

    public class Saper : Game, vuzov
    {
        void vuzov.vuzvat()
        {
            Console.WriteLine("Метод интерфейса vuzov вызван в классе Saper");
        }

        int ID;

        public Saper(string _name, string _version, int _ping, int _id) : base(_name, _version, _ping)
        {
            ID = _id;
        }

        public override void vuzvat()
        {
            Console.WriteLine("Абстрактный метод вызван в классе Saper");
        }

        public override string ToString()
        {
            return $"имя: {NAME}, версия: {VERSION}, айди: {ID}";
        }
    }

    public class Virus : PO
    {
        public override void vuzvat()
        {
            Console.WriteLine("Абстрактный метод из базового класса вызван в классе Virus");
        }

        string TYPE;
        public Virus(string _name, string _version, string _type) : base(_name, _version)
        {
            TYPE = _type;
        }

        public override string ToString()
        {
            return $"имя: {NAME}, версия: {VERSION}, тип: {TYPE}";
        }
    }

    public class CConficker : Virus
    {
        string PLACE;

        public CConficker(string _name, string _version, string _type, string _place) : base(_name, _version, _type)
        {
            PLACE = _place;
        }

        public override string ToString()
        {
            return $"имя: {NAME}, версия: {VERSION}, место: {PLACE}";
        }
    }

    public class Operations : PO
    {
        public override void vuzvat()
        {
            Console.WriteLine("Абстрактный метод из базового класса вызван в классе Operations");
        }

        string TYPE;

        public Operations(string _name, string _version, string _type) : base(_name, _version)
        {
            TYPE = _type;
        }

        public override string ToString()
        {
            return $"имя: {NAME}, версия: {VERSION}, тип: {TYPE}";
        }
    }

    public sealed class Developer : Operations
    {
        int NUMBER;

        public Developer(string _name, string _version, string _type, int _number) : base(_name, _version, _type)
        {
            NUMBER = _number;
        }

        public override string ToString()
        {
            return $"имя: {NAME}, версия: {VERSION}, число: {NUMBER}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PO textProcessor = new TextProcessor("TextPro", "1.0", "Dev1");
            PO word = new Word("Word", "1.0", "Dev1", "English");
            Game saper = new Saper("Saper", "1.0", 50, 1);
            Virus virus = new Virus("Virus", "1.0", "Trojan");
            Virus cConficker = new CConficker("CConficker", "1.0", "Worm", "Global");
            Operations developer = new Developer("Developer", "1.0", "Utility", 123);

            PO[] programs = { textProcessor, word, virus, cConficker, developer };
            Game[] games = { saper };

            PO[] objects = new PO[] { word, saper, virus, developer };

            Printer printer = new Printer();

            foreach (PO obj in objects)
            {
                printer.IAmPrinting(obj);
            }

            foreach (var game in games)
            {
                if (game is vuzov vuz)
                {
                    vuz.vuzvat();
                }
            }

            textProcessor.vuzvat();
            ((vuzov)textProcessor).vuzvat();

            TextProcessor textProc = word as TextProcessor;
            if (textProc != null)
            {
                textProc.Display();
            }

            Computer computer = new Computer();

            Controller controller = new Controller();
            controller.computer = computer;

            controller.InstallSoftware(new TextProcessor("TextPro", "1.0", "Dev1"));
            controller.InstallSoftware(new Word("Word", "1.0", "Dev1", "English"));
            controller.InstallSoftware(new Saper("Saper", "1.0", 50, 1));
            controller.InstallSoftware(new Virus("Virus", "1.0", "Trojan"));
            controller.InstallSoftware(new CConficker("CConficker", "1.0", "Worm", "Global"));
            controller.InstallSoftware(new Developer("Developer", "1.0", "Utility", 123));

            controller.alfavit();

            PO mygame = controller.FindGame("saper");

            if (mygame != null)
            {
                Console.WriteLine("игра найдена:");
                Console.WriteLine(mygame.ToString());
            }
            else
            {
                Console.WriteLine("Игра не найдена.");
            }

            PO mytextprocessor = controller.FindTextProcessor("1.0");

            if (mytextprocessor != null)
            {
                Console.WriteLine("текстовый редактор:");
                Console.WriteLine(mytextprocessor.ToString());
            }
            else
            {
                Console.WriteLine("текстовый редактор не найден.");
            }


        }
    }
}
