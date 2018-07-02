using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observation
{
    public enum CharacterName
    {
        Ryu = 0,
        Ken,
        ChunLi,
        EHonda,
        Blanka,
        Zangief,
        Guile,
        Dhalsim,
        Balrog,
        Sagat,
        Vega,
        MBison,
    };


    class Scene
    {
        private List<Character> _Characters;
        private List<HealthBar> _HealthBars;

        public Scene()
        {
            _Characters = new List<Character>();
            _HealthBars = new List<HealthBar>();

            _Characters.Add(new Character(CharacterName.Ryu, 1, new Fireball(), new SpinAttack()));
            _Characters.Add(new Character(CharacterName.Ken, 2, new Fireball(), new Uppercut()));

            SetOpponents();

            _HealthBars.Add(new HealthBar(_Characters[0]));
            _HealthBars.Add(new HealthBar(_Characters[1]));

        }

        private void SetOpponents()
        {
            for (int i = 0; i < _Characters.Count; i++)
            {
                _Characters[i].SetOpponent(_Characters);
                _Characters[i]._SendWinner += StateWinner;
            }
        }

        private void StateWinner(Character winner)
        {
            Console.WriteLine(" ");
            Console.WriteLine("K.O!");
            Console.WriteLine(winner._ID.ToString() + " Wins!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public void Update()
        {
            for (int i = 0; i < _Characters.Count; i++)
            {
                _Characters[i].Update();                
            }        
        }
    }
}
