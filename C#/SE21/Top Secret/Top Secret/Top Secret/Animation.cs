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
    class Animation
    {
        public Texture2D playerTex;
        public Player player;
        ContentManager content;
        SpriteBatch sprite;
        

        public Animation(ContentManager Content, SpriteBatch Sprite)
        {
            sprite = Sprite;
            content = Content;
        }

        public void loadPlayer()
        {
            playerTex = this.content.Load<Texture2D>(@"Animations/Player/player");
        }

        public void DrawPlayer()
        {
            sprite.Begin();
            sprite.Draw(playerTex, player.location, Color.White);
            sprite.End();
        }
    }
}
