using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observation
{
    #region Attacks

    class Fireball : IAttack
    {


        public void Attack(string id, CharacterName name, Character opponent)
        {
            int demage = 0;
            switch (name)
            {
                case CharacterName.Ryu:
                    Console.WriteLine(id + ": Hadouken!");
                     demage = 450;
                    break;
                case CharacterName.Ken:
                    Console.WriteLine(id + ": Hadouken!");
                    demage = 450;
                    break;
                case CharacterName.ChunLi:
                    Console.WriteLine(id + ": Kikoken!");
                    demage = 450;
                    break;
                case CharacterName.Guile:
                    Console.WriteLine(id + ": Sonic Boom!");
                    demage = 450;
                    break;
                case CharacterName.Dhalsim:
                    Console.WriteLine(id + ": Yoga Fire!");
                    demage = 480;
                    break;
                case CharacterName.Sagat:
                    Console.WriteLine(id + ": Taiger!");
                    demage = 530;
                    break;
                case CharacterName.MBison:
                    Console.WriteLine(id + ": Psyco Cannon!");
                    demage = 560;
                    break;
                default:
                    Console.WriteLine(id + ": I can not perfrom this technique.");
                    break;
            }
            opponent.Gethit(demage);
        }

    }

    class SpinAttack : IAttack
    {
        public void Attack(string id, CharacterName name, Character opponent)
        {
            int demage = 0;
            switch (name)
            {
                case CharacterName.Ryu:
                    Console.WriteLine(id + ": Tatsumaki Senpukyaku!");
                    demage = 360;
                    break;
                case CharacterName.Ken:
                    Console.WriteLine(id + ": Tatsumaki Senpukyaku!");
                    demage = 360;
                    break;
                case CharacterName.ChunLi:
                    Console.WriteLine(id + ": SpinningBirdKick!");
                    demage = 480;
                    break;
                case CharacterName.Zangief:
                    Console.WriteLine(id + ": Orhyeah!");
                    demage = 430;
                    break;
                default:
                    Console.WriteLine(id + ": I can not perfrom this technique.");
                    break;
            }
            opponent.Gethit(demage);
        }

    }

    class Uppercut : IAttack
    {
        public void Attack(string id, CharacterName name, Character opponent)
        {
            int demage = 0;
            switch (name)
            {
                case CharacterName.Ryu:
                    Console.WriteLine(id + ": Shoryuken!");
                    demage = 580;
                    break;
                case CharacterName.Ken:
                    Console.WriteLine(id + ": Shoryuken!");
                    demage = 580;
                    break;
                case CharacterName.ChunLi:
                    Console.WriteLine(id + ": Tenshokyaku!");
                    demage = 550;
                    break;
                case CharacterName.Guile:
                    Console.WriteLine(id + ": Somersault Kick!");
                    demage = 530;
                    break;
                case CharacterName.Balrog:
                    Console.WriteLine(id + ": Oh Wahg!");
                    demage = 530;
                    break;
                case CharacterName.Sagat:
                    Console.WriteLine(id + ": Taiger Uppercut!");
                    demage = 640;
                    break;
                case CharacterName.Vega:
                    Console.WriteLine(id + ": Piew!");
                    demage = 640;
                    break;
                default:
                    Console.WriteLine(id + ": I can not perfrom this technique.");
                    break;
            }
            opponent.Gethit(demage);
        }

    }


    class LaunchAttack : IAttack
    {
        public void Attack(string id, CharacterName name, Character opponent)
        {
            int demage = 0;
            switch (name)
            {
                case CharacterName.EHonda:
                    Console.WriteLine(id + ": Thut Hai!");
                    demage = 480;
                    break;
                case CharacterName.Blanka:
                    Console.WriteLine(id + ": WRAR!");
                    demage = 450;
                    break;
                case CharacterName.Balrog:
                    Console.WriteLine(id + ": Oh Wahg!");
                    demage = 530;
                    break;
                case CharacterName.Sagat:
                    Console.WriteLine(id + ": Taiger Knee!");
                    demage = 550;
                    break;
                case CharacterName.Vega:
                    Console.WriteLine(id + ": Piew Woo!");
                    demage = 580;
                    break;
                case CharacterName.MBison:
                    Console.WriteLine(id + ": Psycho Crusher!");
                    demage = 640;
                    break;
                default:
                    Console.WriteLine(id + ": I can not perfrom this technique.");
                    break;
            }
            opponent.Gethit(demage);
        }

    }







    class RapidHits : IAttack
    {
        public void Attack(string id, CharacterName name, Character opponent)
        {
            int demage = 0;
            switch (name)
            {
                case CharacterName.ChunLi:
                    Console.WriteLine(id + ": Hyakuretsukyaku!");
                    demage = 480;
                    break;
                case CharacterName.EHonda:
                    Console.WriteLine(id + ": Hu-HA-Hu-HA-Hu!");
                    demage = 450;
                    break;
                default:
                    Console.WriteLine(id + ": I can not perfrom this technique.");
                    break;

            }
            opponent.Gethit(demage);
        }

    }



    class ElectricThunder : IAttack
    {
        public void Attack(string id, CharacterName name, Character opponent)
        {
            int demage = 0;
            switch (name)
            {

                case CharacterName.Blanka:
                    Console.WriteLine(id + ": ZAP!");
                    demage = 580;
                    break;
                default:
                    Console.WriteLine(id + ": I can not perfrom this technique.");
                    break;
            }
            opponent.Gethit(demage);
        }

    }



    class YogaFlame : IAttack
    {
        public void Attack(string id, CharacterName name, Character opponent)
        {
            int demage = 0;
            switch (name)
            {

                case CharacterName.Dhalsim:
                    Console.WriteLine(id + ": Yoga Flame!");
                    demage = 530;
                    break;
                default:
                    Console.WriteLine(id + ": I can not perfrom this technique.");
                    break;

            }

            opponent.Gethit(demage);

        }

    }

    #endregion 

    class Hit : IHitable
    {

        public void GetHit(string id, CharacterName name)
        {
            Console.WriteLine(id + ": Ouah!");


        }
    }
}
