using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton.GetInstance.DoeIets();
            Console.ReadKey();

        }
    }

    public class Singleton
    {
        private static Singleton _Instance;

        private Singleton() { }

        public static Singleton GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Singleton();
                }
                return _Instance;
            }
        }

        public void DoeIets()
        {
            Console.WriteLine("Ik doe Iets");
        }
    }
}
