using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Top_Secret
{
    class PlayerAnimation
    {
        private ContentManager content;
        private SpriteBatch sprite;
        public Player player;

        System.Xml.Linq.XDocument spriteSheetData;


        public Point frameSizeIdle;
       
        public Texture2D playerTex { get; private set; }
        
        public PlayerAnimation(ContentManager Content, SpriteBatch Sprite, string CharacterName)
        {
            sprite = Sprite;
            content = Content;

            spriteSheetData = System.Xml.Linq.XDocument.Load("Content/Animations/Player/" + CharacterName + ".xml");
            playerTex = content.Load<Texture2D>(@"Animations/Player/" + CharacterName + "Sheet");

            var idle = spriteSheetData.Root.Element("idle");

            frameSizeIdle = new Point();
            frameSizeIdle.X = int.Parse(idle.Attribute("FrameWidth").Value, NumberStyles.Integer);
            frameSizeIdle.Y = int.Parse(idle.Attribute("FrameHeight").Value, NumberStyles.Integer);
        }

        public void DrawPlayer()
        {
            sprite.Begin();
            sprite.Draw(playerTex, player.location, new Rectangle(
                  0,
                  0,
                  frameSizeIdle.X,
                  frameSizeIdle.Y),
                  Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0);
            sprite.End();
        }   
    }
}
