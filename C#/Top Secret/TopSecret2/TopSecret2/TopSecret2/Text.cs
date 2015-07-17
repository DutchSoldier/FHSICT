using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TopSecret2
{
    class Text
    {
        private float size = 1.5f;
        private Color color = Color.White;

        public Color Color { get { return color; } set { color = value; } }
        public float Size { get { return size; } set { size = value; } }

        public void DrawText(float x, float y, String tekst, SpriteFont font, SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.DrawString(font, tekst, new Vector2(x, y), color, 0f, new Vector2(), size, SpriteEffects.None, 1f);
            sprite.End();
        }
    }
}
