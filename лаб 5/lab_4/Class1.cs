using System;
using System.Collections.Generic;
using System.Text;

namespace lab_4
{
    public partial class TextProcessor
 {
       public override void Display()
    {
        Console.WriteLine("Вызов виртуального метода из производного класса");
    }

      public override string ToString()
    {
        return $"имя: {NAME}, версия: {VERSION}, разработчик: {DEVELOPER}";
    }
 }

}
