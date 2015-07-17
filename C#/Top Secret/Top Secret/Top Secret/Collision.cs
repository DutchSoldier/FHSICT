using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;


namespace Top_Secret
{
    class Collision
    {
        private PlayerAnimation animation;
        private Player player;
        private Level level;
        private Rectangle playerRecLeft;
        private Rectangle playerRecRight;
        private Rectangle playerRecTop;
        private Rectangle playerRecBottom;
        private Rectangle playerRec;
        private Rectangle[] enemyRecLeft;
        private Rectangle[] enemyRecRight;
        private Rectangle[] enemyRecTop;
        private Rectangle[] enemyRecBottom;
        private Rectangle[] enemyRec;
        public Enemy[] enemy;

        public Collision(PlayerAnimation Animation, Player Player, Level Level)
        {
            animation = Animation;
            player = Player;
            level = Level;
        }

        public void setPlayerHitboxes()
        {
            playerRecRight = new Rectangle((int)player.location.X + animation.playerTex.Width / 2, (int)player.location.Y + 20, animation.playerTex.Width / 2, animation.playerTex.Height - 40);
            playerRecLeft = new Rectangle((int)player.location.X, (int)player.location.Y + 20, animation.playerTex.Width / 2, animation.playerTex.Height - 40);
            playerRecTop = new Rectangle((int)player.location.X + 10, (int)player.location.Y, animation.playerTex.Width - 20, 20);
            playerRecBottom = new Rectangle((int)player.location.X + 10, (int)player.location.Y + animation.playerTex.Height - 20, animation.playerTex.Width - 20, 20);
            playerRec = new Rectangle((int)player.location.X, (int)player.location.Y, animation.playerTex.Width, animation.playerTex.Height);
        }

        public void setEnemyHitboxes()
        {
            enemyRecRight = new Rectangle[enemy.Length];
            enemyRecLeft = new Rectangle[enemy.Length];
            enemyRecTop = new Rectangle[enemy.Length];
            enemyRecBottom = new Rectangle[enemy.Length];
            enemyRec = new Rectangle[enemy.Length];

            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i] != null)
                {
                    enemyRecRight[i] = new Rectangle((int)enemy[i].location.X + enemy[i].enemyTex.Width / 2, (int)enemy[i].location.Y + 20, enemy[i].enemyTex.Width / 2, enemy[i].enemyTex.Height - 40);
                    enemyRecLeft[i] = new Rectangle((int)enemy[i].location.X, (int)enemy[i].location.Y + 20, enemy[i].enemyTex.Width / 2, enemy[i].enemyTex.Height - 40);
                    enemyRecTop[i] = new Rectangle((int)enemy[i].location.X + 10, (int)enemy[i].location.Y, enemy[i].enemyTex.Width - 20, 20);
                    enemyRecBottom[i] = new Rectangle((int)enemy[i].location.X + 10, (int)enemy[i].location.Y + enemy[i].enemyTex.Height - 20, enemy[i].enemyTex.Width - 20, 20);
                    enemyRec[i] = new Rectangle((int)enemy[i].location.X, (int)enemy[i].location.Y, enemy[i].enemyTex.Width, enemy[i].enemyTex.Height);
                }
            }
        }

        public string checkEnemyLevelCollision(int i)
        {
            setEnemyHitboxes();
            string collision = "";

            for (int y = 0; y < level.levelRec.Length; y++)
            {
                if (enemyRecRight[i].Intersects(level.levelRec[y]))
                {
                    collision += "Right";
                }

                if (enemyRecLeft[i].Intersects(level.levelRec[y]))
                {
                    collision += "Left";
                }

                if (enemyRecBottom[i].Intersects(level.levelRec[y]))
                {
                    collision += "Bottom";
                }
            }
            return collision;
        }

        public string checkPlayerLevelCollision()
        {
            setPlayerHitboxes();
            string collision = "";

            for (int i = 0; i < level.levelRec.Length; i++)
            {
                if (playerRecRight.Intersects(level.levelRec[i]))
                {
                    collision += "Right";
                }

                if (playerRecLeft.Intersects(level.levelRec[i]))
                {
                    collision += "Left";
                }

                if (playerRecBottom.Intersects(level.levelRec[i]))
                {
                    collision += "Bottom;";
                }
            }
            return collision;
        }

        public bool checkEnemyPlayerCollision(int i)
        {
            if (enemyRec[i].Intersects(playerRec))
            {
                return true;
            }
            return false;
        }

        public int CheckEventCollision()
        {
            for (int i = 0; i < level.eventRec.Length; i++)
            {
                if (playerRecRight.Intersects(level.eventRec[i]))
                {
                    level.eventRec[i].Y = 2000;
                    return i;
                }
            }
            return -1;
        }
    }
}
