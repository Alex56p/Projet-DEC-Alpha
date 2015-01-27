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
        private int ExpNeeded { get; set; }
        private float ExpRatio { get; set; }

        private int BaseHP { get; set; }
        private int BaseAttack { get; set; }
        private int BaseDefense { get; set; }
        private int BaseSpeed { get; set; }
        private int BaseMana { get; set; }

        private int HP { get; set; }
        private int Attack { get; set; }
        private int Defense { get; set; }
        private int Speed { get; set; }

        private float HPRatio { get; set; }
        private float AttackRatio { get; set; }
        private float DefenseRatio { get; set; }
        private float SpeedRatio { get; set; }

        private int Mana { get; set; }
        private TypePokemon Type { get; set; }
        private Image Sprite;
        private List<Attaque> Moves { get; set; }

        public Pokemon(string nom, int level, int hp, float hpratio, int att, float attratio, int def, float defratio, int speed, float speedratio, TypePokemon type, Image img, List<Attaque> moves)
        {
            SetNom(nom);
            SetBaseMana(10);
            SetBaseHP(hp);
            SetBaseAtt(att);
            SetBaseDef(def);
            SetBaseSpeed(speed);

            SetHPRatio(hpratio);
            SetAttRatio(attratio);
            SetDefRatio(defratio);
            SetSpeedRatio(speedratio);

            SetLevel(level);
            SetExp(0);
            SetMana(10);
            SetHP(hp);
            SetAtt(att);
            SetDef(def);
            SetSpeed(speed);

            SetExp(0);
            SetExpNeeded(100);
            SetExpRatio(1.5f);

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
        public int GetExpNeeded()
        {
            return ExpNeeded;
        }

        public void SetExpNeeded(int exp)
        {
            ExpNeeded = exp;
        }
        public float GetExpRatio()
        {
            return ExpRatio;
        }

        public void SetExpRatio(float exp)
        {
            ExpRatio = exp;
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

        public float GetHPRatio()
        {
            return HPRatio;
        }

        public void SetHPRatio(float hp)
        {
            HPRatio = hp;
        }

        public float GetAttRatio()
        {
            return AttackRatio;
        }

        public void SetAttRatio(float att)
        {
            AttackRatio = att;
        }

        public float GetDefRatio()
        {
            return DefenseRatio;
        }

        public void SetDefRatio(float def)
        {
            DefenseRatio = def;
        }

        public float GetSpeedRatio()
        {
            return SpeedRatio;
        }

        public void SetSpeedRatio(float spd)
        {
            SpeedRatio = spd;
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

        public bool LevelUp()
        {
            if(Exp >= ExpNeeded)
            { 
                SetLevel(GetLevel() + 1);
                StatsUpgrade();
                SetExp(0);
                SetExpNeeded(Convert.ToInt32(GetExpNeeded() * GetExpRatio()));
                return true;
            }
            else
                return false;
        }

        private void StatsUpgrade()
        {
            float lvl = Level;
            BaseHP = Convert.ToInt32(Math.Ceiling(2 * GetHPRatio() + 31) * lvl / 100 + lvl + 10);
            BaseAttack = Convert.ToInt32((Math.Ceiling(2 * GetAttRatio() + 31) * lvl / 100 + 5));
            BaseDefense = Convert.ToInt32((Math.Ceiling(2 * GetDefRatio() + 31) * lvl / 100 + 5));
            BaseSpeed = Convert.ToInt32((Math.Ceiling(2 * GetSpeedRatio() + 31) * lvl / 100 + 5));
        }
    }
}