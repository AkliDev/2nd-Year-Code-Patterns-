using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Eend> _Eenden = new List<Eend>();
            _Eenden.Add(new Eend("Eend", new QuackSound(), new Fly(), new Swim()));
            _Eenden.Add(new Eend("Baby Eend", new PeepSound(), null, new Swim()));


            for (int i = 0; i < _Eenden.Count; i++)
            {
                _Eenden[i].Test();
            }

            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
