﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Projet_DEC_Alpha
{
    public partial class Form1 : Form
    {
        bool P1_played = false;
        Pokemon P1_pokemon;
        Attaque P1_move;

        bool P2_played = false;
        Pokemon P2_pokemon;
        Attaque P2_move;

        private Attaque Tackle = new Attaque("Charge", 50, 100, TypePokemon.Normal, 40);
        private Attaque Ember = new Attaque("Ember", 40, 100, TypePokemon.Feu, 40);
        private Attaque WaterGun = new Attaque("Hydro Pump", 120, 100, TypePokemon.Eau, 40);
        private Attaque VineWhip = new Attaque("Tempête Verte", 80, 100, TypePokemon.Herbe, 40);
        private List<Attaque> moves = new List<Attaque>();
        private Image img = GetImageFromUrl("http://cdn.bulbagarden.net/upload/thumb/9/9a/095Onix.png/250px-095Onix.png");
        private Image img2 = GetImageFromUrl("http://cdn.bulbagarden.net/upload/thumb/0/0d/025Pikachu.png/250px-025Pikachu.png");


        public Form1()
        {
            InitializeComponent();

        }
        public static Image GetImageFromUrl(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);

            using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            moves.Add(Tackle);
            moves.Add(Ember);
            moves.Add(WaterGun);
            moves.Add(VineWhip);
            Pokemon Charmander = new Pokemon("Onix", 5, 20, 35, 12, 45, 12, 160, 13, 70,TypePokemon.Eau, img, moves);
            Pokemon Squirtle = new Pokemon("Pikachu",5, 21, 35, 12, 55, 13, 40, 11, 90, TypePokemon.Feu, img2, moves);
            P1_pokemon = Charmander;
            P2_pokemon = Squirtle;
            RTB_Battle.Text += "Game Start!";
            EnterStats();
        }

        private void WaitEndTurn()
        {
            if (P1_played && P2_played)
            {
                UseAttacks();
                AbleMovesP1();
                AbleMovesP2();
                P1_played = false;
                P2_played = false;
                
            }
        }

        private void ShowStatsUpgrade(Pokemon pkmn)
        {
            float lvl = pkmn.GetLevel() + 1;
            RTB_Battle.Text += Environment.NewLine + "HP +" + (Convert.ToInt32(Math.Floor(2 * pkmn.GetHPRatio() + 31 )* lvl / 100 + lvl + 10) - pkmn.GetBaseHP());
            RTB_Battle.Text += Environment.NewLine + "Attack +" + (Convert.ToInt32((Math.Floor(2 * pkmn.GetAttRatio() + 31) * lvl / 100 + 5)) - pkmn.GetBaseAtt());
            RTB_Battle.Text += Environment.NewLine + "Defense +" + (Convert.ToInt32((Math.Floor(2 * pkmn.GetDefRatio() + 31) * lvl / 100 + 5)) - pkmn.GetBaseDef());
            RTB_Battle.Text += Environment.NewLine + "Speed +" + (Convert.ToInt32((Math.Floor(2 * pkmn.GetSpeedRatio() + 31) * lvl / 100 + 5)) - pkmn.GetBaseSpeed());
        }

        private void UseAttacks()
        {
            bool dead = false;
            if (!dead && P1_pokemon.GetSpeed() > P2_pokemon.GetSpeed())
            {
                RTB_Battle.Text += Environment.NewLine + P1_pokemon.GetNom() + " used " + P1_move.GetNom() + " and dealt " + P1_move.Use(P1_pokemon, P2_pokemon) + " to " + P2_pokemon.GetNom();
                WriteEffectiveness(P1_move, P2_pokemon);
                dead = IsSomeoneDead();

                if (!dead)
                {
                    RTB_Battle.Text += Environment.NewLine + P2_pokemon.GetNom() + " used " + P2_move.GetNom() + " and dealt " + P2_move.Use(P2_pokemon, P1_pokemon) + " to " + P1_pokemon.GetNom();
                    WriteEffectiveness(P2_move, P1_pokemon);
                }
                dead = IsSomeoneDead();
                UpdateStats();
                
            }
            else if (!dead && P1_pokemon.GetSpeed() > P2_pokemon.GetSpeed())
            {
                RTB_Battle.Text += Environment.NewLine + P2_pokemon.GetNom() + " used " + P2_move.GetNom() + " and dealt " + P2_move.Use(P2_pokemon, P1_pokemon) + " to " + P1_pokemon.GetNom();
                WriteEffectiveness(P2_move, P1_pokemon);
                dead = IsSomeoneDead();
                if(!dead)
                {
                    RTB_Battle.Text += Environment.NewLine + P1_pokemon.GetNom() + " used " + P1_move.GetNom() + " and dealt " + P1_move.Use(P1_pokemon, P2_pokemon) + " to " + P2_pokemon.GetNom();
                    WriteEffectiveness(P1_move, P2_pokemon);
                }
                    
                dead = IsSomeoneDead();
                UpdateStats();
            }
            else if(!dead)
            {
                Random rnd = new Random();
                if(rnd.Next(0,2) == 1)
                { 
                    RTB_Battle.Text += Environment.NewLine + P1_pokemon.GetNom() + " used " + P1_move.GetNom() + " and dealt " + P1_move.Use(P1_pokemon, P2_pokemon) + " to " + P2_pokemon.GetNom();
                    WriteEffectiveness(P1_move,P2_pokemon);
                    dead = IsSomeoneDead();
                    if(!dead)
                    {
                        RTB_Battle.Text += Environment.NewLine + P2_pokemon.GetNom() + " used " + P2_move.GetNom() + " and dealt " + P2_move.Use(P2_pokemon, P1_pokemon) + " to " + P1_pokemon.GetNom();
                        WriteEffectiveness(P2_move, P1_pokemon);
                    }
                        
                    dead = IsSomeoneDead();
                }
                else
                {
                    RTB_Battle.Text += Environment.NewLine + P2_pokemon.GetNom() + " used " + P2_move.GetNom() + " and dealt " + P2_move.Use(P2_pokemon, P1_pokemon) + " to " + P1_pokemon.GetNom();
                    WriteEffectiveness(P2_move, P1_pokemon);
                    dead = IsSomeoneDead();
                    if (!dead)
                    {
                        RTB_Battle.Text += Environment.NewLine + P1_pokemon.GetNom() + " used " + P1_move.GetNom() + " and dealt " + P1_move.Use(P1_pokemon, P2_pokemon) + " to " + P2_pokemon.GetNom();
                        WriteEffectiveness(P1_move, P2_pokemon);
                    }
                    dead = IsSomeoneDead();
                }
                UpdateStats();
            }
            if(!dead)
            { 
                LB_Turn.Text = (int.Parse(LB_Turn.Text) + 1).ToString(); 
            }
        }

        private void WriteEffectiveness(Attaque move, Pokemon receveur)
        {
            float Effectiveness = IsEffective(move,receveur);
            if(Effectiveness == 0.5f)
            {
                RTB_Battle.Text += Environment.NewLine + "It's not very effective!";
            }
            else if(Effectiveness == 2)
            {
                RTB_Battle.Text += Environment.NewLine + "It's super effective!";
            }
        }

        private float IsEffective(Attaque move, Pokemon receveur)
        {
            float Effectiveness;
            if (receveur.GetTypePkmn() == TypePokemon.Normal)
            {
                Effectiveness = 1;
                return Effectiveness;
            }
            else if (receveur.GetTypePkmn() == TypePokemon.Eau)
            {
                if (move.GetTypePkmn() == TypePokemon.Feu)
                {
                    Effectiveness = 0.5f;
                    return Effectiveness;
                }
                else if (move.GetTypePkmn() == TypePokemon.Eau)
                {
                    Effectiveness = 0.5f;
                    return Effectiveness;
                }
                else if (move.GetTypePkmn() == TypePokemon.Herbe)
                {
                    Effectiveness = 2;
                    return Effectiveness;
                }
                else if (move.GetTypePkmn() == TypePokemon.Normal)
                {
                    Effectiveness = 1;
                    return Effectiveness;
                }
            }
            else if (receveur.GetTypePkmn() == TypePokemon.Feu)
            {
                if (move.GetTypePkmn() == TypePokemon.Feu)
                {
                    Effectiveness = 0.5f;
                    return Effectiveness;
                }
                else if (move.GetTypePkmn() == TypePokemon.Eau)
                {
                    Effectiveness = 2;
                    return Effectiveness;
                }
                else if (move.GetTypePkmn() == TypePokemon.Herbe)
                {
                    Effectiveness = 0.5f;
                    return Effectiveness;
                }
                else if (move.GetTypePkmn() == TypePokemon.Normal)
                {
                    Effectiveness = 1;
                    return Effectiveness;
                }
            }
            else if (receveur.GetTypePkmn() == TypePokemon.Herbe)
            {
                if (move.GetTypePkmn() == TypePokemon.Feu)
                {
                    Effectiveness = 2;
                    return Effectiveness;
                }
                else if (move.GetTypePkmn() == TypePokemon.Eau)
                {
                    Effectiveness = 0.5f;
                    return Effectiveness;
                }
                else if (move.GetTypePkmn() == TypePokemon.Herbe)
                {
                    Effectiveness = 0.5f;
                    return Effectiveness;
                }
                else if (move.GetTypePkmn() == TypePokemon.Normal)
                {
                    Effectiveness = 1;
                    return Effectiveness;
                }
            }
            Effectiveness = 1;
            return Effectiveness;
        }

        private bool IsSomeoneDead()
        {
            if (P1_pokemon.GetHP() > 0 && P2_pokemon.GetHP() > 0)
            {
                return false;
            }
            else if (P1_pokemon.GetHP() <= 0)
            {
                RTB_Battle.Text += Environment.NewLine + P2_pokemon.GetNom() + " won!" + Environment.NewLine;
                P2_pokemon.SetExp(P2_pokemon.GetExp() + 50);
                if (P2_pokemon.GetExp() >= P2_pokemon.GetExpNeeded())
                {
                    RTB_Battle.Text += Environment.NewLine + P2_pokemon.GetNom() + " leveled up!";
                    ShowStatsUpgrade(P2_pokemon);
                    P2_pokemon.LevelUp();
                    RTB_Battle.Text += Environment.NewLine;
                }
                EnterStats();
                return true;
            }
            else if (P2_pokemon.GetHP() <= 0)
            {
                P1_pokemon.SetExp(P1_pokemon.GetExp() + 50);
                RTB_Battle.Text += Environment.NewLine + P1_pokemon.GetNom() + " won!";
                if (P1_pokemon.GetExp() >= P1_pokemon.GetExpNeeded())
                {
                    RTB_Battle.Text += Environment.NewLine + P1_pokemon.GetNom() + " leveled up!";
                    ShowStatsUpgrade(P1_pokemon);
                    P1_pokemon.LevelUp();
                }
                EnterStats();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void EnterStats()
        {
            LB_Turn.Text = "1";
            RTB_Battle.Text += Environment.NewLine + "Battle Start!";


            //Player1
            P1_pokemon.SetHP(P1_pokemon.GetBaseHP());
            P1_pokemon.SetAtt(P1_pokemon.GetBaseAtt());
            P1_pokemon.SetDef(P1_pokemon.GetBaseDef());
            P1_pokemon.SetSpeed(P1_pokemon.GetBaseSpeed());

            PB_Player.Image = P1_pokemon.GetImage();
            BTN_Move1.Text = P1_pokemon.GetMoves()[0].GetNom();
            BTN_Move2.Text = P1_pokemon.GetMoves()[1].GetNom();
            BTN_Move3.Text = P1_pokemon.GetMoves()[2].GetNom();
            BTN_Move4.Text = P1_pokemon.GetMoves()[3].GetNom();
            LB_lvl.Text = P1_pokemon.GetLevel().ToString();
            LB_xp.Text = P1_pokemon.GetExp().ToString();
            LB_ExpNeeded.Text = P1_pokemon.GetExpNeeded().ToString();
            LB_type.Text = P1_pokemon.GetTypePkmn().ToString();
            LB_hp.Text = P1_pokemon.GetBaseHP().ToString();
            LB_mana.Text = P1_pokemon.GetBaseMana().ToString();
            LB_att.Text = P1_pokemon.GetBaseAtt().ToString();
            LB_def.Text = P1_pokemon.GetBaseDef().ToString();
            LB_speed.Text = P1_pokemon.GetBaseSpeed().ToString();

            //Player2
            P2_pokemon.SetHP(P2_pokemon.GetBaseHP());
            P2_pokemon.SetAtt(P2_pokemon.GetBaseAtt());
            P2_pokemon.SetDef(P2_pokemon.GetBaseDef());
            P2_pokemon.SetSpeed(P2_pokemon.GetBaseSpeed());

            PB_Player2.Image = P2_pokemon.GetImage();
            BTN_Move1_2.Text = P2_pokemon.GetMoves()[0].GetNom();
            BTN_Move2_2.Text = P2_pokemon.GetMoves()[1].GetNom();
            BTN_Move3_2.Text = P2_pokemon.GetMoves()[2].GetNom();
            BTN_Move4_2.Text = P2_pokemon.GetMoves()[3].GetNom();
            LB_lvl2.Text = P2_pokemon.GetLevel().ToString();
            LB_xp2.Text = P2_pokemon.GetExp().ToString();
            LB_ExpNeeded2.Text = P2_pokemon.GetExpNeeded().ToString();
            LB_type2.Text = P2_pokemon.GetTypePkmn().ToString();
            LB_hp2.Text = P2_pokemon.GetBaseHP().ToString();
            LB_mana2.Text = P2_pokemon.GetBaseMana().ToString();
            LB_Att2.Text = P2_pokemon.GetBaseAtt().ToString();
            LB_Def2.Text = P2_pokemon.GetBaseDef().ToString();
            LB_Speed2.Text = P2_pokemon.GetBaseSpeed().ToString();
        }
        private void UpdateStats()
        {
            //Player1
            LB_lvl.Text = P1_pokemon.GetLevel().ToString();
            LB_xp.Text = P1_pokemon.GetExp().ToString();
            LB_type.Text = P1_pokemon.GetTypePkmn().ToString();
            LB_hp.Text = P1_pokemon.GetHP().ToString();
            LB_mana.Text = P1_pokemon.GetMana().ToString();
            LB_att.Text = P1_pokemon.GetAtt().ToString();
            LB_def.Text = P1_pokemon.GetDef().ToString();
            LB_speed.Text = P1_pokemon.GetSpeed().ToString();
            //Player2
            LB_lvl2.Text = P2_pokemon.GetLevel().ToString();
            LB_xp2.Text = P2_pokemon.GetExp().ToString();
            LB_type2.Text = P2_pokemon.GetTypePkmn().ToString();
            LB_hp2.Text = P2_pokemon.GetHP().ToString();
            LB_mana2.Text = P2_pokemon.GetMana().ToString();
            LB_Att2.Text = P2_pokemon.GetAtt().ToString();
            LB_Def2.Text = P2_pokemon.GetDef().ToString();
            LB_Speed2.Text = P2_pokemon.GetSpeed().ToString();
        }



        private void BTN_Move1_Click(object sender, EventArgs e)
        {
            P1_move = P1_pokemon.GetMoves()[0];
            P1_played = true;
            DisableP1Moves();
        }

        private void BTN_Move2_Click(object sender, EventArgs e)
        {
            P1_move = P1_pokemon.GetMoves()[1];
            P1_played = true;
            DisableP1Moves();
        }

        private void BTN_Move3_Click(object sender, EventArgs e)
        {
            P1_move = P1_pokemon.GetMoves()[2];
            P1_played = true;
            DisableP1Moves();
        }

        private void BTN_Move4_Click(object sender, EventArgs e)
        {
            P1_move = P1_pokemon.GetMoves()[3];
            P1_played = true;
            DisableP1Moves();
        }

        private void BTN_Move1_2_Click(object sender, EventArgs e)
        {
            P2_move = P2_pokemon.GetMoves()[0];
            P2_played = true;
            DisableP2Moves();
        }

        private void BTN_Move2_2_Click(object sender, EventArgs e)
        {
            P2_move = P2_pokemon.GetMoves()[1];
            P2_played = true;
            DisableP2Moves();
        }

        private void BTN_Move3_2_Click(object sender, EventArgs e)
        {
            P2_move = P2_pokemon.GetMoves()[2];
            P2_played = true;
            DisableP2Moves();
        }

        private void BTN_Move4_2_Click(object sender, EventArgs e)
        {
            P2_move = P2_pokemon.GetMoves()[3];
            P2_played = true;
            DisableP2Moves();
        }

        private void DisableP1Moves()
        {
            BTN_Move1.Enabled = false;
            BTN_Move2.Enabled = false;
            BTN_Move3.Enabled = false;
            BTN_Move4.Enabled = false;
            WaitEndTurn();
        }

        private void DisableP2Moves()
        {
            BTN_Move1_2.Enabled = false;
            BTN_Move2_2.Enabled = false;
            BTN_Move3_2.Enabled = false;
            BTN_Move4_2.Enabled = false;
            WaitEndTurn();
        }

        private void AbleMovesP1()
        {
            BTN_Move1.Enabled = true;
            BTN_Move2.Enabled = true;
            BTN_Move3.Enabled = true;
            BTN_Move4.Enabled = true;
        }

        private void AbleMovesP2()
        {
            BTN_Move1_2.Enabled = true;
            BTN_Move2_2.Enabled = true;
            BTN_Move3_2.Enabled = true;
            BTN_Move4_2.Enabled = true;
        }

        private void RTB_Battle_TextChanged(object sender, EventArgs e)
        {
            RTB_Battle.SelectionStart = RTB_Battle.Text.Length; //Set the current caret position at the end
            RTB_Battle.ScrollToCaret(); //Now scroll it automatically
        }

    }
}
