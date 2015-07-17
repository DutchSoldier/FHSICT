using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace The_Quest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            private Game game;
            private Random random = new Random();
            
        private void Form1_Load(object sender, EventArgs e) 
            {
                game = new Game(new Rectangle(78, 57, 420, 155));
                game.NewLevel(random);
                UpdateCharacters();
            }

            public void UpdateCharacters() 
            {
                Player.Location = game.PlayerLocation;
                playerHitPoints.Text =
                game.PlayerHitPoints.ToString();
                bool showBat = false;
                bool showGhost = false;
                bool showGhoul = false;
                int enemiesShown = 0;
            }

            foreach (Enemy enemy in game.Enemies) 
            {
                if (enemy is Bat) 
                {
                    bat.Location = enemy.Location;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                
            if (enemy.HitPoints > 0) 
                {
                showBat = true;
                enemiesShown++;
                }
            }
        }

        private void UpMoveBt_Click(object sender, EventArgs e)
        {

        }

        private void LeftMoveBt_Click(object sender, EventArgs e)
        {

        }

        private void RightMoveBt_Click(object sender, EventArgs e)
        {

        }

        private void DownMoveBt_Click(object sender, EventArgs e)
        {

        }

        private void upAttackBt_Click(object sender, EventArgs e)
        {

        }

        private void RightAttackBt_Click(object sender, EventArgs e)
        {

        }

        private void DownAttackBt_Click(object sender, EventArgs e)
        {

        }

        private void leftAttackBt_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
