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
    class Player
    {
        public Collision Collision;
        private PlayerAnimation animation;
        private Level level;

        public int locationLevel;
        public Vector2 location;
        private int jumpSpeed;
        private int health;
        private float center;
        public bool jumping;

        public bool locked { get; private set; }
        public bool allowJump { get; private set; }
       
        public Player(Level Level, PlayerAnimation Animation)
        {
            level = Level;
            animation = Animation;
            allowJump = true;
            setStartingHealth();
        }

        public void setStartingPosition()
        {
            location.X = GlobalVars.resolutionWidth/2 - animation.playerTex.Width/2;
            location.Y = 0;
            center = location.X;
        }

        public void setStartingHealth()
        {
            health = 100;
        }

        public void modifyHealth(int amount)
        {
            health -= health;
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
            if (jumping)
            {
                if (jumpSpeed >= 0 && jumpSpeed <= 15)
                {
                    location.Y -= 15;
                }
                if (jumpSpeed >= 16 && jumpSpeed <= 18)
                {
                    location.Y -= 12;
                }
                if (jumpSpeed >= 19 && jumpSpeed <= 21)
                {
                    location.Y -= 9;
                }
                if (jumpSpeed >= 22 && jumpSpeed <= 24)
                {
                    location.Y -= 5;
                }
                if (jumpSpeed >= 25 && jumpSpeed <= 27)
                {
                    location.Y -= 2;
                }
                if (jumpSpeed == 28)
                {
                    jumpSpeed = 0;
                    jumping = false;
                    allowJump = false;
                }
                jumpSpeed++;
            }
            else
            {
                if (!Collision.checkPlayerLevelCollision().Contains("Bottom"))
                {
                    if (jumpSpeed >= 0 && jumpSpeed <= 2)
                    {
                        location.Y += 2;
                    }

                    if (jumpSpeed >= 3 && jumpSpeed <= 5)
                    {
                        location.Y += 5;
                    }

                    if (jumpSpeed >= 6 && jumpSpeed <= 8)
                    {
                        location.Y += 9;
                    }

                    if (jumpSpeed >= 9 && jumpSpeed <= 11)
                    {
                        location.Y += 12;
                    }

                    if (jumpSpeed > 11)
                    {
                        location.Y += 15;
                    }
                    jumpSpeed++;
                }
                else
                {
                    allowJump = true;
                    jumpSpeed = 0;
                }
            }
        }

        public void moveRight()
        {
            if (!locked)
            {
                if (!Collision.checkPlayerLevelCollision().Contains("Right"))
                {
                    for (int i = 0; i < level.aantalLagen[level.currentLevel]; i++)
                    {
                        for (int y = 0; y < level.aantalVlakken[level.currentLevel, i]; y++)
                        {
                            level.levelSegmentPos[i, y].X -= level.levelSegmentSpeed[i];
                        }
                    }
                    for (int i = 0; i < level.levelRec.Length; i++)
                    {
                        level.levelRec[i].X -= level.levelSegmentSpeed[level.voorgrondLaag];
                    }

                    for (int i = 0; i < level.eventRec.Length; i++)
                    {
                        level.eventRec[i].X -= level.levelSegmentSpeed[level.voorgrondLaag];
                    }

                    locationLevel += (level.levelSegmentSpeed[level.voorgrondLaag]);
                }
            }
            else
            {
                if (!Collision.checkPlayerLevelCollision().Contains("Right"))
                {
                    if (location.X < GlobalVars.resolutionWidth - animation.playerTex.Width)
                    {
                        location.X += (level.levelSegmentSpeed[level.voorgrondLaag]);
                    }
                }
            }
        }

        public void moveLeft()
        {
            if (locationLevel > 0)
            {
                if (!locked)
                {
                    if (!Collision.checkPlayerLevelCollision().Contains("Left"))
                    {
                        for (int i = 0; i < level.aantalLagen[level.currentLevel]; i++)
                        {
                            for (int y = 0; y < level.aantalVlakken[level.currentLevel, i]; y++)
                            {
                                level.levelSegmentPos[i, y].X += level.levelSegmentSpeed[i];
                            }
                        }
                        for (int i = 0; i < level.levelRec.Length; i++)
                        {
                            level.levelRec[i].X += level.levelSegmentSpeed[level.voorgrondLaag];
                        }

                        for (int i = 0; i < level.eventRec.Length; i++)
                        {
                            level.eventRec[i].X += level.levelSegmentSpeed[level.voorgrondLaag];
                        }


                        locationLevel -= (level.levelSegmentSpeed[level.voorgrondLaag]);
                    }
                }
                else
                {
                    if (!Collision.checkPlayerLevelCollision().Contains("Left"))
                    {
                        if (location.X > 0)
                        {
                            location.X -= (level.levelSegmentSpeed[level.voorgrondLaag]);
                        }
                    }
                }
            } 
        }

        public bool moveToEnd()
        {
            locked = true;
            if (location.X < GlobalVars.resolutionWidth)
            {
                location.X += (level.levelSegmentSpeed[level.voorgrondLaag]);
                return false;
            }
            else
            {
                location.X = center;
                location.Y = 0;
                return true;
            }
        }

        public bool endOfLevel()
        {
            if (locationLevel >= level.totalWidth - GlobalVars.resolutionWidth)
            {
                return true;
            }
            return false;
        }

        public void unlockLevel()
        {
            locked = false;
        }

        public void lockLevel()
        {
            locked = true;
        }

        public bool moveToCenter()
        {
                if (location.X > center)
                {
                    location.X -= (level.levelSegmentSpeed[level.voorgrondLaag]);

                    for (int i = 0; i < level.aantalLagen[level.currentLevel]; i++)
                    {
                        for (int y = 0; y < level.aantalVlakken[level.currentLevel, i]; y++)
                        {
                            level.levelSegmentPos[i, y].X -= level.levelSegmentSpeed[i];
                        }
                    }
                    for (int i = 0; i < level.levelRec.Length; i++)
                    {
                        level.levelRec[i].X -= level.levelSegmentSpeed[level.voorgrondLaag];
                    }

                    locationLevel += (level.levelSegmentSpeed[level.voorgrondLaag]);
                }

                if (location.X < center)
                {
                    location.X += (level.levelSegmentSpeed[level.voorgrondLaag]);

                    for (int i = 0; i < level.aantalLagen[level.currentLevel]; i++)
                    {
                        for (int y = 0; y < level.aantalVlakken[level.currentLevel, i]; y++)
                        {
                            level.levelSegmentPos[i, y].X += level.levelSegmentSpeed[i];
                        }
                    }
                    for (int i = 0; i < level.levelRec.Length; i++)
                    {
                        level.levelRec[i].X += level.levelSegmentSpeed[level.voorgrondLaag];
                    }
                    locationLevel -= (level.levelSegmentSpeed[level.voorgrondLaag]);
                }

                if (location.X == center)
                {
                    return true;
                }
                return false;   
        }
    }
}
