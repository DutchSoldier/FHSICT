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

namespace Top_Secret
{
    class Menu
    {
        private ContentManager content;
        private SpriteBatch sprite;
        private Text text;
        private Texture2D achtergrond;
        private Texture2D knopHighscore;
        private Texture2D knopStart;
        private Texture2D achtergrond2;
        private Texture2D knopKies;
        private Texture2D knopTerug;
        public bool scoreLoaded;
        private Texture2D knopKiesHilite;
        private Texture2D knopTerugHilite;
        private Texture2D knopStartHilite;
        private Texture2D knopHighscoreHilite;
        KeyboardState newkeyboardState;
        KeyboardState oldkeyboardState;


        public Menu(ContentManager Content, SpriteBatch SpriteBatch, Text Text)
        {
            content = Content;
            sprite = SpriteBatch;
            text = Text;
            scoreLoaded = false;
        }

        public void loadMainMenu()
        {
            knopHighscore = this.content.Load<Texture2D>(@"Menu/Knoppen/HighScores");
            knopStart = this.content.Load<Texture2D>(@"Menu/Knoppen/Start");
            achtergrond = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
        }

        public void drawMainMenu()
        {
            sprite.Begin();
            sprite.Draw(achtergrond, new Vector2(0, 0), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopStart, new Vector2(578, 360), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopHighscore, new Vector2(578, 470), Color.White);
            sprite.End();

        }

        public void loadCaracterMenu()
        {
            achtergrond2 = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
            knopKies = this.content.Load<Texture2D>(@"Menu/Knoppen/Start");
            knopTerug = this.content.Load<Texture2D>(@"Menu/Knoppen/HighScores");
        }

        public void drawCaracterMenu()
        {
            sprite.Begin();
            sprite.Draw(achtergrond2, new Vector2(0, 0), Color.Blue);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopKies, new Vector2(578, 360), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopTerug, new Vector2(578, 470), Color.White);
            sprite.End();
        }

        public void loadLevelScore()
        {
            if (!scoreLoaded)
            {
                achtergrond = this.content.Load<Texture2D>(@"Menu/levelScore/0");
            }
        }

        public void drawLevelScore()
        {
            sprite.Begin();
            sprite.Draw(achtergrond, new Vector2(0, 0), Color.Red);
            sprite.End();
        }

    }
}
