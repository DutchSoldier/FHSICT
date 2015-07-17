using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace TopSecret2
{
    public class TopSecret2 : Microsoft.Xna.Framework.Game
    {
        private TimeSpan resterendeTijd = TimeSpan.FromSeconds(200);
        private TimeSpan vorigeActie = TimeSpan.FromSeconds(0);
        private bool useArduino = true;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private KeyboardState keystate;
        private SpriteFont font;
        private Text text;

        private PlayerAnimations playerAnimations;
        private KeyboardInput keyboardInput;
        private Interface playerInterface;
        private DatabaseClass database;

        private Collision collision;
        private List<Enemy> enemies;
        private Arduino arduino;
        private Player player;
        private Level level;
        private Menu menu;

        private string naam = "Voer naam in";
        public int comPoort { get; private set; }

        public TopSecret2()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.graphics.PreferredBackBufferHeight = GlobalVars.resolutionHeight;
            this.graphics.PreferredBackBufferWidth = GlobalVars.resolutionWidth;
            this.graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>(@"Arial");

            playerAnimations = new PlayerAnimations(Content);
            playerInterface = new Interface(Content);
            player = new Player(playerAnimations);
            keyboardInput = new KeyboardInput();
            database = new DatabaseClass();
            collision = new Collision();
            enemies = new List<Enemy>();
            level = new Level(Content);
            menu = new Menu(Content);
            text = new Text();
 
            GlobalVars.currentState = GlobalVars.gameState.mainMenu;
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            keystate = Keyboard.GetState();
            ConsoleCommands(gameTime);

            if (GlobalVars.currentState == GlobalVars.gameState.mainMenu)
            {
                UpdateMainMenu(gameTime);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.characterMenu)
            {
                UpdateCharacterMenu(gameTime);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.moeilijkheidsMenu)
            {
                UpdateMoeilijkheidsMenu(gameTime);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.highScoreMenu)
            {
                UpdateHighScoreMenu(gameTime);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.normalLevel)
            {
                UpdateNormalLevel(gameTime);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.tutorialScherm)
            {
                UpdateTutorialMenu(gameTime);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.loadingScherm)
            {
                UpdateLoadingScherm(gameTime);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.highScoreInvullen)
            {
                UpdateHighScoreInvullen(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (GlobalVars.currentState == GlobalVars.gameState.mainMenu)
            {
                menu.DrawMainMenu(spriteBatch);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.characterMenu)
            {
                menu.DrawCharacterMenu(spriteBatch);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.moeilijkheidsMenu)
            {
                menu.DrawMoeilijkheidsMenu(spriteBatch);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.highScoreMenu)
            {
                Vector2 locatieNaam = new Vector2(GlobalVars.resolutionWidth/2 - 300,200);
                Vector2 locatieScore = new Vector2(GlobalVars.resolutionWidth / 2 + 300, 200);
                menu.DrawHighScoreMenu(spriteBatch);
                foreach (string naam in database.Naam)
                {
                    text.DrawText(locatieNaam.X, locatieNaam.Y, naam, font, spriteBatch);
                    locatieNaam.Y += 30;
                }
                foreach (int score in database.Score)
                {
                    text.DrawText(locatieScore.X, locatieScore.Y, Convert.ToString(score), font, spriteBatch);
                    locatieScore.Y += 30;
                }
            }
            if (GlobalVars.currentState == GlobalVars.gameState.tutorialScherm)
            {
                menu.DrawTurorialMenu(spriteBatch);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.normalLevel)
            {
                DrawNormalLevel();
            }
            if (GlobalVars.currentState == GlobalVars.gameState.tutorialScherm)
            {
                menu.DrawTurorialMenu(spriteBatch);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.loadingScherm)
            {
                menu.DrawLoadingScreen(spriteBatch, level);
            }
            if (GlobalVars.currentState == GlobalVars.gameState.highScoreInvullen)
            {
                menu.DrawLoadingScreen(spriteBatch, level);
                text.DrawText(0, 0, naam, font, spriteBatch);
            }
            if (keystate.IsKeyDown(Keys.F1) && keystate.IsKeyDown(Keys.F3))
            {
                text.DrawText(770, 450, Convert.ToString(comPoort), font, spriteBatch);
            }
            base.Draw(gameTime);
        }

        private void ConsoleCommands(GameTime gameTime)
        {
            if (keystate.IsKeyDown(Keys.F1) && keystate.IsKeyDown(Keys.F3))
            {
                if (gameTime.TotalGameTime >= vorigeActie + TimeSpan.FromSeconds(0.2))
                {
                    if (keystate.IsKeyDown(Keys.Down))
                    {
                        comPoort--;
                        vorigeActie = gameTime.TotalGameTime;
                    }
                    if (keystate.IsKeyDown(Keys.Up))
                    {
                        comPoort++;
                        vorigeActie = gameTime.TotalGameTime;
                    }
                    if (keystate.IsKeyDown(Keys.F5))
                    {
                        useArduino = false; 
                        vorigeActie = gameTime.TotalGameTime;
                    }
                    if (keystate.IsKeyDown(Keys.F6))
                    {
                        useArduino = true;
                        GlobalVars.currentState = GlobalVars.gameState.loadingScherm;
                        vorigeActie = gameTime.TotalGameTime;
                    }
                }
            }
        }

        private void UpdateMainMenu(GameTime gameTime)
        {
            if (vorigeActie + TimeSpan.FromSeconds(0.2) <= gameTime.TotalGameTime)
            {
                if (keystate.IsKeyDown(Keys.Down))
                {
                    menu.huidigeMenuOpties = Menu.MenuOpties.MainMenuHighscores;
                    vorigeActie = gameTime.TotalGameTime;
                }
                if (keystate.IsKeyDown(Keys.Up))
                {
                    menu.huidigeMenuOpties = Menu.MenuOpties.MainMenuStart;
                    vorigeActie = gameTime.TotalGameTime;
                }
                if (keystate.IsKeyDown(Keys.Enter))
                {
                    if (menu.huidigeMenuOpties == Menu.MenuOpties.MainMenuStart)
                    {
                        GlobalVars.currentState = GlobalVars.gameState.characterMenu;
                        menu.huidigeMenuOpties = Menu.MenuOpties.CharacterMenuSimon;
                    }
                    else
                    {
                        database.GetScore();
                        GlobalVars.currentState = GlobalVars.gameState.highScoreMenu;
                    }
                    vorigeActie = gameTime.TotalGameTime;
                }
            }
        }

        private void UpdateCharacterMenu(GameTime gameTime)
        {
            if (vorigeActie + TimeSpan.FromSeconds(0.2) <= gameTime.TotalGameTime)
            {
                if (keystate.IsKeyDown(Keys.Down))
                {
                    menu.huidigeMenuOpties = Menu.MenuOpties.CharacterMenuTerug;
                    vorigeActie = gameTime.TotalGameTime;
                }
                if (keystate.IsKeyDown(Keys.Up))
                {
                    menu.huidigeMenuOpties = Menu.MenuOpties.CharacterMenuSimon;
                    vorigeActie = gameTime.TotalGameTime;
                }
                if (keystate.IsKeyDown(Keys.Enter))
                {
                    if (menu.huidigeMenuOpties == Menu.MenuOpties.CharacterMenuSimon)
                    {
                        GlobalVars.currentState = GlobalVars.gameState.moeilijkheidsMenu;
                        menu.huidigeMenuOpties = Menu.MenuOpties.MoeilijkheidsMenuEasy;
                    }
                    else
                    {
                        GlobalVars.currentState = GlobalVars.gameState.mainMenu;
                        menu.huidigeMenuOpties = Menu.MenuOpties.MainMenuStart;
                    }
                    vorigeActie = gameTime.TotalGameTime;
                }
            }
        }

        private void UpdateMoeilijkheidsMenu(GameTime gameTime)
        {
            if (vorigeActie + TimeSpan.FromSeconds(0.2) <= gameTime.TotalGameTime)
            {
                if (keystate.IsKeyDown(Keys.Down))
                {
                    if (menu.huidigeMenuOpties == Menu.MenuOpties.MoeilijkheidsMenuHard)
                    {
                        menu.huidigeMenuOpties = Menu.MenuOpties.MoeilijkheidsMenuTerug;
                    }
                    if (menu.huidigeMenuOpties == Menu.MenuOpties.MoeilijkheidsMenuMedium)
                    {
                        menu.huidigeMenuOpties = Menu.MenuOpties.MoeilijkheidsMenuHard;
                    }
                    if (menu.huidigeMenuOpties == Menu.MenuOpties.MoeilijkheidsMenuEasy)
                    {
                        menu.huidigeMenuOpties = Menu.MenuOpties.MoeilijkheidsMenuMedium;
                    }
                    vorigeActie = gameTime.TotalGameTime;
                }
                if (keystate.IsKeyDown(Keys.Up))
                {
                    if (menu.huidigeMenuOpties == Menu.MenuOpties.MoeilijkheidsMenuMedium)
                    {
                        menu.huidigeMenuOpties = Menu.MenuOpties.MoeilijkheidsMenuEasy;
                    }
                    if (menu.huidigeMenuOpties == Menu.MenuOpties.MoeilijkheidsMenuHard)
                    {
                        menu.huidigeMenuOpties = Menu.MenuOpties.MoeilijkheidsMenuMedium;
                    }
                    if (menu.huidigeMenuOpties == Menu.MenuOpties.MoeilijkheidsMenuTerug)
                    {
                        menu.huidigeMenuOpties = Menu.MenuOpties.MoeilijkheidsMenuHard;
                    }
                    vorigeActie = gameTime.TotalGameTime;
                }
                if (keystate.IsKeyDown(Keys.Enter))
                {
                    if (menu.huidigeMenuOpties == Menu.MenuOpties.MoeilijkheidsMenuEasy)
                    {
                        database.LoadEnemies("Enemy_Easy");
                        GlobalVars.currentState = GlobalVars.gameState.tutorialScherm;
                    }
                    if (menu.huidigeMenuOpties == Menu.MenuOpties.MoeilijkheidsMenuMedium)
                    {
                        database.LoadEnemies("Enemy_Medium");
                        GlobalVars.currentState = GlobalVars.gameState.tutorialScherm;
                    }
                    if (menu.huidigeMenuOpties == Menu.MenuOpties.MoeilijkheidsMenuHard)
                    {
                        database.LoadEnemies("Enemy_Hard");
                        GlobalVars.currentState = GlobalVars.gameState.tutorialScherm;
                    }
                    if (menu.huidigeMenuOpties == Menu.MenuOpties.MoeilijkheidsMenuTerug)
                    {
                        GlobalVars.currentState = GlobalVars.gameState.characterMenu;
                        menu.huidigeMenuOpties = Menu.MenuOpties.CharacterMenuSimon;
                    }
                    vorigeActie = gameTime.TotalGameTime;
                }
            }
        }

        private void UpdateHighScoreMenu(GameTime gameTime)
        {
            if (vorigeActie + TimeSpan.FromSeconds(1) <= gameTime.TotalGameTime)
            {
                if (keystate.IsKeyDown(Keys.Enter))
                {
                    GlobalVars.currentState = GlobalVars.gameState.mainMenu;
                    vorigeActie = gameTime.TotalGameTime;
                }
            }
        }

        private void UpdateHighScoreInvullen(GameTime gameTime)
        {
            if (vorigeActie + TimeSpan.FromSeconds(0.12) <= gameTime.TotalGameTime)
            {
                if (keyboardInput.getNaam(keystate) != "")
                {
                    if (naam == "Voer naam in")
                    {
                        naam = "";
                    }

                    naam += keyboardInput.getNaam(keystate);
                    vorigeActie = gameTime.TotalGameTime;
                }
                if (keystate.IsKeyDown(Keys.Enter))
                {
                    database.SubmitScore(naam, Convert.ToInt32(GlobalVars.score));
                    vorigeActie =  gameTime.TotalGameTime;
                }
                if(keystate.IsKeyDown(Keys.Back))
                {
                    if (naam.Length > 0)
                    {
                        naam = naam.Remove(naam.Length - 1);
                        vorigeActie = gameTime.TotalGameTime;
                    }
                }
            }
        }

        private void UpdateNormalLevel(GameTime gameTime)
        {
            player.UpdateHitboxes(playerAnimations);
            player.UpdateHeight(playerAnimations, level, collision);
            playerInterface.UpdateInterface(player);
            if (player.isAlive() && !level.EndOfLevel() && resterendeTijd > TimeSpan.FromSeconds(0))
            {
                if (arduino == null)
                {
                    resterendeTijd -= gameTime.ElapsedGameTime;
                    Event();
                    if (player.MoveToCenter(playerAnimations, level))
                    {
                        if (enemies.Count <= 0)
                        {
                            player.screenLocked = false;
                        }
                        else
                        {
                            player.screenLocked = true;
                        }
                        if (keystate.IsKeyDown(Keys.Right))
                        {
                            player.MoveRight(playerAnimations, level, gameTime, collision);
                        }
                        if (keystate.IsKeyDown(Keys.Left))
                        {
                            player.MoveLeft(playerAnimations, level, gameTime, collision);
                        }
                        if (keystate.IsKeyDown(Keys.Up))
                        {
                            player.jumping = true;
                        }
                        if (keystate.IsKeyDown(Keys.Space))
                        {
                            player.Combo(gameTime, enemies, collision);
                        }
                    }

                    foreach (Enemy enemy in enemies)
                    {
                        if (enemy.isAlive())
                        {
                            enemy.updateHitBoxes();
                            enemy.updateHeight(collision, level);
                            if (enemy.Move(player, collision, level, gameTime, playerAnimations))
                            {
                                enemy.Attack(gameTime, player, collision);
                            }
                        }
                        else
                        {
                            enemies.Remove(enemy);
                            break;
                        }
                    }  
                }
                else
                {
                    if (arduino.checkCode())
                    {
                        arduino = null;
                    } 
                }
            }
            else if (level.EndOfLevel())
            {
                if (player.MoveToEnd(playerAnimations, gameTime))
                {
                    vorigeActie = gameTime.TotalGameTime;
                    GlobalVars.score += resterendeTijd.TotalMilliseconds / 1000;
                    Debug.WriteLine(GlobalVars.score);
                    GlobalVars.currentState = GlobalVars.gameState.loadingScherm;
                }
            }
            else
            {
                ResetLevel();
            }

            
        }

        private void UpdateTutorialMenu(GameTime gameTime)
        {
            if (vorigeActie + TimeSpan.FromSeconds(1) <= gameTime.TotalGameTime)
            {
                if (keystate.IsKeyDown(Keys.Enter))
                {
                    vorigeActie = gameTime.TotalGameTime;
                    GlobalVars.currentState = GlobalVars.gameState.normalLevel;
                }
            }
        }

        private void UpdateLoadingScherm(GameTime gameTime)
        {
            if (vorigeActie + TimeSpan.FromSeconds(1) <= gameTime.TotalGameTime)
            {
                if (keystate.IsKeyDown(Keys.Enter))
                {
                    NextLevel();
                    vorigeActie = gameTime.TotalGameTime;
                }
            }
        }

        private void DrawNormalLevel()
        {
            level.DrawLevel(spriteBatch);
            playerAnimations.DrawPlayer(spriteBatch, player);
            playerInterface.DrawInterface(spriteBatch);
            text.DrawText(1350, 10, string.Format("{0:mm\\:ss}", resterendeTijd), font, spriteBatch);
            foreach (Enemy enemy in enemies)
            {
                enemy.DrawEnemy(spriteBatch);
            }
            if (arduino != null)
            {
                string code = arduino.returnCode();
                text.DrawText(770, 450, code, font, spriteBatch);
            }
        }

        private void Event()
        {
            int eventNum = collision.CheckEventCollision(level, player);

            if (level.currentLevel == 0)
            {
                if (eventNum == 0)
                {
                    enemies.Add(new Enemy("melee", new Vector2(0,0), Content));
                }

                if (eventNum == 1)
                {
                    player.health -= 1;
                }
            }

            if (level.currentLevel == 1)
            {
                if (eventNum == 0)
                {
                    player.health -= 1;
                }

                if (eventNum == 1)
                {
                    player.health -= 1;
                }
            }

            int damageNum = collision.CheckDamageCollision(level, player);
            if (level.currentLevel == 0)
            {
                if (damageNum == 0 || damageNum == 1 || damageNum == 2 || damageNum == 3 || damageNum == 4 || damageNum == 5)
                {
                    player.health -= 5;
                }
            }

            if (level.currentLevel == 1)
            {
                if (damageNum == 0 || damageNum == 1 || damageNum == 2)
                {
                    player.health -= 5;
                }
            }

            int objectNum = collision.CheckObjectCollision(level, player);
            if (objectNum == 0 || objectNum == 1)
            {
                player.Heal(20);
            }

        }

        private void ResetLevel()
        {
            player.ResetPlayer(playerAnimations);
            level.levelLoaded = false;
            level.LoadLevel(Content);
            enemies.Clear();
            SetTime();
        }

        private void NextLevel()
        {
                player.ResetPlayer(playerAnimations);
                level.NextLevel(Content, menu);
                SetTime();
        }

        private void SetTime()
        {
            if (level.currentLevel == 0)
            {
                resterendeTijd = TimeSpan.FromSeconds(200);
            }

            if (level.currentLevel == 1)
            {
                resterendeTijd = TimeSpan.FromSeconds(200);
            }
        }
    }
}
