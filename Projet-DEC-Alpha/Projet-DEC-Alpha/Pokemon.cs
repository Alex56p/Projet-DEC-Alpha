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
            Nom = nom;
            Level = level;
            Exp = 0;
            Mana = 10;
            HP = hp;
            Attack = att;
            Defense = def;
            Speed = speed;
            Type = type;
            Sprite = img;
            Moves = moves;
        }

        public string GetNom()
        {
            return Nom;
        }

        public int GetLevel()
        {
            return Level;
        }

        public int GetExp()
        {
            return Exp;
        }

        public int GetHP()
        {
            return HP;
        }

        public int GetAtt()
        {
            return Attack;
        }

        public int GetDef()
        {
            return Defense;
        }

        public int GetSpeed()
        {
            return Speed;
        }
        public int GetMana()
        {
            return Mana;
        }

        public Image GetImage()
        {
            return Sprite;
        }

        public TypePokemon GetTypePkmn()
        {
            return Type;
        }
        
        public List<Attaque> GetMoves()
        {
            return Moves;
        }
    }
}
