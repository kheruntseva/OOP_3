using System;
using System.Drawing;
using System.Reflection;
using System.IO;

namespace lab11
{
	public class Program
	{

		static void Main()
		{
			try
			{
				Type myType = typeof(lab11.PO);
				Type myType2 = typeof(lab11.Car);
				Console.WriteLine($"Информация о классе записана в файл");
				Reflector.GetTypeInfo(myType, "System.Int32");

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
				Console.WriteLine($"Место: {ex.StackTrace}");
			}

			string fileName = "toread.txt";

			Console.WriteLine($"Текущая рабочая директория: {Directory.GetCurrentDirectory()}");

			if (File.Exists(fileName))
			{
				Console.WriteLine($"Файл найден: {fileName}");
				string content = File.ReadAllText(fileName);
				Console.WriteLine("Содержимое файла:");
				Console.WriteLine(content);
			}
			else
			{
				Console.WriteLine($"Файл {fileName} не найден.");
			}

		}
	}
}