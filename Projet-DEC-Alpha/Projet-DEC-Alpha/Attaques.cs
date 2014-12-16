using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DEC_Alpha
{
    class Attaque
    {
        private string Nom { get; set; }
        private int Power{get;set;}
        private int Accuracy { get; set; }
        private TypePokemon Type { get; set; }
        private int PP { get; set; }

        public Attaque(string nom, int power, int accuracy, TypePokemon type, int pp)
        {
            Nom = nom;
            Power = power;
            Accuracy = accuracy;
            Type = type;
            PP = pp;
        }

        public string GetNom()
        {
            return Nom;
        }
        public int GetPower()
        {
            return Power;
        }
        public int GetAccuracy()
        {
            return Accuracy;
        }
        public TypePokemon GetTypePkmn()
        {
            return Type;
        }
        public int GetPP()
        {
            return PP;
        }
    }
}
