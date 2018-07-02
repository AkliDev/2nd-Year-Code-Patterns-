using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{
    class QuackSound : ISoundAble
    {
        public void MakeSound()
        {
            Console.WriteLine("Quack");
        }
    }

    class PeepSound : ISoundAble
    {   
        public void MakeSound()
        {
            Console.WriteLine("Peep");
        }
    }

    class Swim : ISwimAbla
    { 
        public void GoSwim()
        {
            Console.WriteLine("Swim");
        }
    }
    class Fly : IFlyAble
    {
        public void GoFly()
        {
            Console.WriteLine("Fly");
        }
    }
}
