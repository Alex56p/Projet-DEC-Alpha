using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DEC_Alpha
{
    class Combat
    {
        Pokemon Player { get; set; }
        Pokemon Enemy { get; set; }

        public Combat(Pokemon player, Pokemon enemy)
        {
            Player = player;
            Enemy = enemy;
        }
    }
}
