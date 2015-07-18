using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Top_Secret
{
    class Level
    {
        private ContentManager content;
        private SpriteBatch sprite;
        public Player player;

        private Texture2D[,] levelSegment;
        public Vector2[,] levelSegmentPos;       
        public bool levelLoaded;
        private int aantalLevels;
        public Rectangle[] levelRec;
        public Rectangle[] eventRec;

        public int []levelSegmentSpeed { get; private set; }
        public int[] aantalLagen { get; private set; }
        public int[,] aantalVlakken { get; private set; }
        public int voorgrondLaag { get; private set; }
        public float totalWidth { get; private set; }
        public int currentLevel { get; private set; }
        
        public Level(ContentManager Content, SpriteBatch Sprite)
        {
            content = Content;
            sprite = Sprite;
            currentLevel = 0;
            levelLoaded = false;
            
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

            for (int i=  0; i < aantalLevels; i++)
            {
                for (int y = 0; y < aantalLagen[i]; y++)
                {
                    aantalVlakken[i,y] = Directory.GetFiles(@"Content/Levels/Level" + Convert.ToString(i) + "/" + "Laag" + Convert.ToString(y)).Length;
                    if (maxAantalVlakken < aantalVlakken[i,y])
                    {
                        maxAantalVlakken = aantalVlakken[i,y];
                    }
                }
            }
            levelSegment = new Texture2D[maxAantalLagen, maxAantalVlakken];
            levelSegmentPos = new Vector2[maxAantalLagen, maxAantalVlakken];
            levelSegmentSpeed = new int[maxAantalLagen];
        }

        public void loadLevel()
        {
            if (!levelLoaded)
            {
                float positieVorigSegmentX = 0f;
                float positieVorigSegmentY = 0f;
                float breedteVorigSegment = 0f;
                totalWidth = 0;

                voorgrondLaag = aantalLagen[currentLevel] - 1;

                for (int i = 0; i < aantalLagen[currentLevel]; i++)
                {
                    for (int y = 0; y < aantalVlakken[currentLevel, i]; y++)
                    {
                        levelSegment[i, y] = this.content.Load<Texture2D>(@"Levels/Level" + Convert.ToString(currentLevel) + "/" + "Laag" + Convert.ToString(i) + "/" + Convert.ToString(y));

                        if (i == voorgrondLaag)
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
                        levelSegmentPos[i, y].Y = positieVorigSegmentY;

                        positieVorigSegmentX = levelSegmentPos[i, y].X;
                        breedteVorigSegment = levelSegment[i, y].Width;
                    }
                    positieVorigSegmentX = 0;
                    breedteVorigSegment = 0;
                }
                setLevelSpeed();
                setLevelCollision();
            }
            levelLoaded = true;
        }

        public void setLevelCollision()
        {
            if (currentLevel == 0)
            {
                levelRec = new Rectangle[2];
                levelRec[0] =  new Rectangle(0, 800, 10000, 44);
            }
            setEventCollision();
        }

        public void setEventCollision()
        {
            if (currentLevel == 0)
            {
                eventRec = new Rectangle[2];
                eventRec[0] = new Rectangle(1400, 0, 10, 900);
                eventRec[1] = new Rectangle(2800, 0, 10, 900);


            }
        }

        public void setLevelSpeed()
        {
            if (currentLevel == 0)
            {
                levelSegmentSpeed[voorgrondLaag] = 10;
                levelSegmentSpeed[0] = 1;
                levelSegmentSpeed[1] = 3;
            }
        }

        public void drawLevel()
        {
            sprite.Begin();
            for (int i = 0; i < aantalLagen[currentLevel]; i++)
            {
                for (int y = 0; y < aantalVlakken[currentLevel, i]; y++)
                {
                    sprite.Draw(levelSegment[i, y], levelSegmentPos[i, y], Color.White);
                } 
            }
            sprite.End();
        }

        public void nextLevel()
        {
            player.locationLevel = 0;

            if (currentLevel < aantalLevels - 1)
            {
                currentLevel += 1;
                GlobalVars.currentState = GlobalVars.gameState.levelScore;
            }
            else
            {
                currentLevel = 0;
                GlobalVars.currentState = GlobalVars.gameState.mainMenuStart;
            }
            levelLoaded = false;
        }

        public void resetLevel()
        {
            player.locationLevel = 0;
            GlobalVars.currentState = GlobalVars.gameState.levelScore;
        }
    }
}
