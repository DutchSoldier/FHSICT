using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace TopSecret2
{
    class Player
    {
        public bool screenLocked;
        public bool jumping;
        private bool grounded;
        private bool allowJump;
        private float velocity;

        private int comboCounter;
        private TimeSpan nextAttack;
        private TimeSpan lastAttack;

        public Rectangle playerRecLeft;
        public Rectangle playerRecRight;
        public Rectangle playerRecTop;
        public Rectangle playerRecBottom;
        public Rectangle playerRec;

        public Vector2 location { get; private set; }
        public int health { get;  set; }

        public Player(PlayerAnimations animation)
        {
            ResetPlayer(animation);  
        }

        public void ResetPlayer(PlayerAnimations animation)
        {
            location = new Vector2(GlobalVars.resolutionWidth / 2 - animation.playerTex[animation.currentframe].Width, 0);
            health = 100;
            nextAttack = TimeSpan.FromSeconds(0);
            lastAttack = TimeSpan.FromSeconds(0);
            comboCounter = 0;
            velocity = 15f;
            jumping = false;
            grounded = false;
            allowJump = false;
        }

        public void UpdateHitboxes(PlayerAnimations animation)
        {
            int width = animation.playerTex[animation.currentframe].Width;
            int height = animation.playerTex[animation.currentframe].Height;
            int x = (int)location.X;
            int y = (int)location.Y;

            playerRecRight = new Rectangle(
                x + width / 2,
                y + 20,
                width / 2,
                height - 40);

            playerRecLeft = new Rectangle(
                x,
                y + 20,
                width / 2,
                height - 40);

            playerRecTop = new Rectangle(
                x + 10,
                y,
                width - 20,
                20);

            playerRecBottom = new Rectangle(
                x + 10,
                y + height - 20,
                width - 20,
                20);

            playerRec = new Rectangle(
                x,
                y,
                width,
                height);
        }

        public void UpdateHeight(PlayerAnimations animation, Level level, Collision collision)
        {
            if (jumping && allowJump)
            {
                if (grounded)
                {
                    velocity = 15f;
                }

                grounded = false;
                location = new Vector2(location.X, location.Y - velocity);
                velocity -= 0.5f;
                if (velocity <= 0)
                {
                    jumping = false;
                    allowJump = false;
                }
            }
            else
            {
                if (grounded)
                {
                    velocity = 1f;
                }
                if (!collision.checkPlayerLevelCollision(animation, this, level).Contains("Bottom"))
                {
                    if (velocity <= 15)
                    {
                        velocity += 0.5f;
                    }
                    location = new Vector2(location.X, location.Y + velocity);
                    allowJump = false;
                    grounded = false;
                }
                else
                {
                    grounded = true;
                    allowJump = true;
                }
            }
        }

        public void Combo(GameTime gameTime, List<Enemy>enemies, Collision collision)
        {
            if (nextAttack >= (lastAttack + TimeSpan.FromSeconds(1)))
            {
                comboCounter = 0;
                foreach (Enemy enemy in enemies)
                {
                    if (collision.checkIfPlayerHitEnemy(enemy, this))
                    {
                        enemy.Hit(20, true);
                    }
                }
                lastAttack = gameTime.TotalGameTime;
                comboCounter = 1;
            }
            else
            {
                if (comboCounter == 0)
                {
                    nextAttack = gameTime.TotalGameTime;
                }
                else
                {
                    if (nextAttack >= (lastAttack + TimeSpan.FromSeconds(0.5)))
                    {
                        foreach (Enemy enemy in enemies)
                        {
                            if (collision.checkIfPlayerHitEnemy(enemy, this))
                            {
                                if (comboCounter == 1)
                                {
                                    enemy.Hit(20, true);
                                }
                                if (comboCounter == 2)
                                {
                                    enemy.Hit(20, true);
                                }
                                if (comboCounter == 3)
                                {
                                    enemy.Hit(20, true);
                                }
                            }
                        }
                        if (comboCounter <= 3)
                        {
                            comboCounter++;
                        }
                        else
                        {
                            comboCounter = 0;
                        }
                        lastAttack = gameTime.TotalGameTime;
                    }
                    else
                    {
                        nextAttack = gameTime.TotalGameTime;
                    }
                }
            }
        }

        public void Hit(int damage)
        {
            health -= damage;
        }

        public void Heal(int amount)
        {
            health += amount;
            if (health > 100)
            {
                health = 100;
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

        public void MoveRight(PlayerAnimations animation, Level level, GameTime gameTime, Collision collision)
        {
            if (!collision.checkPlayerLevelCollision(animation, this, level).Contains("Right"))
            {
                animation.BotState = PlayerAnimations.BottomAnimationState.Walking;
                if (!screenLocked)
                {
                    level.MoveLevel(1);
                }
                else
                {
                    if (location.X < GlobalVars.resolutionWidth - animation.playerTex[animation.currentframe].Width)
                    {
                        location += new Vector2(GlobalVars.playerSpeed, 0);
                    }
                }
            }
        }

        public void MoveLeft(PlayerAnimations animation, Level level, GameTime gameTime, Collision collision)
        {
            if (level.location > 0)
            {
                if (!collision.checkPlayerLevelCollision(animation, this, level).Contains("Left"))
                {
                    animation.Moving(gameTime);

                    if (!screenLocked)
                    {
                        level.MoveLevel(-1);
                    }
                    else
                    {
                        if (location.X > 0)
                        {
                            location -= new Vector2(GlobalVars.playerSpeed, 0);
                        }
                    }
                }
            }
        }

        public bool MoveToCenter(PlayerAnimations animation, Level level)
        {
            if (!screenLocked)
            {
                int center = GlobalVars.resolutionWidth / 2 - animation.playerTex[animation.currentframe].Width;

                if (location.X > center)
                {
                    location -= new Vector2(GlobalVars.playerSpeed, 0);
                    level.MoveLevel(1);
                }

                if (location.X < center)
                {
                    location += new Vector2(GlobalVars.playerSpeed, 0);
                    level.MoveLevel(-1);
                }

                if (location.X == center)
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        public bool MoveToEnd(PlayerAnimations animation, GameTime gameTime)
        {
            if (location.X < GlobalVars.resolutionWidth)
            {
                animation.Moving(gameTime);
                location += new Vector2(GlobalVars.playerSpeed, 0);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
