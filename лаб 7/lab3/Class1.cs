using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class Class1<T>
    {
        string NAME;
        public Class1(string name)
        {
            name = NAME;
        }

        T razmer;
        T number;
        T _length;

        static void Main(string[] args)
        {
            Class1<T> newclass = new Class1<T>("smth");
            Class1<T> newclass1 = new Class1<T>("smth1");
            Class1<T> newclass2 = new Class1<T>("smth2");

        }

    }
  

}
   
