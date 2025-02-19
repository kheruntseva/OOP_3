using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{

    public delegate int newdel(int a, int b);

    class Class1
    {

        public event newdel newevent;

        public int newmethod(int a,int b)
        {
            a++;
            b++;
            int c = a + b;
            return c;
        }
       
        public void cgange(int a, int b)
        {
            newevent += newmethod;
        }

        public void classnewvyzov(int a, int b)
        {
            int result = newevent.Invoke(a, b);
            Console.WriteLine($"сумма: {result}");
        }
       
    }
    
    class newwww
    {
        
    }
}
