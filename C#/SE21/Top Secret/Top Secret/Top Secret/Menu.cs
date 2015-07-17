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
        private Texture2D knopHard;
        private Texture2D knopHardHilite;
        private Texture2D knopEasy;
        private Texture2D knopEasyHilite;
        private Texture2D knopMedium;
        private Texture2D knopMediumHilite;
        int x = GlobalVars.resolutionWidth/2;
        int y = GlobalVars.resolutionHeight;

        public Menu(ContentManager Content, SpriteBatch SpriteBatch, Text Text)
        {
            content = Content;
            sprite = SpriteBatch;
            text = Text;
            scoreLoaded = false;
        }

        public void loadMainMenuStart()
        {
            knopHighscore = this.content.Load<Texture2D>(@"Menu/Knoppen/High_Blank");
            knopStartHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Start_Selected");
            achtergrond = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
        }

        public void drawMainMenuStart()
        {
           sprite.Begin();
           sprite.Draw(achtergrond, new Vector2(0,0), Color.White);
           sprite.End();

           sprite.Begin();
           sprite.Draw(knopStartHilite, new Vector2(x - 329 / 2, 300), Color.White);
           sprite.End();
          
           sprite.Begin();
           sprite.Draw(knopHighscore, new Vector2(x - 329 / 2, 480), Color.White);
           sprite.End();

        }
        
        public void loadMainMenuHighscore()
        {
            knopHighscoreHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/High_Selected");
            knopStart = this.content.Load<Texture2D>(@"Menu/Knoppen/Start_Blank");
            achtergrond = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
        }

        public void drawMainMenuHighscore()
        {
            sprite.Begin();
            sprite.Draw(achtergrond, new Vector2(0, 0), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopStart, new Vector2(x - 329 / 2, 300), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopHighscoreHilite, new Vector2(x - 329 / 2, 480), Color.White);
            sprite.End();

        }

        public void loadCaracterMenuKies()
        {
            achtergrond2 = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
            knopKiesHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Kies_Selected");
            knopTerug = this.content.Load<Texture2D>(@"Menu/Knoppen/Back_Blank");
        }

        public void drawCaracterMenuKies()
        {
            sprite.Begin();
            sprite.Draw(achtergrond2, new Vector2(0, 0), Color.Blue);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopKiesHilite, new Vector2(1111, y - 180), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopTerug, new Vector2(0, y - 180), Color.White);
            sprite.End();
        }

        public void loadCaracterMenuTerug()
        {
            achtergrond2 = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
            knopKies = this.content.Load<Texture2D>(@"Menu/Knoppen/Kies_Blank");
            knopTerugHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Back_Selected");
        }

        public void drawCaracterMenuTerug()
        {
            sprite.Begin();
            sprite.Draw(achtergrond2, new Vector2(0, 0), Color.Blue);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopKies, new Vector2(1111, y - 180), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopTerugHilite, new Vector2(0, y - 180), Color.White);
            sprite.End();
        }

        public void loadHighscoreMenuTerug()
        {
            achtergrond2 = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
            knopTerugHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Back_Selected");
        }

        public void drawHighscoreMenuTerug()
        {
            sprite.Begin();
            sprite.Draw(achtergrond2, new Vector2(0, 0), Color.Blue);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopTerugHilite, new Vector2(1111, y - 180), Color.White);
            sprite.End();
        }

        public void loadMoeilijkheidMenuKiesEasy()
        {
            knopEasyHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Easy_Selected");
            knopKiesHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Kies_Selected");
            achtergrond = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
            knopHard = this.content.Load<Texture2D>(@"Menu/Knoppen/Hard_Blank");
            knopMedium = this.content.Load<Texture2D>(@"Menu/Knoppen/Medium_Blank");
            knopTerug = this.content.Load<Texture2D>(@"Menu/Knoppen/Back_Blank");

        }

        public void drawMoeilijkheidMenuKiesEasy()
        {
            sprite.Begin();
            sprite.Draw(achtergrond, new Vector2(0, 0), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopKiesHilite, new Vector2(1111, y - 180), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopEasyHilite, new Vector2(x - 329 / 2, 220), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopMedium, new Vector2(x - 329 / 2, 400), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopHard, new Vector2(x - 329 / 2, 580), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopTerug, new Vector2(0, y - 180), Color.White);
            sprite.End();
        }

        public void loadMoeilijkheidMenuKiesMedium()
        {
            knopEasy = this.content.Load<Texture2D>(@"Menu/Knoppen/Easy_Blank");
            knopKiesHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Kies_Selected");
            achtergrond = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
            knopHard = this.content.Load<Texture2D>(@"Menu/Knoppen/Hard_Blank");
            knopMediumHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Medium_Selected");
            knopTerug = this.content.Load<Texture2D>(@"Menu/Knoppen/Back_Blank");
        }

        public void drawMoeilijkheidMenuKiesMedium()
        {
            sprite.Begin();
            sprite.Draw(achtergrond, new Vector2(0, 0), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopKiesHilite, new Vector2(1111, y - 180), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopEasy, new Vector2(x - 329 / 2, 220), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopMediumHilite, new Vector2(x - 329 / 2, 400), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopHard, new Vector2(x - 329 / 2, 580), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopTerug, new Vector2(0, y - 180), Color.White);
            sprite.End();

        }

        public void loadMoeilijkheidMenuKiesHard()
        {
            knopEasy = this.content.Load<Texture2D>(@"Menu/Knoppen/Easy_Blank");
            knopKiesHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Kies_Selected");
            achtergrond = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
            knopHardHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Hard_Selected");
            knopMedium = this.content.Load<Texture2D>(@"Menu/Knoppen/Medium_Blank");
            knopTerug = this.content.Load<Texture2D>(@"Menu/Knoppen/Back_Blank");
        }

        public void drawMoeilijkheidMenuKiesHard()
        {
            sprite.Begin();
            sprite.Draw(achtergrond, new Vector2(0, 0), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopKiesHilite, new Vector2(1111, y - 180), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopEasy, new Vector2(x - 329 / 2, 220), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopMedium, new Vector2(x - 329 / 2, 400), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopHardHilite, new Vector2(x - 329 / 2, 580), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopTerug, new Vector2(0, y - 180), Color.White);
            sprite.End();

        }

        public void loadMoeilijkheidMenuTerugEasy()
        {
            knopEasyHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Easy_Selected");
            knopKies = this.content.Load<Texture2D>(@"Menu/Knoppen/Kies_Blank");
            achtergrond = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
            knopHard = this.content.Load<Texture2D>(@"Menu/Knoppen/Hard_Blank");
            knopMedium = this.content.Load<Texture2D>(@"Menu/Knoppen/Medium_Blank");
            knopTerugHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Back_Selected");
        }

        public void drawMoeilijkheidMenuTerugEasy()
        {
            sprite.Begin();
            sprite.Draw(achtergrond, new Vector2(0, 0), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopKies, new Vector2(1111, y - 180), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopEasyHilite, new Vector2(x - 329 / 2, 220), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopMedium, new Vector2(x - 329 / 2, 400), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopHard, new Vector2(x - 329 / 2, 580), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopTerugHilite, new Vector2(0, y - 180), Color.White);
            sprite.End();

        }

        public void loadMoeilijkheidMenuTerugMedium()
        {
            knopEasy = this.content.Load<Texture2D>(@"Menu/Knoppen/Easy_Blank");
            knopKies = this.content.Load<Texture2D>(@"Menu/Knoppen/Kies_Blank");
            achtergrond = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
            knopHard = this.content.Load<Texture2D>(@"Menu/Knoppen/Hard_Blank");
            knopMediumHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Medium_Selected");
            knopTerugHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Back_Selected");
        }

        public void drawMoeilijkheidMenuTerugMedium()
        {
            sprite.Begin();
            sprite.Draw(achtergrond, new Vector2(0, 0), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopKies, new Vector2(1111, y - 180), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopEasy, new Vector2(x - 329 / 2, 220), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopMediumHilite, new Vector2(x - 329 / 2, 400), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopHard, new Vector2(x - 329 / 2, 580), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopTerugHilite, new Vector2(0, y - 180), Color.White);
            sprite.End();
            
        }

        public void loadMoeilijkheidMenuTerugHard()
        {
            knopEasy = this.content.Load<Texture2D>(@"Menu/Knoppen/Easy_Blank");
            knopKies = this.content.Load<Texture2D>(@"Menu/Knoppen/Kies_Blank");
            achtergrond = this.content.Load<Texture2D>(@"Menu/Achtergrond/0");
            knopHardHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Hard_Selected");
            knopMedium = this.content.Load<Texture2D>(@"Menu/Knoppen/Medium_Blank");
            knopTerugHilite = this.content.Load<Texture2D>(@"Menu/Knoppen/Back_Selected");
        }

        public void drawMoeilijkheidMenuTerugHard()
        {
            sprite.Begin();
            sprite.Draw(achtergrond, new Vector2(0, 0), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopKies, new Vector2(1111, y - 180), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopEasy, new Vector2(x - 329 / 2, 220), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopMedium, new Vector2(x - 329 / 2, 400), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopHardHilite, new Vector2(x - 329 / 2, 580), Color.White);
            sprite.End();

            sprite.Begin();
            sprite.Draw(knopTerugHilite, new Vector2(0, y - 180), Color.White);
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
