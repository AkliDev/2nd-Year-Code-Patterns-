using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observation
{
    interface IState
    {
        void Enter();
        void Update();
        void Exit();
    }

    interface IAttack
    {
        void Attack(string id, CharacterName name, Character opponent);
    }

    interface IHitable
    {
        void GetHit(string id, CharacterName name);
    }



}
