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
    class Text
    {
        private float size = 1f;
        private Color color = Color.White;

        public Color Color { get { return color; } set { color = value; }}
        public float Size { get { return size; } set { size = value; }}

        SpriteFont font;
        SpriteBatch sprite;

        public Text(SpriteFont Font, SpriteBatch Sprite)
        {
            font = Font;
            sprite = Sprite;
        }

        public void DrawText(float x, float y, String tekst)
        {
            sprite.Begin();
            sprite.DrawString(font, tekst, new Vector2(x,y), color, 0f, new Vector2(),size, SpriteEffects.None, 1f);
            sprite.End();
        }

        public bool DrawClickText(float x, float y, String tekst, int mosX, int mosY, bool mouseClick)
        {
            bool r = false;

            if (mosX > x && mosY > y && mosX < x + font.MeasureString(tekst).X * size && mosY < y + font.MeasureString(tekst).Y * size)
            {
                if (mouseClick)
                {
                    r = true;
                }   
            }
            DrawText(x, y, tekst);

            return r;
        }

    }
}
