// READ THIS:
// Looking for the NXT code in this file? 
// Do a text search for the string "NXT:"!

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// NXT: Added the line "using NXTMessaging;" 
//      to make the code from the NXTMessaging.dll
//      available in this program file.
using NXTMessaging;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D ballSprite;
        Vector2 ballPosition;
        Vector2 ballSpeed;

        Texture2D paddleSprite;
        Vector2 paddlePosition;

        SoundEffect swishSound;
        SoundEffect crashSound;

        // NXT: nxtMessenger is used to communicate with the Lego NXT
        NXTMessenger nxtMessenger;
        bool robotIsConnectedAndAlive;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ballPosition = Vector2.Zero;
            ballSpeed = new Vector2(150, 150);

            // NXT: Create an NXTMessenger object which you can use to talk to the NXT.
            nxtMessenger = new NXTMessenger();

            // NXT: Connect to the NXT serial port over Bluetooth and beep to confirm
            //      If the program 'hangs' on a call to nxtMessenger.Connect, 
            //      then your NXT is not paired with your PC yet/anymore. 
            //      To pair: Remove the NXT from the Windows Bluetooth device list and add it again.
            robotIsConnectedAndAlive = nxtMessenger.Connect("COM10"); // Hardcoded serial port: put the serial port 
            // of the Bluetooth connection to your NXT here!
            if (robotIsConnectedAndAlive)
            {
                // NXT: Sound a beep on the NXT to confirm you are connected.
                nxtMessenger.Beep();

                // NXT: Enable buffering for reading mailbox 1.
                // Enable read buffering ONLY when needed and ONLY for mailboxes you actually use in your
                // program.
                // In our case we do need to buffer message reading, because a read from the buffer
                // does not take much time compared to a direct read from the NXT 
                // which takes lots of time (50ms).
                // See EnableBuffering documentation for more info.
                nxtMessenger.EnableReadBuffering(1, true);
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            // Set the initial paddle location
            paddlePosition = new Vector2(
                graphics.GraphicsDevice.Viewport.Width / 2 - paddleSprite.Width / 2,
                graphics.GraphicsDevice.Viewport.Height - paddleSprite.Height);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ballSprite = Content.Load<Texture2D>("basketball");
            paddleSprite = Content.Load<Texture2D>("hand");

            swishSound = Content.Load<SoundEffect>("swish");
            crashSound = Content.Load<SoundEffect>("crash");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // Unload any non ContentManager content here

            // NXT: Disconnect
            if (robotIsConnectedAndAlive)
            {
                nxtMessenger.Disconnect();
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Move the sprite by speed, scaled by elapsed time
            ballPosition += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            int maxX = graphics.GraphicsDevice.Viewport.Width - ballSprite.Width;
            int maxY = graphics.GraphicsDevice.Viewport.Height - ballSprite.Height;

            // Check for bounce
            if (ballPosition.X > maxX || ballPosition.X < 0)
            {
                // Ball hit one of the sides of the screen
                ballSpeed.X *= -1;
            }

            if (ballPosition.Y < 0)
            {
                // Ball hit top of screen
                ballSpeed.Y *= -1;
            }
            else if (ballPosition.Y > maxY)
            {
                // Ball hit the bottom of the screen, so make sound and reset the ball position
                crashSound.Play();

                // NXT: send CRASH message to mailbox 2 of the NXT
                if (robotIsConnectedAndAlive)
                {
                    nxtMessenger.SendMessage("CRASH", 2);
                }

                ballPosition.Y = 0;
                ballSpeed.X = 150;
                ballSpeed.Y = 150;
            }

            if (BallAndPaddleCollide() && ballSpeed.Y > 0)
            {
                // Paddle collided with the ball, so make a sound and bounce the ball back
                swishSound.Play();

                // NXT: send HIT message to mailbox 2 of the NXT
                if (robotIsConnectedAndAlive)
                {
                    nxtMessenger.SendMessage("HIT", 2);
                }

                // Increase ball speed
                ballSpeed.Y += 50;
                if (ballSpeed.X < 0)
                {
                    ballSpeed.X -= 50;
                }
                else
                {
                    ballSpeed.X += 50;
                }

                // Send ball back up the screen
                ballSpeed.Y *= -1;
            }

            // Game can be controlled by both the arrow keys and the keys of the connected NXT
            UpdatePaddlePositionUsingKeys();
            UpdatePaddlePositionUsingNXT();

            base.Update(gameTime);
        }

        /// <summary>
        /// Update paddle position or exit game using messages from mailbox 1 of a connected NXT.
        /// </summary>
        private void UpdatePaddlePositionUsingNXT()
        {
            if (robotIsConnectedAndAlive)
            {
                String message = "";
                const int messageMailbox = 1;

                // NXT: Receive a new direction command from mailbox 1 of the NXT
                // and use it to change the direction of the paddle or to exit the game.
                NXTCommandResult commandResult = nxtMessenger.ReceiveMessage(messageMailbox, out message);
                if (commandResult == NXTCommandResult.Success)
                {
                    if (message == "R")
                    {
                        MovePaddle(10);
                    }
                    else if (message == "L")
                    {
                        MovePaddle(-10);
                    }
                    else if (message == "E")
                    {
                        Exit();
                    }
                }
            }
        }

        /// <summary>
        /// Update the paddle's position with arrow keys from the keyboard 
        /// and exit game on ESC key.
        /// </summary>
        private void UpdatePaddlePositionUsingKeys()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Right))
            {
                MovePaddle(5);
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                MovePaddle(-5);
            }
            else if (keyState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }
        }

        /// <summary>
        /// Move paddel relative to uts current position.
        /// The paddle cannot be moved outside the viewport area.
        /// </summary>
        /// <param name="relativeX"></param>
        private void MovePaddle(float relativeX)
        {
            float newPosition = paddlePosition.X + relativeX;
            if (relativeX < 0)
            {
                paddlePosition.X = Math.Max(0, newPosition);
            }
            else
            {
                int Xmax = graphics.GraphicsDevice.Viewport.Width - paddleSprite.Width;
                paddlePosition.X = Math.Min(Xmax, newPosition);
            }
        }

        /// <summary>
        /// Check if the ball and the paddle collide
        /// </summary>
        /// <returns>true if the ball and the paddel collide, else false.</returns>
        private bool BallAndPaddleCollide()
        {
            // Ball and paddle collide?  Check rectangle intersection between objects
            Rectangle ballRect =
                new Rectangle((int)ballPosition.X, (int)ballPosition.Y,
                ballSprite.Width, ballSprite.Height);

            Rectangle handRect =
                new Rectangle((int)paddlePosition.X, (int)paddlePosition.Y,
                    paddleSprite.Width, paddleSprite.Height);

            return ballRect.Intersects(handRect);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // Draw the sprite
            spriteBatch.Begin();
            spriteBatch.Draw(ballSprite, ballPosition, Color.White);
            spriteBatch.Draw(paddleSprite, paddlePosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}