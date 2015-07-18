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

namespace TopSecret2
{
    class Menu
    {
      
        public MenuOpties huidigeMenuOpties;
        private Texture2D[] achtergrond;
        private Texture2D[] knoppen;
        private Texture2D[] tutorial;

        public enum MenuOpties
        {
            MainMenuStart,
            MainMenuHighscores,
            CharacterMenuSimon,
            CharacterMenuTerug,
            MoeilijkheidsMenuTerug,
            MoeilijkheidsMenuEasy,
            MoeilijkheidsMenuMedium,
            MoeilijkheidsMenuHard
        }

        private int center = GlobalVars.resolutionWidth / 2;
        private int hoogte = GlobalVars.resolutionHeight;
        private int breedte = GlobalVars.resolutionWidth;

        public Menu(ContentManager content)
        {
            knoppen = new Texture2D[15];
            achtergrond = new Texture2D[3];
            huidigeMenuOpties = MenuOpties.MainMenuStart;
            LoadMenu(content);
            tutorial = new Texture2D[2];
        }

        public void LoadMenu(ContentManager content)
        {
            achtergrond[0] = content.Load<Texture2D>(@"Menu/Achtergrond/0");
            achtergrond[1] = content.Load<Texture2D>(@"Menu/Achtergrond/1");
            achtergrond[2] = content.Load<Texture2D>(@"Menu/Achtergrond/2");
            achtergrond[3] = content.Load<Texture2D>(@"Menu/Achtergrond/3");
            achtergrond[4] = content.Load<Texture2D>(@"Menu/Achtergrond/4");
            for (int i = 0; i < 15; i++)
            {
                knoppen[i] = content.Load<Texture2D>(@"Menu/Knoppen/" + Convert.ToString(i));
            }
        }

        public void DrawMainMenu(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(achtergrond[0], new Vector2(0, 0), Color.White);
            if (huidigeMenuOpties == MenuOpties.MainMenuStart)
            {
                sprite.Draw(knoppen[1], new Vector2(center - knoppen[1].Width / 2 , 300), Color.White);
                sprite.Draw(knoppen[2], new Vector2(center - knoppen[2].Width / 2, 480), Color.White);
            }

            if (huidigeMenuOpties == MenuOpties.MainMenuHighscores)
            {
                sprite.Draw(knoppen[0], new Vector2(center - knoppen[0].Width / 2, 300), Color.White);
                sprite.Draw(knoppen[3], new Vector2(center - knoppen[3].Width / 2, 480), Color.White);
            }
            sprite.End();
        }

        public void DrawCharacterMenu(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(achtergrond[0], new Vector2(0, 0), Color.White);
            if (huidigeMenuOpties == MenuOpties.CharacterMenuSimon)
            {
                sprite.Draw(knoppen[14], new Vector2(116, 270), Color.White);
                             
                sprite.Draw(knoppen[6], new Vector2(0, hoogte - knoppen[6].Height), Color.White);
            }
            if (huidigeMenuOpties == MenuOpties.CharacterMenuTerug)
            {
                sprite.Draw(knoppen[14], new Vector2(116, 270), Color.White);
                sprite.Draw(knoppen[7], new Vector2(0, hoogte - knoppen[7].Height), Color.White);
            }
            sprite.End();
        }

        public void DrawMoeilijkheidsMenu(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(achtergrond[0], new Vector2(0, 0), Color.White);
            if (huidigeMenuOpties == MenuOpties.MoeilijkheidsMenuEasy)
            {
                sprite.Draw(knoppen[9], new Vector2(center - knoppen[0].Width / 2, 220), Color.White);
                sprite.Draw(knoppen[10], new Vector2(center - knoppen[0].Width / 2, 400), Color.White);
                sprite.Draw(knoppen[12], new Vector2(center - knoppen[0].Width / 2, 580), Color.White);
                sprite.Draw(knoppen[6], new Vector2(0 , hoogte - knoppen[6].Height), Color.White);
            }
            if (huidigeMenuOpties == MenuOpties.MoeilijkheidsMenuMedium)
            {
                sprite.Draw(knoppen[8], new Vector2(center - knoppen[0].Width / 2, 220), Color.White);
                sprite.Draw(knoppen[11], new Vector2(center - knoppen[0].Width / 2, 400), Color.White);
                sprite.Draw(knoppen[12], new Vector2(center - knoppen[0].Width / 2, 580), Color.White);
                sprite.Draw(knoppen[6], new Vector2(0, hoogte - knoppen[6].Height), Color.White);
            }
            if (huidigeMenuOpties == MenuOpties.MoeilijkheidsMenuHard)
            {
                sprite.Draw(knoppen[8], new Vector2(center - knoppen[0].Width / 2, 220), Color.White);
                sprite.Draw(knoppen[10], new Vector2(center - knoppen[0].Width / 2, 400), Color.White);
                sprite.Draw(knoppen[13], new Vector2(center - knoppen[0].Width / 2, 580), Color.White);
                sprite.Draw(knoppen[6], new Vector2(0, hoogte - knoppen[6].Height), Color.White);
            }
            if (huidigeMenuOpties == MenuOpties.MoeilijkheidsMenuTerug)
            {
                sprite.Draw(knoppen[8], new Vector2(center - knoppen[0].Width / 2, 220), Color.White);
                sprite.Draw(knoppen[10], new Vector2(center - knoppen[0].Width / 2, 400), Color.White);
                sprite.Draw(knoppen[12], new Vector2(center - knoppen[0].Width / 2, 580), Color.White);
                sprite.Draw(knoppen[7], new Vector2(0, hoogte - knoppen[6].Height), Color.White);
            }
            sprite.End();
        }

        public void DrawTurorialMenu(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(achtergrond[0], new Vector2(0, 0), Color.White);
            sprite.Draw(achtergrond[1], new Vector2(360,300), Color.White);
            sprite.End();
        }

        public void DrawLoadingScreen(SpriteBatch sprite, Level level)
        {
            sprite.Begin();
            if (level.currentLevel == 0)
            {
                sprite.Draw(achtergrond[2], new Vector2(0, 0), Color.White);
            }

            if (level.currentLevel == 1)
            {
                sprite.Draw(achtergrond[3], new Vector2(0, 0), Color.White);
            }

            if (level.currentLevel == 2)
            {
                sprite.Draw(achtergrond[4], new Vector2(0, 0), Color.White);
            }
            sprite.End();
        }

        public void DrawHighScoreMenu(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(achtergrond[0], new Vector2(0, 0), Color.White);
            sprite.Draw(knoppen[7], new Vector2(0, hoogte - knoppen[6].Height), Color.White);
            sprite.End();
        }

        public void DrawHighScoreInvullen(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(achtergrond[0], new Vector2(0, 0), Color.White);
            sprite.Draw(knoppen[7], new Vector2(0, hoogte - knoppen[6].Height), Color.White);
            sprite.End();
        }
    }
}
