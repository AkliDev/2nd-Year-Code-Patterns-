using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observation
{
    class HealthBar
    {
        private int _HitPoints;
        private Character _Player;

        public HealthBar(Character player)
        {
            _Player = player;
            _HitPoints = _Player._HitPoints;
            _Player._GotHit += ChangeHealth;
        }

        public void ChangeHealth(int hitponts)
        {
            _HitPoints = hitponts;
            Console.WriteLine(_Player._ID.ToString() + ": HitPoints : " + _HitPoints);
            Console.WriteLine(" ");
        }
    }
}
