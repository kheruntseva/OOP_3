using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Reflection;


namespace SerializationExample
{

    public interface ISerializer
    {
        void Serialize<T>(T obj, string filename);
        T Deserialize<T>(string filename);
    }


    public class TextProcessor : PO, vuzov
    {
        // Запрещаем сериализацию поля
        [NonSerialized]
        [XmlIgnore]
        private string DEVELOPER;

        public TextProcessor(string _name, string _version, string _developer) : base(_name, _version)
        {
            DEVELOPER = _developer;
        }

        public override void vuzvat()
        {
            Console.WriteLine("Абстрактный метод из базового класса вызван в классе TextProcessor");
        }

        public override string ToString()
        {
            return $"имя: {NAME}, версия: {VERSION}, разработчик: {DEVELOPER}";
        }

        public override void Display()
        {
            Console.WriteLine("Вызов виртуального метода из производного класса");
        }
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


    public interface vuzov
    {
        void vuzvat();
    }

  
    public class BinarySerializer : ISerializer
    {
        public void Serialize<T>(T obj, string filename)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, obj);
            }
        }

        public T Deserialize<T>(string filename)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                return (T)formatter.Deserialize(stream);
            }
        }
    }


    public class SoapSerializer : ISerializer
    {
        public void Serialize<T>(T obj, string filename)
        {
            IFormatter formatter = new SoapFormatter();
            using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, obj);
            }
        }

        public T Deserialize<T>(string filename)
        {
            IFormatter formatter = new SoapFormatter();
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                return (T)formatter.Deserialize(stream);
            }
        }
    }


    public class JsonSerializer : ISerializer
    {
        public void Serialize<T>(T obj, string filename)
        {
         
            JsonSerializer jsonSerializer = new JsonSerializer();

            var json = $"{{{string.Join(",", typeof(T).GetProperties().Select(p => $"\"{p.Name}\":\"{p.GetValue(obj)}\""))}}}";
            File.WriteAllText(filename, json);
        }

        public T Deserialize<T>(string filename)
        {
        
            JsonSerializer jsonSerializer = new JsonSerializer();

     
            var json = File.ReadAllText(filename)
                           .Trim('{', '}')
                           .Split(',');

            var obj = Activator.CreateInstance<T>();
            foreach (var pair in json)
            {
                var keyValue = pair.Split(':');
                var propertyName = keyValue[0].Trim('"');
                var propertyValue = keyValue[1].Trim('"');

                var property = typeof(T).GetProperty(propertyName);
                if (property != null)
                {
                    var convertedValue = Convert.ChangeType(propertyValue, property.PropertyType);
                    property.SetValue(obj, convertedValue);
                }
            }

            return obj;
        }
    }



    public class XmlSerializer : ISerializer
    {
        public void Serialize<T>(T obj, string filename)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public T Deserialize<T>(string filename)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (TextReader reader = new StreamReader(filename))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
          
            TextProcessor[] processors = new TextProcessor[]
            {
                new TextProcessor("TextProcessor1", "1.0", "Developer1"),
                new TextProcessor("TextProcessor2", "2.0", "Developer2")
            };

         
            ISerializer binarySerializer = new BinarySerializer();
            ISerializer soapSerializer = new SoapSerializer();
            ISerializer jsonSerializer = new JsonSerializer();
            ISerializer xmlSerializer = new XmlSerializer();

            // Сериализация в бинарный формат
            binarySerializer.Serialize(processors, "processors.bin");
            var binaryDeserialized = binarySerializer.Deserialize<TextProcessor[]>("processors.bin");

            // Сериализация в SOAP формат
            soapSerializer.Serialize(processors, "processors.soap");
            var soapDeserialized = soapSerializer.Deserialize<TextProcessor[]>("processors.soap");

            // Сериализация в JSON формат
            jsonSerializer.Serialize(processors, "processors.json");
            var jsonDeserialized = jsonSerializer.Deserialize<TextProcessor[]>("processors.json");

            // Сериализация в XML формат
            xmlSerializer.Serialize(processors, "processors.xml");
            var xmlDeserialized = xmlSerializer.Deserialize<TextProcessor[]>("processors.xml");

      
            Console.WriteLine("Десериализация из файлов:");
            foreach (var processor in binaryDeserialized)
                Console.WriteLine(processor);
        }
    }
}
