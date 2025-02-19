using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
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
            Console.WriteLine($"имя ПО: {NAME}, версия: {VERSION}");
        }
        public void UpdateVersion(string newVersion)
        {
            VERSION = newVersion;
            Console.WriteLine($"версия обновлена до: {VERSION}");
        }
    }


}
