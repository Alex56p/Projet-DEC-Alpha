using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DEC_Alpha
{
    enum TypePokemon
    {
        Eau, Feu, Herbe
    };

    class Pokemon
    {
        private string Nom{get;set;}
        private int Level { get; set;}
        private int Exp { get; set; }
        private int HP { get; set; }

        private int Attack { get; set; }
        private int Defense { get; set; }
        private int Mana { get; set; }
        private TypePokemon Type { get; set; }
        


    }
}
