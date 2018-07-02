using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observation
{
    delegate void GotHit(int hitpoints);
    delegate void SendWinner(Character winner);

    class Character
    {
        public CharacterName _ID;

        public int _Player;
        public int _HitPoints;
        private Character _Opponent;

        private IAttack _Attack1;
        private IAttack _Attack2;
        private IHitable _Hit;

        private ConsoleKey _Input;

        public event GotHit _GotHit;
        public event SendWinner _SendWinner;

        public Character(CharacterName id, int player, IAttack attack1, IAttack attack2)
        {
            _ID = id;
            _Player = player;
            _Attack1 = attack1;
            _Attack2 = attack2;
            _Hit = new Hit();

            switch (_ID)
            {
                case CharacterName.Ryu:
                    _HitPoints = 1000;
                    break;
                case CharacterName.Ken:
                    _HitPoints = 1000;
                    break;
                case CharacterName.ChunLi:
                    _HitPoints = 900;
                    break;
                case CharacterName.EHonda:
                    _HitPoints = 1050;
                    break;
                case CharacterName.Blanka:
                    _HitPoints = 1000;
                    break;
                case CharacterName.Zangief:
                    _HitPoints = 1100;
                    break;
                case CharacterName.Guile:
                    _HitPoints = 1000;
                    break;
                case CharacterName.Dhalsim:
                    _HitPoints = 900;
                    break;
                case CharacterName.Balrog:
                    _HitPoints = 1050;
                    break;
                case CharacterName.Sagat:
                    _HitPoints = 1050;
                    break;
                case CharacterName.Vega:
                    _HitPoints = 1000;
                    break;
                case CharacterName.MBison:
                    _HitPoints = 1000;
                    break;
            }

            _HitPoints = _HitPoints * 2;
        }

        public void Update()
        {
            Input();
        }

        public void SetOpponent(List<Character> characters)
        {
            switch (_Player)
            {
                case 1:
                    _Opponent = characters[1];
                    break;
                case 2:
                    _Opponent = characters[0];
                    break;
            }
        }
        public void Input()

        {
            if (_HitPoints > 0 && _Opponent._HitPoints > 0)
            {
                _Input = Console.ReadKey().Key;
                switch (_Player)
                {
                    case 1:
                        if (_Input == ConsoleKey.F1)
                        {
                            Attack(_Attack1);
                        }
                        if (_Input == ConsoleKey.F2)
                        {
                            Attack(_Attack2);
                        }
                        break;
                    case 2:
                        if (_Input == ConsoleKey.F7)
                        {
                            Attack(_Attack1);
                        }
                        if (_Input == ConsoleKey.F8)
                        {
                            Attack(_Attack2);
                        }
                        break;
                }
            }
        }


        public void Attack(IAttack attack)
        {
            if (attack != null)
            {
                attack.Attack(_ID.ToString(), _ID, _Opponent);
            }
        }


        public void Gethit(int demage)
        {
            if (_Hit != null)
            {
                if (demage > 0)
                {
                    _Hit.GetHit(_ID.ToString(), _ID);
                    _HitPoints -= demage;
                    if (_HitPoints < 0)
                    {
                        _HitPoints = 0;
                    }


                }

                if (_GotHit != null)
                {
                    _GotHit(_HitPoints);
                }

            }
            if (_HitPoints <= 0)
            {
                if (_SendWinner != null)
                {
                    _SendWinner(_Opponent);
                }
            }
        }
    }
}
