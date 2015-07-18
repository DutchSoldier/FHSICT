using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace TopSecret2
{
    class Level
    {
        private Vector2[,] levelSegmentPos;
        private Texture2D[,] levelSegment;
        private Texture2D[] objecten;
        private int[] levelSegmentSpeed;
        private int[,] aantalVlakken;
        private int[] aantalLagen;
        public bool levelLoaded;

        public List<Rectangle> levelRec { get; private set; }
        public List<Rectangle> eventRec { get; private set; }
        public List<Rectangle> objectRec { get; private set; }
        public List<Rectangle> damageRec { get; private set; }
        public int aantalLevels { get; private set; }
        public int currentLevel { get; private set; }
        public int totalWidth { get; private set; }
        public int location { get; private set; }

        public Level(ContentManager Content)
        {
            currentLevel = 0;
            levelLoaded = false;

            levelRec = new List<Rectangle>();
            eventRec = new List<Rectangle>();
            damageRec = new List<Rectangle>();
            objectRec = new List<Rectangle>();

            int maxAantalLagen = 0;
            int maxAantalVlakken = 0;

            aantalLevels = Directory.GetDirectories(@"Content/Levels/").Length;
            aantalLagen = new int[aantalLevels];

            for (int i = 0; i < aantalLevels; i++)
            {
                aantalLagen[i] = Directory.GetDirectories(@"Content/Levels/Level" + Convert.ToString(i)).Length;
                if (maxAantalLagen < aantalLagen[i])
                {
                    maxAantalLagen = aantalLagen[i];
                }
            }
            aantalVlakken = new int[aantalLevels, maxAantalLagen];

            for (int i = 0; i < aantalLevels; i++)
            {
                for (int y = 0; y < aantalLagen[i]; y++)
                {
                    aantalVlakken[i, y] = Directory.GetFiles(@"Content/Levels/Level" + Convert.ToString(i) + "/" + "Laag" + Convert.ToString(y)).Length;
                    if (maxAantalVlakken < aantalVlakken[i, y])
                    {
                        maxAantalVlakken = aantalVlakken[i, y];
                    }
                }
            }

            objecten = new Texture2D[Directory.GetFiles(@"Content/Objecten").Length];
            levelSegment = new Texture2D[maxAantalLagen, maxAantalVlakken];
            levelSegmentPos = new Vector2[maxAantalLagen, maxAantalVlakken];
            levelSegmentSpeed = new int[maxAantalLagen];
            LoadLevel(Content);
        }

        public void LoadLevel(ContentManager Content)
        {
            if (!levelLoaded)
            {
                float positieVorigSegmentX = 0f;
                float breedteVorigSegment = 0f;
                totalWidth = 0;
                location = 0;

                for (int i = 0; i < aantalLagen[currentLevel]; i++)
                {
                    for (int y = 0; y < aantalVlakken[currentLevel, i]; y++)
                    {
                        levelSegment[i, y] = Content.Load<Texture2D>(@"Levels/Level" + Convert.ToString(currentLevel) + "/" + "Laag" + Convert.ToString(i) + "/" + Convert.ToString(y));

                        if (i == aantalLagen[currentLevel] - 1)
                        {
                            totalWidth += levelSegment[i, y].Width;
                        }
                    }
                }

                for (int i = 0; i < aantalLagen[currentLevel]; i++)
                {
                    for (int y = 0; y < aantalVlakken[currentLevel, i]; y++)
                    {
                        levelSegmentPos[i, y].X = positieVorigSegmentX + breedteVorigSegment;
                        levelSegmentPos[i, y].Y = 0;

                        positieVorigSegmentX = levelSegmentPos[i, y].X;
                        breedteVorigSegment = levelSegment[i, y].Width;
                    }
                    positieVorigSegmentX = 0;
                    breedteVorigSegment = 0;
                }

                for (int i = 0; i < objecten.Length; i++)
                {
                    objecten[i] = Content.Load<Texture2D>(@"Objecten/" + Convert.ToString(i));
                }
                SetLevelSpeed();
                SetLevelCollision();
                SetEventCollision();
                SetDamageCollision();
                SetObjectCollision();
            }
            levelLoaded = true;
        }

        private void SetLevelCollision()
        {
            levelRec.Clear();
            if (currentLevel == 0)
            {
                levelRec.Add(new Rectangle(0, 980, 10000, 10));

                levelRec.Add(new Rectangle(1995, 874, 168, 130));
                levelRec.Add(new Rectangle(2127, 796, 105, 120));
                levelRec.Add(new Rectangle(2573, 675, 120, 284));

                levelRec.Add(new Rectangle(6513, 847, 40, 28));
                levelRec.Add(new Rectangle(6850, 743, 36, 28));
                levelRec.Add(new Rectangle(7191, 749, 36, 26));
            }

            if (currentLevel == 1)
            {
                levelRec.Add(new Rectangle(0, 800, 10000, 10));

                levelRec.Add(new Rectangle(1995, 687, 168, 130));
                levelRec.Add(new Rectangle(2127, 609, 105, 120));
                levelRec.Add(new Rectangle(2573, 480, 120, 284));

                levelRec.Add(new Rectangle(6513, 665, 40, 28));
                levelRec.Add(new Rectangle(6850, 560, 36, 28));
                levelRec.Add(new Rectangle(7191, 563, 36, 26));
            }
        }

        private void SetEventCollision()
        {
            eventRec.Clear();
            if (currentLevel == 0)
            {
                eventRec.Add(new Rectangle(1400, 0, 1, 1080));
                eventRec.Add(new Rectangle(1640, 0, 102, 1080));
            }

            if (currentLevel == 1)
            {
                eventRec.Add(new Rectangle(1604, 760, 100, 86));
                eventRec.Add(new Rectangle(1640, 678, 102, 76));
            }
        }

        private void SetDamageCollision()
        {
            damageRec.Clear();
            if (currentLevel == 0)
            {
                damageRec.Add(new Rectangle(1604, 896, 137, 147));
                damageRec.Add(new Rectangle(2311, 838, 155, 166));
                damageRec.Add(new Rectangle(2763, 842, 154, 144));
                damageRec.Add(new Rectangle(6604, 922, 138, 144));
                damageRec.Add(new Rectangle(6912, 908, 155, 170));
                damageRec.Add(new Rectangle(7270, 912, 272, 148));
            }

            if (currentLevel == 1)
            {
                damageRec.Add(new Rectangle(1604, 747, 137, 147));
                damageRec.Add(new Rectangle(2311, 650, 155, 166));
                damageRec.Add(new Rectangle(2763, 655, 154, 144));
            }
        }

        private void SetObjectCollision()
        {
            objectRec.Clear();
            if (currentLevel == 0)
            {
                objectRec.Add(new Rectangle(3038, 880, 163, 117));
                objectRec.Add(new Rectangle(7651, 918, 174, 127));
            }
        }

        private void SetLevelSpeed()
        {
            levelSegmentSpeed[aantalLagen[currentLevel] - 1] = GlobalVars.playerSpeed;
            if (currentLevel == 0)
            {
                levelSegmentSpeed[0] = 1;
                levelSegmentSpeed[1] = 3;
            }
        }

        public void MoveLevel(int direction)
        {
            for (int i = 0; i < aantalLagen[currentLevel]; i++)
            {
                for (int y = 0; y < aantalVlakken[currentLevel, i]; y++)
                {
                    levelSegmentPos[i, y].X -= levelSegmentSpeed[i] * direction;
                }
            }

            for (int i = 0; i < levelRec.Count; i++)
            {
                Rectangle r = levelRec[i];
                r.X -= GlobalVars.playerSpeed * direction;
                levelRec[i] = r;
            }

            for (int i = 0; i < eventRec.Count; i++)
            {
                Rectangle r = eventRec[i];
                r.X -= GlobalVars.playerSpeed * direction;
                eventRec[i] = r;
            }

            for (int i = 0; i < damageRec.Count; i++)
            {
                Rectangle r = damageRec[i];
                r.X -= GlobalVars.playerSpeed * direction;
                damageRec[i] = r;
            }

            for (int i = 0; i < objectRec.Count; i++)
            {
                Rectangle r = objectRec[i];
                r.X -= GlobalVars.playerSpeed * direction;
                objectRec[i] = r;
            }
            location += (GlobalVars.playerSpeed * direction);
        }

        public bool EndOfLevel()
        {
            if (location >= (totalWidth - GlobalVars.resolutionWidth))
            {
                return true;
            }
            return false;
        }

        public void NextLevel(ContentManager Content, Menu menu)
        {
            if (currentLevel < aantalLevels - 1)
            {
                currentLevel += 1;
                GlobalVars.currentState = GlobalVars.gameState.normalLevel;
            }
            else
            {
                currentLevel = 0;
                GlobalVars.currentState = GlobalVars.gameState.highScoreInvullen;
                menu.huidigeMenuOpties = Menu.MenuOpties.MainMenuStart;
            }
            levelLoaded = false;
            LoadLevel(Content);
        }

        public void DrawLevel(SpriteBatch sprite)
        {
            sprite.Begin();
            for (int i = 0; i < aantalLagen[currentLevel]; i++)
            {
                for (int y = 0; y < aantalVlakken[currentLevel, i]; y++)
                {
                    sprite.Draw(levelSegment[i, y], levelSegmentPos[i, y], Color.White);

                }
            }
            for (int i = 0; i < objectRec.Count; i++)
            {
                sprite.Draw(objecten[0], objectRec[i], Color.White);
            }
            sprite.End();
        }
    }
}

