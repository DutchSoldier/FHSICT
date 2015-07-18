using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TopSecret2
{
    class PlayerAnimations
    {
        TimeSpan nextFrameInterval = TimeSpan.FromSeconds(1.0f / 6);
        TimeSpan nextFrame = TimeSpan.FromSeconds(1);

        public int currentframe { get; private set; }
        public Texture2D[] playerTex { get; private set; }

        public enum TopAnimiationState
        {
            Attack1,
            Attack2,
            Attack3,
            Attack4,
            Idle
        }

        public enum BottomAnimationState
        {
            Walking,
            Jumping,
            Idle
        }

        public TopAnimiationState TopState;
        public BottomAnimationState BotState;

        public PlayerAnimations(ContentManager Content)
        {
            playerTex = new Texture2D[3];

            playerTex[0] = Content.Load<Texture2D>(@"Player/0");
            playerTex[1] = Content.Load<Texture2D>(@"Player/1");
            playerTex[2] = Content.Load<Texture2D>(@"Player/2");
        }

        public void Moving(GameTime gameTime)
        {
            if (nextFrame >= nextFrameInterval)
            {
                if (currentframe >= 0 && currentframe < 2)
                {
                    currentframe++;
                }
                else
                {
                    currentframe = 0;
                }
                nextFrame = TimeSpan.Zero;
            }
            else
            {
                nextFrame += gameTime.ElapsedGameTime;
            }
        }

        public void Idle()
        {
            currentframe = 0;
        }

        public void DrawPlayer(SpriteBatch sprite, Player player)
        {
            sprite.Begin();
            sprite.Draw(playerTex[currentframe], player.location , Color.White);
            sprite.End();
        }

    }
}
