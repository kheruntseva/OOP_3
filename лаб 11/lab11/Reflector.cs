using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace lab11
{
    public static class Reflector
    {
        public static void GetTypeInfo(Type type, string paramType = null)
        {
            const string fileName = "TypeInfo.txt";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
           
                var assemblyName = type.Assembly.GetName().Name;
                writer.WriteLine($"Сборка: {assemblyName}");
                Console.WriteLine($"Сборка: {assemblyName}");

             
                var constructors = type.GetConstructors();
                writer.WriteLine($"Публичные конструкторы: {constructors.Length > 0}");
                Console.WriteLine($"Публичные конструкторы: {constructors.Length > 0}");

              
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                writer.WriteLine("Публичные методы:");
                Console.WriteLine("Публичные методы:");
                foreach (var method in methods)
                {
                    writer.WriteLine(method.Name);
                    Console.WriteLine(method.Name);
                }

            
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                writer.WriteLine("Публичные поля:");
                Console.WriteLine("Публичные поля:");
                foreach (var field in fields)
                {
                    writer.WriteLine(field.Name);
                    Console.WriteLine(field.Name);
                }

              
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                writer.WriteLine("Публичные свойства:");
                Console.WriteLine("Публичные свойства:");
                foreach (var property in properties)
                {
                    writer.WriteLine(property.Name);
                    Console.WriteLine(property.Name);
                }

            
                var interfaces = type.GetInterfaces();
                writer.WriteLine("Реализованные интерфейсы:");
                Console.WriteLine("Реализованные интерфейсы:");
                foreach (var iface in interfaces)
                {
                    writer.WriteLine(iface.Name);
                    Console.WriteLine(iface.Name);
                }

           
                if (!string.IsNullOrEmpty(paramType))
                {
                    var parameterType = Type.GetType(paramType);
                    if (parameterType != null)
                    {
                        var matchingMethods = methods.Where(m => m.GetParameters().Any(p => p.ParameterType == parameterType));
                        writer.WriteLine($"Методы, содержащие параметр типа {paramType}:");
                        Console.WriteLine($"Методы, содержащие параметр типа {paramType}:");
                        foreach (var method in matchingMethods)
                        {
                            writer.WriteLine(method.Name);
                            Console.WriteLine(method.Name);
                        }
                    }
                    else
                    {
                        writer.WriteLine($"Тип {paramType} не найден.");
                        Console.WriteLine($"Тип {paramType} не найден.");
                    }
                }
            }

            Console.WriteLine($"Информация записана в файл: {fileName}");
            InvokeMethodFromFile(type);
        }

        private static object GenerateParameterValue(Type parameterType)
        {
            if (parameterType == typeof(int))
            {
                return new Random().Next(1, 100); 
            }
            if (parameterType == typeof(string))
            {
                return "Test String";
            }
            if (parameterType == typeof(bool))
            {
                return true; 
            }
            if (parameterType == typeof(double))
            {
                return 42.42;
            }
        

            throw new ArgumentException($"Неизвестный тип: {parameterType}");
        }



        private static void InvokeMethodFromFile(Type type)
        {
            Console.WriteLine("Введите имя текстового файла для параметров вызова метода:");
            var fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length >= 1)
                {
                    var methodName = parts[0];
                    var parameters = parts.Skip(1).ToArray();
                    var methodInfo = type.GetMethod(methodName);

                    if (methodInfo != null)
                    {
                        try
                        {
                            var instance = Activator.CreateInstance(type);
                            var methodParameters = methodInfo.GetParameters();
                            var convertedParams = methodParameters.Select((p, i) =>
                                Convert.ChangeType(parameters[i], p.ParameterType)).ToArray();

                            methodInfo.Invoke(instance, convertedParams);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка при вызове метода {methodName}: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Метод {methodName} не найден.");
                    }
                }
            }
        }

        public static T Create<T>()
        {
            Type type = typeof(T);

            var constructor = type.GetConstructors().FirstOrDefault();

            if (constructor == null)
            {
                throw new InvalidOperationException($"Конструктор для типа {type.Name} не найден.");
            }
            return (T)constructor.Invoke(null);
        }

    }
}
