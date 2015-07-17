using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;



namespace TopSecret2
{
    class Enemy
    {
        public Vector2 location;
        public Texture2D[] enemyTex;
        private float airVelocity;
        private int currentFrame;
        private int direction;
        int health;
        int damage;

        private float recoilCounter;

        private TimeSpan nextAttack = TimeSpan.FromSeconds(0);
        private TimeSpan lastAttack = TimeSpan.FromSeconds(0);

        TimeSpan nextFrameInterval = TimeSpan.FromSeconds(1.0f / 12);
        TimeSpan nextFrame = TimeSpan.FromSeconds(1);

        public Rectangle enemyRecLeft;
        public Rectangle enemyRecRight;
        public Rectangle enemyRecTop;
        public Rectangle enemyRecBottom;
        public Rectangle enemyRec;

        public Enemy(string type, Vector2 Location, ContentManager Content)
        {
            enemyTex = new Texture2D[36];
            location = Location;
            airVelocity = 15f;
            recoilCounter = 0f;
            health = GlobalVars.healthMelee;
            damage = GlobalVars.damageMelee;

            LoadEnemy(Content);
        }

        public void LoadEnemy(ContentManager Content)
        {
            for (int i = 0; i < 36; i++)
            {
                enemyTex[i] = Content.Load<Texture2D>(@"Enemies/ZombieMelee/" + Convert.ToString(i));
            }
        }

        public void updateHitBoxes()
        {
            int width = enemyTex[currentFrame].Width;
            int height = enemyTex[currentFrame].Height;
            int x = (int)location.X;
            int y = (int)location.Y;

            enemyRecRight = new Rectangle(
                x + width / 2,
                y + 20,
                width / 2,
                height - 40);

            enemyRecLeft = new Rectangle(
                x,
                y + 20,
                width / 2,
                height - 40);

            enemyRecTop = new Rectangle(
                x + 10,
                y,
                width - 20,
                20);

            enemyRecBottom = new Rectangle(
                x + 10,
                y + height - 20,
                width - 20,
                20);

            enemyRec = new Rectangle(
                x,
                y,
                width,
                height);
        }

        public void updateHeight(Collision collision, Level level)
        {
            if (!collision.checkEnemyLevelCollision(this, level).Contains("Bottom"))
            {
                if (airVelocity <= 15)
                {
                    airVelocity += 0.5f;
                }
                location = new Vector2(location.X, location.Y + airVelocity);
            }
        }

        public void Attack(GameTime gameTime, Player player, Collision collision)
        {
            animateAttack(gameTime);
            if (nextAttack >= (lastAttack + TimeSpan.FromSeconds(1.08)))
            {
                if (collision.checkIfEnemyHitPlayer(this, player))
                {
                    player.Hit(damage); 
                }
                lastAttack = gameTime.TotalGameTime;
            }
            else
            {
                nextAttack = gameTime.TotalGameTime;
            }
        }

        public void Hit(int damage, bool recoil)
        {
            health -= damage;
            if (recoil)
            {
                recoilCounter = 1;
            }
        }

        public bool isAlive()
        {
            if (health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Recoil(Player player)
        {
            if (recoilCounter > 0)
            {
                int direction;
                if (location.X < player.location.X)
                {
                    direction = -1;
                }
                else
                {
                    direction = 1;
                }

                if (recoilCounter < 20)
                {
                    location.X += 15 / (recoilCounter / 2) * direction;
                }
                recoilCounter++;

                if (recoilCounter > 40)
                {
                    recoilCounter = 0;
                }
                return true;
            }
            return false;
        }

        public bool Move(Player player, Collision collision, Level level, GameTime gameTime, PlayerAnimations playerAnimations)
        {
            if (!Recoil(player))
            {
                if (location.X + enemyTex[currentFrame].Width < player.location.X)
                {
                    if (!collision.checkEnemyLevelCollision(this, level).Contains("Right"))
                    {
                        direction = 1;
                        location.X += 5;
                        animateMove(gameTime);
                        lastAttack = gameTime.TotalGameTime - TimeSpan.FromSeconds(0.5);
                        return false;
                    }
                }

                if (location.X > player.location.X + playerAnimations.playerTex[playerAnimations.currentframe].Width)
                {
                    if (!collision.checkEnemyLevelCollision(this, level).Contains("Left"))
                    {
                        direction = 0;
                        location.X -= 5;
                        animateMove(gameTime);
                        lastAttack = gameTime.TotalGameTime -TimeSpan.FromSeconds(0.5);
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void animateMove(GameTime gameTime)
        {
            if (nextFrame >= nextFrameInterval)
            {
                if (currentFrame >= 0 && currentFrame < 23)
                {
                    currentFrame++;
                }
                else
                {
                    currentFrame = 0;
                }
                nextFrame = TimeSpan.Zero;
            }
            else
            {
                nextFrame += gameTime.ElapsedGameTime;
            }
        }

        public void animateAttack(GameTime gameTime)
        {
            if (nextFrame >= nextFrameInterval)
            {
                if (currentFrame >= 24 && currentFrame < 35)
                {
                    currentFrame++;
                }
                else
                {
                    currentFrame = 24;
                }
                nextFrame = TimeSpan.Zero;
            }
            else
            {
                nextFrame += gameTime.ElapsedGameTime;
            }
        }

        public void DrawEnemy(SpriteBatch sprite)
        {
            sprite.Begin();
            if (direction == 1)
            {
                sprite.Draw(enemyTex[currentFrame], location, Color.White);
            }
            else
            {
                sprite.Draw(enemyTex[currentFrame], location, null, Color.White,0,new Vector2(0,0),1, SpriteEffects.FlipHorizontally,0);
            }
            sprite.End();
        } 
    }
}
