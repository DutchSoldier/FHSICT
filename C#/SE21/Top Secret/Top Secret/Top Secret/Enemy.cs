using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Top_Secret
{
    class Enemy
    {
        private Player player;
        private SpriteBatch sprite;
        private ContentManager content;
        private Collision collision;
        public Vector2 location;
        private int jumpSpeed;
        private int index;
        private int health;

        public Texture2D enemyTex { get; private set; }
  
        public Enemy(Player Player, SpriteBatch Sprite, ContentManager Content, string type, Collision Collision, int Index)
        {
            player = Player;
            sprite = Sprite;
            content = Content;
            collision = Collision;
            index = Index;

            loadEnemy(type);
            setEnemyStartingPosition();
            setStartingHealth();
        }

        //load enemy
        
        public void loadEnemy(string type)
        {
            if (type == "melee")
            {
                enemyTex = this.content.Load<Texture2D>(@"Animations/Enemy/EnemyMelee");
            }
        }

        public void setStartingHealth()
        {
            health = 100;
        }

        public void modifyHealth(int amount)
        {
            health -= amount;
        }

        public bool isAlive()
        {
            if (health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void updateHeight()
        {
            if (!collision.checkEnemyLevelCollision(index).Contains("Bottom"))
            {
                if (jumpSpeed >= 0 && jumpSpeed <= 2)
                {
                    location.Y += 2;
                }

                if (jumpSpeed >= 3 && jumpSpeed <= 5)
                {
                    location.Y += 4;
                }

                if (jumpSpeed >= 6 && jumpSpeed <= 8)
                {
                    location.Y += 6;
                }

                if (jumpSpeed >= 9 && jumpSpeed <= 11)
                {
                    location.Y += 8;
                }

                if (jumpSpeed > 11)
                {
                    location.Y += 10;
                }
                jumpSpeed++;
            }
            else
            {
                jumpSpeed = 0;
            }
        }
        //draw enemy
        
        public void DrawEnemy()
        {
            sprite.Begin();
            sprite.Draw(enemyTex, location, Color.White);
            sprite.End();
        }  

        //spawn enemy rechts

        public void setEnemyStartingPosition()
        {
            location.X = GlobalVars.resolutionWidth;
            location.Y = 0;
        }

        //Enemy move
        public bool moveTowardsPlayer()
        {
            if (location.X < player.location.X - 150)
            {
                if (!collision.checkEnemyLevelCollision(index).Contains("Right"))
                {
                    location.X += 5;
                    return false;
                }
            }

            if (location.X > player.location.X + 150)
            {
                if (!collision.checkEnemyLevelCollision(index).Contains("Left"))
                {
                    location.X -= 5;
                    return false;
                }
            }
            return true;
        }

        /*
        //Enemy attack als 'ie dichtbij genoeg is
        public void enemyAttack()
        {
            if ((enemy.Location.X - player.Location.X) = //tussen -50 en 50)
            {
                enemy.Attack;
            }
        }
        */

        //Waar is enemy
        //Waar is player
        //enemy -> player
        
        
    }
}
