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
    public class TopSecret : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private KeyboardState keystate;
        private SpriteFont font;
        private Text text;
        private Player player;
        private Level level;
        private Menu menu;
        private PlayerAnimation animation;
        private Collision collision;
        private Enemy[] enemy;
        private int eventNum;
        private TimeSpan vorigmenu = TimeSpan.FromSeconds(0);

        public TopSecret()
        {
            graphics = new GraphicsDeviceManager(this);

            GlobalVars.resolutionWidth = 1440;
            GlobalVars.resolutionHeight = 900;


            this.graphics.PreferredBackBufferWidth = GlobalVars.resolutionWidth;
            this.graphics.PreferredBackBufferHeight = GlobalVars.resolutionHeight;
            this.graphics.IsFullScreen = true;
            
            Content.RootDirectory = "Content";
            enemy = new Enemy[0];
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>(@"Fonts/Arial");
            text = new Text(font, spriteBatch);

            menu = new Menu(Content, spriteBatch, text);
            level = new Level(Content, spriteBatch);

            menu.loadMainMenuStart();
            GlobalVars.currentState = GlobalVars.gameState.mainMenuStart;
            menu.loadMainMenuHighscore();
            menu.loadHighscoreMenuTerug();
            menu.loadCaracterMenuKies();
            menu.loadCaracterMenuTerug();
            menu.loadMoeilijkheidMenuKiesEasy();
            menu.loadMoeilijkheidMenuKiesHard();
            menu.loadMoeilijkheidMenuKiesMedium();
            menu.loadMoeilijkheidMenuTerugEasy();
            menu.loadMoeilijkheidMenuTerugHard();
            menu.loadMoeilijkheidMenuTerugMedium();
            
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            keystate = Keyboard.GetState();
            menuFunctions(gameTime);
            levelFunctions();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (GlobalVars.currentState)
            {
                case GlobalVars.gameState.mainMenuStart:
                    {
                        menu.drawMainMenuStart();
                        break;
                    }

                case GlobalVars.gameState.mainMenuHighscore:
                    {
                        menu.drawMainMenuHighscore();
                        break;
                    }

                case GlobalVars.gameState.highScoreMenuTerug:
                    {
                        menu.drawHighscoreMenuTerug();
                        break;
                    }

                case GlobalVars.gameState.caracterMenuKies:
                    {
                        menu.drawCaracterMenuKies();
                        break;
                    }

                case GlobalVars.gameState.caracterMenuTerug:
                    {
                        menu.drawCaracterMenuTerug();
                        break;
                    }

                case GlobalVars.gameState.moeilijkheidMenuKiesEasy:
                    {
                        menu.drawMoeilijkheidMenuKiesEasy();
                        break;
                    }

                case GlobalVars.gameState.moeilijkheidMenuKiesHard:
                    {
                        menu.drawMoeilijkheidMenuKiesHard();
                        break;
                    }

                case GlobalVars.gameState.moeilijkheidMenuKiesMedium:
                    {
                        menu.drawMoeilijkheidMenuKiesMedium();
                        break;
                    }

                case GlobalVars.gameState.moeilijkheidMenuTerugEasy:
                    {
                        menu.drawMoeilijkheidMenuTerugEasy();
                        break;
                    }

                case GlobalVars.gameState.moeilijkheidMenuTerugHard:
                    {
                        menu.drawMoeilijkheidMenuTerugHard();
                        break;
                    }

                case GlobalVars.gameState.moeilijkheidMenuTerugMedium:
                    {
                        menu.drawMoeilijkheidMenuTerugMedium();
                        break;
                    }

                case GlobalVars.gameState.levelScore:
                    {
                        menu.drawLevelScore();
                        break;
                    }

                case GlobalVars.gameState.displayingNormalLevel:
                    {
                        drawLevel();
                        break;
                    }

            }
            base.Draw(gameTime);
        }

        private void menuFunctions(GameTime gameTime)
        {
            switch (GlobalVars.currentState)
            {
                case GlobalVars.gameState.mainMenuStart:
                    {
                        menu.loadCaracterMenuKies();
                        menu.loadMainMenuHighscore();
                        if (keystate.IsKeyDown(Keys.Enter))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.5) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.caracterMenuKies;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Down))
                        {
                            GlobalVars.currentState = GlobalVars.gameState.mainMenuHighscore;
                        }
                        
                        break;
                    }

                case GlobalVars.gameState.mainMenuHighscore:
                    {
                            menu.loadHighscoreMenuTerug();
                            menu.loadMainMenuStart();
                            if (keystate.IsKeyDown(Keys.Enter))
                            {
                                if (vorigmenu + TimeSpan.FromSeconds(0.5) <= gameTime.TotalGameTime)
                                {
                                    vorigmenu = gameTime.TotalGameTime;
                                    GlobalVars.currentState = GlobalVars.gameState.highScoreMenuTerug;
                                }
                            }
                            else if (keystate.IsKeyDown(Keys.Up))
                            {
                                GlobalVars.currentState = GlobalVars.gameState.mainMenuStart;
                            }
                        break;
                    }

                case GlobalVars.gameState.highScoreMenuTerug:
                    {
                        menu.loadMainMenuStart();
                        if (keystate.IsKeyDown(Keys.Enter))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.5) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.mainMenuStart;
                            }
                        }

                        break;
                    }

                case GlobalVars.gameState.caracterMenuKies:
                    {
                            menu.loadCaracterMenuTerug();
                            menu.loadMoeilijkheidMenuKiesEasy();
                            if (keystate.IsKeyDown(Keys.Enter))
                            {
                                if (vorigmenu + TimeSpan.FromSeconds(0.5) <= gameTime.TotalGameTime)
                                {
                                    vorigmenu = gameTime.TotalGameTime;
                                    GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuKiesEasy;
                                }
                            }
                            else if (keystate.IsKeyDown(Keys.Left))
                            {
                                GlobalVars.currentState = GlobalVars.gameState.caracterMenuTerug;
                            }
                        
                        break;
                    }

                case GlobalVars.gameState.caracterMenuTerug:
                    {
                        menu.loadMainMenuStart();
                        menu.loadCaracterMenuKies();
                        if (keystate.IsKeyDown(Keys.Enter))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.5) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.mainMenuStart;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Right))
                        {
                            GlobalVars.currentState = GlobalVars.gameState.caracterMenuKies;
                        }

                        break;
                    }

                case GlobalVars.gameState.moeilijkheidMenuKiesEasy:
                    {
                        menu.loadMoeilijkheidMenuKiesMedium();
                        menu.loadMoeilijkheidMenuTerugEasy();
                        level.loadLevel();

                        if (keystate.IsKeyDown(Keys.Enter))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.5) <= gameTime.TotalGameTime)
                            {
                                GlobalVars.currentState = GlobalVars.gameState.displayingNormalLevel;

                                animation = new PlayerAnimation(Content, spriteBatch, "Luc");
                                player = new Player(level, animation);
                                collision = new Collision(animation, player, level);

                                animation.player = this.player;
                                level.player = this.player;
                                player.Collision = this.collision;

                                player.setStartingPosition();
                                vorigmenu = gameTime.TotalGameTime;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Down))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.3) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuKiesMedium;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Left))
                        {
                            GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuTerugEasy;
                        }

                        break;
                    }

                case GlobalVars.gameState.moeilijkheidMenuKiesMedium:
                    {
                        menu.loadMoeilijkheidMenuTerugMedium();
                        menu.loadMoeilijkheidMenuKiesHard();
                        level.loadLevel();
                        menu.loadMoeilijkheidMenuKiesEasy();

                        if (keystate.IsKeyDown(Keys.Enter))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.5) <= gameTime.TotalGameTime)
                            {
                                GlobalVars.currentState = GlobalVars.gameState.displayingNormalLevel;

                                animation = new PlayerAnimation(Content, spriteBatch, "Luc");
                                player = new Player(level, animation);
                                collision = new Collision(animation, player, level);

                                animation.player = this.player;
                                level.player = this.player;
                                player.Collision = this.collision;
                                vorigmenu = gameTime.TotalGameTime;
                                player.setStartingPosition();
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Up))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.3) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuKiesEasy;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Down))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.3) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuKiesHard;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Left))
                        {
                            GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuTerugMedium;
                        }

                        break;
                    }

                case GlobalVars.gameState.moeilijkheidMenuKiesHard:
                    {
                        menu.loadMoeilijkheidMenuKiesMedium();
                        menu.loadMoeilijkheidMenuTerugHard();
                        level.loadLevel();

                        if (keystate.IsKeyDown(Keys.Enter))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.5) <= gameTime.TotalGameTime)
                            {
                                GlobalVars.currentState = GlobalVars.gameState.displayingNormalLevel;

                                animation = new PlayerAnimation(Content, spriteBatch, "Luc");
                                player = new Player(level, animation);
                                collision = new Collision(animation, player, level);

                                animation.player = this.player;
                                level.player = this.player;
                                player.Collision = this.collision;
                                vorigmenu = gameTime.TotalGameTime;
                                player.setStartingPosition();
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Up))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.3) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuKiesMedium;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Left))
                        {
                            GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuTerugHard;
                        }

                        break;
                    }

                case GlobalVars.gameState.moeilijkheidMenuTerugEasy:
                    {
                        menu.loadCaracterMenuKies();
                        menu.loadMoeilijkheidMenuTerugMedium();
                        if (keystate.IsKeyDown(Keys.Enter))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.5) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.caracterMenuKies;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Down))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.3) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuTerugMedium;
                            }
                        }

                        else if (keystate.IsKeyDown(Keys.Right))
                        {
                            GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuKiesEasy;
                        }
                        break;
                    }

                case GlobalVars.gameState.moeilijkheidMenuTerugMedium:
                    {
                        menu.loadMoeilijkheidMenuTerugEasy();
                        menu.loadMoeilijkheidMenuTerugHard();
                        menu.loadCaracterMenuKies();

                        if (keystate.IsKeyDown(Keys.Enter))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.5) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.caracterMenuKies;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Up))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.3) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuTerugEasy;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Down))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.3) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuTerugHard;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Right))
                        {
                            GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuKiesMedium;
                        }
                        break;
                    }

                case GlobalVars.gameState.moeilijkheidMenuTerugHard:
                    {
                        menu.loadMoeilijkheidMenuKiesMedium();
                        menu.loadCaracterMenuKies();
                        if (keystate.IsKeyDown(Keys.Enter))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.5) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.caracterMenuKies;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Up))
                        {
                            if (vorigmenu + TimeSpan.FromSeconds(0.3) <= gameTime.TotalGameTime)
                            {
                                vorigmenu = gameTime.TotalGameTime;
                                GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuTerugMedium;
                            }
                        }
                        else if (keystate.IsKeyDown(Keys.Right))
                        {
                            GlobalVars.currentState = GlobalVars.gameState.moeilijkheidMenuKiesHard;
                        }
                        break;
                    }

                case GlobalVars.gameState.levelScore:
                    {
                        level.loadLevel();
                        if (keystate.IsKeyDown(Keys.Enter))
                        {
                            vorigmenu = gameTime.TotalGameTime;
                            GlobalVars.currentState = GlobalVars.gameState.displayingNormalLevel;
                        }
                        break;
                    }
            }
        }

        private void levelFunctions()
        {
             if (GlobalVars.currentState == GlobalVars.gameState.displayingNormalLevel)
                    {
                        eventNum = collision.CheckEventCollision();
                        if (eventNum >= 0)
                        {
                            Event();
                        }

                        updateEnemy();
                        updatePlayer();
                    }
        }

        private void drawLevel()
        {
            level.drawLevel();
            animation.DrawPlayer();

            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i] != null)
                {
                    enemy[i].DrawEnemy();
                }
            }
        }

        private void Event()
        {
            if (level.currentLevel == 0)
            {
                if (eventNum == 0)
                {
                    player.lockLevel();
                    enemy = new Enemy[2];
                    enemy[0] = new Enemy(player, spriteBatch, Content, "melee", collision, 0);
                    enemy[1] = new Enemy(player, spriteBatch, Content, "melee", collision, 0);
                    collision.enemy = this.enemy;
                }

                if (eventNum == 1)
                {
                    player.lockLevel();
                    enemy = new Enemy[1];
                    enemy[0] = new Enemy(player, spriteBatch, Content, "melee", collision, 0);
                    collision.enemy = this.enemy;
                }
            }
        }

        private bool allEnemiesDead()
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i] != null)
                {
                    return false;
                }
            }
            return true;    
        }

        private void updatePlayer()
        {
            if (player.isAlive())
            {
                player.updateHeight();
                if (!player.endOfLevel())
                {
                    if (!player.locked)
                    {
                        if (player.moveToCenter())
                        {
                            if (keystate.IsKeyDown(Keys.Right))
                            {
                                player.moveRight();
                            }
                            if (keystate.IsKeyDown(Keys.Left))
                            {
                                player.moveLeft();
                            }
                            if (keystate.IsKeyDown(Keys.Up))
                            {
                                if (player.allowJump)
                                {
                                    player.jumping = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (keystate.IsKeyDown(Keys.Right))
                        {
                            player.moveRight();
                        }
                        if (keystate.IsKeyDown(Keys.Left))
                        {
                            player.moveLeft();
                        }
                        if (keystate.IsKeyDown(Keys.Up))
                        {
                            if (player.allowJump)
                            {
                                player.jumping = true;
                            }
                        }
                    }
                }
                else
                {
                    menu.loadLevelScore();
                    if (player.moveToEnd())
                    {
                        level.nextLevel();
                        menu.scoreLoaded = false;
                    }
                }
            }
        }

        private void updateEnemy()
        {
            if (!allEnemiesDead())
            {
                for (int i = 0; i < enemy.Length; i++)
                {
                    if (enemy[i] != null)
                    {
                        if (enemy[i].isAlive())
                        {
                            enemy[i].updateHeight();
                            if (collision.checkEnemyPlayerCollision(i))
                            {
                                enemy[i].modifyHealth(1);
                            }

                            if (enemy[i].moveTowardsPlayer())
                            {
                                //aanvallen
                            }
                        }
                        else
                        {
                            enemy[i] = null;
                        }
                    }
                }
            }
            else
            {
                player.unlockLevel();
            }
        }
    }
}
