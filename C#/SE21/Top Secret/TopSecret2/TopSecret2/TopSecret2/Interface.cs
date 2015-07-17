using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TopSecret2
{
    class Interface
    {
        Texture2D[] interfaceTex;
        private double healthbarWith;

        public Interface(ContentManager Content)
        {
            interfaceTex = new Texture2D[3];
            interfaceTex[0] = Content.Load<Texture2D>(@"Interface/Achtergrond");
            interfaceTex[1] = Content.Load<Texture2D>(@"Interface/Healthbar");
            interfaceTex[2] = Content.Load<Texture2D>(@"Interface/Lijnen");
        }

        public void UpdateInterface(Player player)
        {
            healthbarWith = player.health * 4.38;
        }


        public void DrawInterface(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(interfaceTex[0], new Vector2(-2, 20), Color.White);
            sprite.Draw(interfaceTex[1], new Vector2(-2, 20), new Rectangle(
                0,
                0,
                (int)healthbarWith,
                200),
                Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0);
            sprite.Draw(interfaceTex[2], new Vector2(-2, 20), Color.White);
            sprite.End();
        }

    }
}
