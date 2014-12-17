using System;
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
        private Attaque Tackle = new Attaque("Tackle", 40, 100, TypePokemon.Normal, 40);
        private Attaque Ember = new Attaque("Ember", 40, 100, TypePokemon.Feu, 40);
        private Attaque WaterGun = new Attaque("Water Gun", 40, 100, TypePokemon.Eau,40);
        private Attaque VineWhip = new Attaque("Vine Whip", 40, 100, TypePokemon.Herbe, 40);
        private List<Attaque> moves = new List<Attaque>();
        private Image img = GetImageFromUrl("http://cdn.bulbagarden.net/upload/thumb/7/73/004Charmander.png/250px-004Charmander.png");
        private Image img2 = GetImageFromUrl("http://cdn.bulbagarden.net/upload/thumb/3/39/007Squirtle.png/600px-007Squirtle.png");

        
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
            Pokemon Charmander = new Pokemon("Charmander", 10, 50, 50, 40,50,TypePokemon.Feu,img,moves);
            Pokemon Squirtle = new Pokemon("Squirtle", 10, 50, 45, 50, 49, TypePokemon.Eau, img2, moves);
            PB_Player.Image = Charmander.GetImage();
            BTN_Move1.Text = Charmander.GetMoves()[0].GetNom();
            BTN_Move2.Text = Charmander.GetMoves()[1].GetNom();
            BTN_Move3.Text = Charmander.GetMoves()[2].GetNom();
            BTN_Move4.Text = Charmander.GetMoves()[3].GetNom();
            LB_lvl.Text = Charmander.GetLevel().ToString();
            LB_xp.Text = Charmander.GetExp().ToString();
            LB_type.Text = Charmander.GetTypePkmn().ToString();
            LB_hp.Text = Charmander.GetHP().ToString();
            LB_mana.Text = Charmander.GetMana().ToString();
            LB_att.Text = Charmander.GetAtt().ToString();
            LB_def.Text = Charmander.GetDef().ToString();
            LB_speed.Text = Charmander.GetSpeed().ToString();

            PB_Player2.Image = Squirtle.GetImage();
            BTN_Move1_2.Text = Squirtle.GetMoves()[0].GetNom();
            BTN_Move2_2.Text = Squirtle.GetMoves()[1].GetNom();
            BTN_Move3_2.Text = Squirtle.GetMoves()[2].GetNom();
            BTN_Move4_2.Text = Squirtle.GetMoves()[3].GetNom();
            LB_lvl2.Text = Squirtle.GetLevel().ToString();
            LB_xp2.Text = Squirtle.GetExp().ToString();
            LB_type2.Text = Squirtle.GetTypePkmn().ToString();
            LB_hp2.Text = Squirtle.GetHP().ToString();
            LB_mana2.Text = Squirtle.GetMana().ToString();
            LB_Att2.Text = Squirtle.GetAtt().ToString();
            LB_Def2.Text = Squirtle.GetDef().ToString();
            LB_Speed2.Text = Squirtle.GetSpeed().ToString();
        }

      
    }
}
