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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace ButtonTutorial
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Global variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        enum BState
        {
            HOVER,
            UP,
            JUST_RELEASED,
            DOWN
        }
        const int NUMBER_OF_BUTTONS = 3, 
            EASY_BUTTON_INDEX = 0,
            MEDIUM_BUTTON_INDEX = 1,
            HARD_BUTTON_INDEX = 2,
            BUTTON_HEIGHT = 40,
            BUTTON_WIDTH = 88;
        Color background_color;
        Color[] button_color = new Color[NUMBER_OF_BUTTONS];
        Rectangle[] button_rectangle = new Rectangle[NUMBER_OF_BUTTONS];
        BState[] button_state = new BState[NUMBER_OF_BUTTONS];
        Texture2D[] button_texture = new Texture2D[NUMBER_OF_BUTTONS];
        double[] button_timer = new double[NUMBER_OF_BUTTONS];
        //mouse pressed and mouse just pressed
        bool mpressed, prev_mpressed = false;
        //mouse location in window
        int mx, my;
        double frame_time;
        // for simulating button clicks with keyboard
        KeyboardState keyboard_state, last_keyboard_state;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        // wrapper for hit_image_alpha taking Rectangle and Texture
        Boolean hit_image_alpha(Rectangle rect, Texture2D tex, int x, int y)
        {
            return hit_image_alpha(0, 0, tex, tex.Width * (x - rect.X) / 
                rect.Width, tex.Height * (y - rect.Y) / rect.Height);
        }

        // wraps hit_image then determines if hit a transparent part of image 
        Boolean hit_image_alpha(float tx, float ty, Texture2D tex, int x, int y)
        {
            if (hit_image(tx, ty, tex, x, y))
            {
                uint[] data = new uint[tex.Width * tex.Height];
                tex.GetData<uint>(data);
                if ((x - (int)tx) + (y - (int)ty) * 
                    tex.Width < tex.Width * tex.Height)
                {
                    return ((data[
                        (x - (int)tx) + (y - (int)ty) * tex.Width
                        ] &
                                0xFF000000) >> 24) > 20;
                }
            }
            return false;
        }

        // determine if x,y is within rectangle formed by texture located at tx,ty
        Boolean hit_image(float tx, float ty, Texture2D tex, int x, int y)
        {
            return (x >= tx &&
                x <= tx + tex.Width &&
                y >= ty &&
                y <= ty + tex.Height);
        }

        // determine state and color of button
        void update_buttons()
        {
            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            {

                if (hit_image_alpha(
                    button_rectangle[i], button_texture[i], mx, my))
                {
                    button_timer[i] = 0.0;
                    if (mpressed)
                    {
                        // mouse is currently down
                        button_state[i] = BState.DOWN;
                        button_color[i] = Color.Blue;
                    }
                    else if (!mpressed && prev_mpressed)
                    {
                        // mouse was just released
                        if (button_state[i] == BState.DOWN)
                        {
                            // button i was just down
                            button_state[i] = BState.JUST_RELEASED;
                        }
                    }
                    else
                    {
                        button_state[i] = BState.HOVER;
                        button_color[i] = Color.LightBlue;
                    }
                }
                else
                {
                    button_state[i] = BState.UP;
                    if (button_timer[i] > 0)
                    {
                        button_timer[i] = button_timer[i] - frame_time;
                    }
                    else
                    {
                        button_color[i] = Color.White;
                    }
                }

                if (button_state[i] == BState.JUST_RELEASED)
                {
                    take_action_on_button(i);
                }
            }
        }


        // Logic for each button click goes here
        void take_action_on_button(int i)
        {
            //take action corresponding to which button was clicked
            switch (i)
            {
                case EASY_BUTTON_INDEX:
                    background_color = Color.Green;
                    break;
                case MEDIUM_BUTTON_INDEX:
                    background_color = Color.Yellow;
                    break;
                case HARD_BUTTON_INDEX:
                    background_color = Color.Red;
                    break;
                default:
                    break;
            }
        }

        // Logic for each key down event goes here
        void handle_keyboard()
        {
            last_keyboard_state = keyboard_state;
            keyboard_state = Keyboard.GetState();
            Keys[] keymap = (Keys[])keyboard_state.GetPressedKeys();
            foreach (Keys k in keymap)
            {

                char key = k.ToString()[0];
                switch (key)
                {
                    case 'e':
                    case 'E':
                        take_action_on_button(EASY_BUTTON_INDEX);
                        button_color[EASY_BUTTON_INDEX] = Color.Orange;
                        button_timer[EASY_BUTTON_INDEX] = 0.25;
                        break;
                    case 'm':
                    case 'M':
                        take_action_on_button(MEDIUM_BUTTON_INDEX);
                        button_color[MEDIUM_BUTTON_INDEX] = Color.Orange;
                        button_timer[MEDIUM_BUTTON_INDEX] = 0.25;
                        break;
                    case 'h':
                    case 'H':
                        take_action_on_button(HARD_BUTTON_INDEX);
                        button_color[HARD_BUTTON_INDEX] = Color.Orange;
                        button_timer[HARD_BUTTON_INDEX] = 0.25;
                        break;
                    default:
                        break;
                }

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
            // TODO: Add your initialization logic here
            // starting x and y locations to stack buttons 
            // vertically in the middle of the screen
            int x = Window.ClientBounds.Width/2 - BUTTON_WIDTH / 2;
            int y = Window.ClientBounds.Height/2 - 
                NUMBER_OF_BUTTONS / 2 * BUTTON_HEIGHT - 
                (NUMBER_OF_BUTTONS%2)*BUTTON_HEIGHT/2;
            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            {
                button_state[i] = BState.UP;
                button_color[i] = Color.White;
                button_timer[i] = 0.0;
                button_rectangle[i] = new Rectangle(x, y, BUTTON_WIDTH, BUTTON_HEIGHT);
                y += BUTTON_HEIGHT;
            }
            IsMouseVisible = true;
            background_color = Color.CornflowerBlue;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            button_texture[EASY_BUTTON_INDEX] = 
                Content.Load<Texture2D>(@"images/easy");
            button_texture[MEDIUM_BUTTON_INDEX] =
                Content.Load<Texture2D>(@"images/medium");
            button_texture[HARD_BUTTON_INDEX] = 
                Content.Load<Texture2D>(@"images/hard");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // get elapsed frame time in seconds
            frame_time = gameTime.ElapsedGameTime.Milliseconds / 1000.0;

            // update mouse variables
            MouseState mouse_state = Mouse.GetState();
            mx = mouse_state.X;
            my = mouse_state.Y;
            prev_mpressed = mpressed;
            mpressed = mouse_state.LeftButton == ButtonState.Pressed;

            update_buttons();
            handle_keyboard();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(background_color);

            spriteBatch.Begin();
            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
                spriteBatch.Draw(button_texture[i], button_rectangle[i], button_color[i]);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
