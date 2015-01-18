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

        public void Use(Pokemon user, Pokemon receiver)
        {
            receiver.SetHP(receiver.GetHP() - Convert.ToInt32(Damage(user, receiver)));
        }

        private float Damage(Pokemon user, Pokemon receiver)
        {
            float ye = (2.0f * user.GetLevel() + 10.0f) / 250.0f;
            float wahoo = (user.GetAtt() / receiver.GetDef());
            float damn = this.GetPower() * IsStab(user) * IsEffective(receiver);
            return ye * wahoo * damn;
            //return ((2 * user.GetLevel() + 10) / 250) * (user.GetAtt() / receiver.GetDef()) * this.GetPower() * IsStab(user) * IsEffective(receiver);
        }

        private float IsStab(Pokemon pkmn)
        {
            if (pkmn.GetTypePkmn() == this.GetTypePkmn())
            {
                return 1.5f;
            }
            else
            {
                return 1;
            }
        }

        private float IsEffective(Pokemon pkmn)
        {
            if (pkmn.GetTypePkmn() == TypePokemon.Normal)
            {
                return 1;
            }
            else if (pkmn.GetTypePkmn() == TypePokemon.Eau)
            {
                if(this.GetTypePkmn() == TypePokemon.Feu)
                {
                    return 0.5f;
                }
                else if(this.GetTypePkmn() == TypePokemon.Eau)
                {
                    return 0.5f;
                }
                else if(this.GetTypePkmn() == TypePokemon.Herbe)
                {
                    return 2;
                }
                else if(this.GetTypePkmn() == TypePokemon.Normal)
                {
                    return 1;
                }
            }
            else if (pkmn.GetTypePkmn() == TypePokemon.Feu)
            {
                if (this.GetTypePkmn() == TypePokemon.Feu)
                {
                    return 0.5f;
                }
                else if (this.GetTypePkmn() == TypePokemon.Eau)
                {
                    return 2;
                }
                else if (this.GetTypePkmn() == TypePokemon.Herbe)
                {
                    return 0.5f;
                }
                else if (this.GetTypePkmn() == TypePokemon.Normal)
                {
                    return 1;
                }
            }
            else if (pkmn.GetTypePkmn() == TypePokemon.Herbe)
            {
                if (this.GetTypePkmn() == TypePokemon.Feu)
                {
                    return 2;
                }
                else if (this.GetTypePkmn() == TypePokemon.Eau)
                {
                    return 0.5f;
                }
                else if (this.GetTypePkmn() == TypePokemon.Herbe)
                {
                    return 0.5f;
                }
                else if (this.GetTypePkmn() == TypePokemon.Normal)
                {
                    return 1;
                }
            }
            return 1;
        }
    }
}
