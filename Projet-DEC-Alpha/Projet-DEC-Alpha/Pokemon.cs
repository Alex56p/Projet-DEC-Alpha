using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Projet_DEC_Alpha
{
    enum TypePokemon
    {
        Eau, Feu, Herbe, Normal
    };

    class Pokemon
    {
        private string Nom;
        private int Level { get; set;}
        private int Exp { get; set; }

        private int BaseHP { get; set; }
        private int BaseAttack { get; set; }
        private int BaseDefense { get; set; }
        private int BaseSpeed { get; set; }
        private int BaseMana { get; set; }

        private int HP { get; set; }
        private int Attack { get; set; }
        private int Defense { get; set; }
        private int Speed { get; set; }
        private int Mana { get; set; }
        private TypePokemon Type { get; set; }
        private Image Sprite;
        private List<Attaque> Moves { get; set; }

        public Pokemon(string nom, int level, int hp, int att, int def, int speed, TypePokemon type, Image img, List<Attaque> moves)
        {
            SetNom(nom);
            SetBaseMana(10);
            SetBaseHP(hp);
            SetBaseAtt(att);
            SetBaseDef(def);
            SetBaseSpeed(speed);

            SetLevel(level);
            SetExp(0);
            SetMana(10);
            SetHP(hp);
            SetAtt(att);
            SetDef(def);
            SetSpeed(speed);
            SetTypePkmn(type);
            SetImage(img);
            SetMoves(moves);
        }

        public string GetNom()
        {
            return Nom;
        }

        public void SetNom(string nom)
        {
            Nom = nom;
        }

        public int GetLevel()
        {
            return Level;
        }

        public void SetLevel(int lvl)
        {
            Level = lvl;
        }

        public int GetExp()
        {
            return Exp;
        }

        public void SetExp(int exp)
        {
            Exp = exp;
        }

        public int GetBaseHP()
        {
            return BaseHP;
        }

        public void SetBaseHP(int hp)
        {
            BaseHP = hp;
        }

        public int GetBaseAtt()
        {
            return BaseAttack;
        }

        public void SetBaseAtt(int att)
        {
            BaseAttack = att;
        }

        public int GetBaseDef()
        {
            return BaseDefense;
        }

        public void SetBaseDef(int def)
        {
            BaseDefense = def;
        }

        public int GetBaseSpeed()
        {
            return BaseSpeed;
        }

        public void SetBaseSpeed(int spd)
        {
            BaseSpeed = spd;
        }
        public int GetBaseMana()
        {
            return BaseMana;
        }

        public void SetBaseMana(int mana)
        {
            BaseMana = mana;
        }

        public int GetHP()
        {
            return HP;
        }

        public void SetHP(int hp)
        {
            HP = hp;
        }

        public int GetAtt()
        {
            return Attack;
        }

        public void SetAtt(int att)
        {
            Attack = att;
        }

        public int GetDef()
        {
            return Defense;
        }

        public void SetDef(int def)
        {
            Defense = def;
        }

        public int GetSpeed()
        {
            return Speed;
        }

        public void SetSpeed(int spd)
        {
            Speed = spd;
        }
        public int GetMana()
        {
            return Mana;
        }

        public void SetMana(int mana)
        {
            Mana = mana;
        }

        public Image GetImage()
        {
            return Sprite;
        }

        public void SetImage(Image img)
        {
            Sprite = img;
        }

        public TypePokemon GetTypePkmn()
        {
            return Type;
        }

        public void SetTypePkmn(TypePokemon typepkmn)
        {
            Type = typepkmn;
        }
        
        public List<Attaque> GetMoves()
        {
            return Moves;
        }

        public void SetMoves( List<Attaque> moves)
        {
            Moves = moves;
        }
    }
}
