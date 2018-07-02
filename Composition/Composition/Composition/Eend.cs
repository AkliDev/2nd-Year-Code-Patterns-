using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{
    class Eend
    {
        private ISoundAble _Sound;
        private IFlyAble _Fly;
        private ISwimAbla _Swim;
        private string _ID;

        public Eend(string id,ISoundAble sound, IFlyAble fly, ISwimAbla swim)
        {
            _Sound = sound;
            _Fly = fly;
            _Swim = swim;
            _ID = id;
   
        }


        public void Test()
        {
            Console.WriteLine(_ID + ":");
            MakeSound();
            Fly();
            Swim();
            Console.WriteLine(" ");
        }
        public void MakeSound()
        {
            if (_Sound != null)
            {
                _Sound.MakeSound();
            }
        }

        public void Fly()
        {
            if (_Fly != null)
            {
                _Fly.GoFly();
            }
        }

        public void Swim()
        {
            if (_Swim != null)
            {
                _Swim.GoSwim();
            }
        }




    }
}
