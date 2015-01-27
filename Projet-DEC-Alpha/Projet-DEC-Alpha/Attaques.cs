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
        public float Effectiveness { get; set; }

        public Attaque(string nom, int power, int accuracy, TypePokemon type, int pp)
        {
            SetNom(nom);
            SetPower(power);
            SetAccuracy(accuracy);
            SetTypePkmn(type);
            SetPP(pp);
        }

        public string GetNom()
        {
            return Nom;
        }

        public void SetNom(string nom)
        {
            Nom = nom;
        }

        public int GetPower()
        {
            return Power;
        }

        public void SetPower( int power)
        {
            Power = power;
        }

        public int GetAccuracy()
        {
            return Accuracy;
        }

        public void SetAccuracy(int accuracy)
        {
            Accuracy = accuracy;
        }
        public TypePokemon GetTypePkmn()
        {
            return Type;
        }

        public void SetTypePkmn(TypePokemon typepkmn)
        {
            Type = typepkmn;
        }

        public int GetPP()
        {
            return PP;
        }

        public void SetPP(int pp)
        {
            PP = pp;
        }

        public int Use(Pokemon user, Pokemon receiver)
        {
            if(receiver.GetLevel() == 11)
            {
                int dmg2 = 1;
            }
            int dmg = Convert.ToInt32(Damage(user, receiver));
            receiver.SetHP(receiver.GetHP() - dmg);
            return dmg;
        }

        private float Damage(Pokemon user, Pokemon receiver)
        {
            float ye = (2.0f * user.GetLevel() + 10.0f) / 250.0f;
            float a = user.GetAtt();
            float d = receiver.GetDef();
            float wahoo = a / d;
            float damn = this.GetPower() * IsStab(user) * IsEffective(receiver);
            return ye * wahoo * damn;
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
                Effectiveness = 1;
                return Effectiveness;
            }
            else if (pkmn.GetTypePkmn() == TypePokemon.Eau)
            {
                if (this.GetTypePkmn() == TypePokemon.Feu)
                {
                    Effectiveness = 0.5f;
                    return Effectiveness;
                }
                else if (this.GetTypePkmn() == TypePokemon.Eau)
                {
                    Effectiveness = 0.5f;
                    return Effectiveness;
                }
                else if (this.GetTypePkmn() == TypePokemon.Herbe)
                {
                    Effectiveness = 2;
                    return Effectiveness;
                }
                else if (this.GetTypePkmn() == TypePokemon.Normal)
                {
                    Effectiveness = 1;
                    return Effectiveness;
                }
            }
            else if (pkmn.GetTypePkmn() == TypePokemon.Feu)
            {
                if (this.GetTypePkmn() == TypePokemon.Feu)
                {
                    Effectiveness = 0.5f;
                    return Effectiveness;
                }
                else if (this.GetTypePkmn() == TypePokemon.Eau)
                {
                    Effectiveness = 2;
                    return Effectiveness;
                }
                else if (this.GetTypePkmn() == TypePokemon.Herbe)
                {
                    Effectiveness = 0.5f;
                    return Effectiveness;
                }
                else if (this.GetTypePkmn() == TypePokemon.Normal)
                {
                    Effectiveness = 1;
                    return Effectiveness;
                }
            }
            else if (pkmn.GetTypePkmn() == TypePokemon.Herbe)
            {
                if (this.GetTypePkmn() == TypePokemon.Feu)
                {
                    Effectiveness = 2;
                    return Effectiveness;
                }
                else if (this.GetTypePkmn() == TypePokemon.Eau)
                {
                    Effectiveness = 0.5f;
                    return Effectiveness;
                }
                else if (this.GetTypePkmn() == TypePokemon.Herbe)
                {
                    Effectiveness = 0.5f;
                    return Effectiveness;
                }
                else if (this.GetTypePkmn() == TypePokemon.Normal)
                {
                    Effectiveness = 1;
                    return Effectiveness;
                }
            }
            Effectiveness = 1;
            return Effectiveness;
        }
    }
}
