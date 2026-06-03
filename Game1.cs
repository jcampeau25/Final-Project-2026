using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Final_Project_2026
{

    enum Screen
    {
        Title,
        Level1,
        Level2,
        Level3,
        Workbench
    }

    enum Level1Room
    { 
        Room1,
        Room2,
        Room3
    }

    


    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        MouseState mouseState, prevMouseState;

        KeyboardState keyboardState, prevKeyboardState;

        Player player;

        List<ShooterGuard> level1ShooterGuards;
        List<MeleeGuard> level1MeleeGuards;
        List<Rectangle> wallsL1R1;
        List<Rectangle>wallsL1R2;
        List<Rectangle> wallsL1R3;

        List<Workbench> workbenches;

        Texture2D playerTexture, shooterGuardTexture, meleeGuardTexture, bulletTexture, crosshairTexture,
                  ammoTexture, healthBarTexture, wallTexture, workbenchTexture;

        Texture2D titleTexture, upgradesTexture;

        SpriteFont ammoFont, reloadingFont, upgradeFont, infoFont;

        int score = 0;

        Screen screen;

        Level1Room Level1Room;
        

        Rectangle window, damageRect, capacityRect, healthRect, exitRect;

        Rectangle playRect, levelRect;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            screen = Screen.Title;

            level1ShooterGuards = new List<ShooterGuard>();
            level1MeleeGuards = new List<MeleeGuard>();

            wallsL1R1 = new List<Rectangle>();
            wallsL1R2 = new List<Rectangle>();
            wallsL1R3 = new List<Rectangle>();

            //wallsL1R1.Add();

            workbenches = new List<Workbench>();

            player = new Player(new Rectangle(50, 50, 43, 43), new Vector2(50, 50), playerTexture, Color.White, bulletTexture, 100);

            level1ShooterGuards.Add(new ShooterGuard(new Rectangle(500, 500, 50, 50), new Vector2(500, 500), shooterGuardTexture, Color.White, bulletTexture, 25));
            level1MeleeGuards.Add(new MeleeGuard(new Rectangle(600, 200, 50, 50), new Vector2(600, 200), new Vector2(5,5), meleeGuardTexture, 25, 5));

            wallsL1R1.Add(new Rectangle(0, 0, 1000, 20));
            wallsL1R1.Add(new Rectangle(0, 780, 1000, 20));
            wallsL1R1.Add(new Rectangle(0, 0, 20, 800));
            wallsL1R1.Add(new Rectangle(980, 0, 20, 300));
            wallsL1R1.Add(new Rectangle(980, 500, 20, 300));

            wallsL1R2.Add(new Rectangle(0, 0, 400, 20));
            wallsL1R2.Add(new Rectangle(600, 0, 400, 20));
            wallsL1R2.Add(new Rectangle(0, 780, 1000, 20));
            wallsL1R2.Add(new Rectangle(980, 0, 20, 800));
            wallsL1R2.Add(new Rectangle(0, 0, 20, 300));
            wallsL1R2.Add(new Rectangle(0, 500, 20, 300));

            wallsL1R3.Add(new Rectangle(0, 0, 1000, 20));
            wallsL1R3.Add(new Rectangle(0, 780, 400, 20));
            wallsL1R3.Add(new Rectangle(600, 780, 400, 20));
            wallsL1R3.Add(new Rectangle(980, 0, 20, 800));
            wallsL1R3.Add(new Rectangle(0, 0, 20, 800));


            window = new Rectangle(0, 0, 1000, 800);

            damageRect = new Rectangle(80, 200, 240, 520);
            capacityRect = new Rectangle(380, 200, 240, 520);
            healthRect = new Rectangle(680, 200, 240, 520);
            exitRect = new Rectangle(940, 10, 50, 50);

            playRect = new Rectangle(480, 336, 400, 140);
            levelRect = new Rectangle(480, 518, 400, 140);

            workbenches.Add(new Workbench(new Rectangle(200, 0, 150, 100), workbenchTexture));

            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            playerTexture = Content.Load<Texture2D>("Images/player_gun");
            shooterGuardTexture = Content.Load<Texture2D>("Images/guard");
            meleeGuardTexture = Content.Load<Texture2D>("Images/MeleeGuard");
            bulletTexture = Content.Load<Texture2D>("Images/bullet");
            crosshairTexture = Content.Load<Texture2D>("Images/crosshair");
            ammoTexture = Content.Load<Texture2D>("Images/ammo_icon");
            healthBarTexture = Content.Load<Texture2D>("Images/rectangle");
            wallTexture = Content.Load<Texture2D>("Images/brick wall");
            workbenchTexture = Content.Load<Texture2D>("Images/workbench");

            ammoFont = Content.Load<SpriteFont>("Fonts/ammoFont");
            reloadingFont = Content.Load<SpriteFont>("Fonts/reloadingFont");
            upgradeFont = Content.Load<SpriteFont>("Fonts/upgradeFont");
            infoFont = Content.Load<SpriteFont>("Fonts/infoFont");

            titleTexture = Content.Load<Texture2D>("Images/JailhouseIntro");
            upgradesTexture = Content.Load<Texture2D>("Images/Upgrades");

        }

        protected override void Update(GameTime gameTime)
        {
            prevMouseState = mouseState;
            prevKeyboardState = keyboardState;

            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";

            if (screen == Screen.Level1)
            {
                IsMouseVisible = false;
            }

            else
            {
                IsMouseVisible = true;

            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            if (keyboardState.IsKeyDown(Keys.X) && prevKeyboardState.IsKeyUp(Keys.X))
            {
                player.Health -= 10;
            }

            if (player.Health <= 0)
            {
                player.Health = 0;
            }

            if (keyboardState.IsKeyDown(Keys.C) && prevKeyboardState.IsKeyUp(Keys.C))
            {
                player.Health += 10;
            }

            if (player.Health >= player.MaxHealth)
            {
                player.Health = player.MaxHealth;
            }


            // TODO: Add your update logic here

            player.Update(keyboardState, mouseState, prevMouseState, gameTime);

            if (screen == Screen.Title)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    if (playRect.Contains(mouseState.Position))
                    {
                        screen = Screen.Level1;
                        Level1Room = Level1Room.Room1;
                    }
                }
            }

            if (screen == Screen.Level1 && Level1Room == Level1Room.Room1)
            {
                foreach (Rectangle wall in wallsL1R1)
                {
                    if (player.Hitbox.Intersects(wall))
                    {
                        player.DrawRect.Offset(-player.Speed);
                    }
                }

                if (player.DrawRect.Left >= 1000)
                {
                    Level1Room = Level1Room.Room2;
                    player.DrawRect = new Rectangle(0, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                }

            }

            


            if (screen == Screen.Level1 && Level1Room == Level1Room.Room2)
            {
                foreach (Rectangle wall in wallsL1R2)
                {
                    if (player.Hitbox.Intersects(wall))
                    {
                        player.DrawRect.Offset(-player.Speed);
                    }
                }

                foreach (ShooterGuard shooterGuard in level1ShooterGuards)
                {
                    shooterGuard.Update(gameTime, player);

                    for (int i = 0; i < player.Bullets.Count; i++)
                    {

                        if (player.Bullets[i].Hitbox.Intersects(shooterGuard.DrawRect))
                        {
                            shooterGuard.Health -= player.Damage;

                            player.Bullets.Remove(player.Bullets[i]);
                        }

                    }

                    if (player.DrawRect.Right <= 0)
                    {
                        Level1Room = Level1Room.Room1;
                        player.DrawRect = new Rectangle(950, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                    }

                    if (player.DrawRect.Bottom <= 0)
                    {
                        Level1Room = Level1Room.Room3;
                        player.DrawRect = new Rectangle(player.DrawRect.X, 750, player.DrawRect.Width, player.DrawRect.Height);
                    }
                }


                foreach (MeleeGuard meleeGuard in level1MeleeGuards)
                {
                    meleeGuard.Update(gameTime, player);

                    for (int i = 0; i < player.Bullets.Count; i++)
                    {

                        if (player.Bullets[i].Hitbox.Intersects(meleeGuard.DrawRect))
                        {
                            meleeGuard.Health -= player.Damage;

                            player.Bullets.Remove(player.Bullets[i]);
                        }

                    }
                }

                for (int i = 0; i < level1ShooterGuards.Count; i++)
                {
                    for (int j = 0; j < level1ShooterGuards[i].Bullets.Count; j++)
                    {
                        if (level1ShooterGuards[i].Bullets[j].Hitbox.Intersects(player.DrawRect))
                        {
                            player.Health -= 20;

                            level1ShooterGuards[i].Bullets.Remove(level1ShooterGuards[i].Bullets[j]);
                        }
                    }
                }
            }

            if (screen == Screen.Level1 && Level1Room == Level1Room.Room3)
            {
                foreach (Rectangle wall in wallsL1R3)
                {
                    if (player.Hitbox.Intersects(wall))
                    {
                        player.DrawRect.Offset(-player.Speed);
                    }
                }

                if (player.DrawRect.Top >= 800)
                {
                    Level1Room = Level1Room.Room2;
                    player.DrawRect = new Rectangle(player.DrawRect.X, 0, player.DrawRect.Width, player.DrawRect.Height);
                }

            }


            foreach (Workbench workbench in workbenches)
           {
                if (player.Hitbox.Intersects(workbench.Location))
                {
                    if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E))
                    {
                        screen = Screen.Workbench;
                    }
                }
           }





           if (screen == Screen.Workbench)
           {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    if (damageRect.Contains(mouseState.Position))
                    {
                        player.Damage += 1;
                    }

                    if (capacityRect.Contains(mouseState.Position))
                    {
                        player.MaxAmmo += 5;
                    }

                    if (healthRect.Contains(mouseState.Position))
                    {
                        player.MaxHealth += 25;
                    }

                    if (exitRect.Contains(mouseState.Position))
                    {
                        screen = Screen.Level1;
                    }
                }
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (screen == Screen.Title)
            {
                _spriteBatch.Draw(titleTexture, window, Color.White);
            
            }

            if (screen == Screen.Level1 && Level1Room == Level1Room.Room1)
            {
                foreach (Rectangle wall in wallsL1R1)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }

                _spriteBatch.DrawString(infoFont, "WASD to move", new Vector2(300, 50), Color.Black);
            }



            if (screen == Screen.Level1 && Level1Room == Level1Room.Room2)
            {
                _spriteBatch.DrawString(infoFont, "Left Click to shoot guards", new Vector2(100, 600), Color.Black);

                foreach (Rectangle wall in wallsL1R2)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }



                foreach (ShooterGuard shooterGuard1 in level1ShooterGuards)
                {
                    shooterGuard1.Draw(_spriteBatch);
                }

                foreach (MeleeGuard meleeGuard in level1MeleeGuards)
                {
                    meleeGuard.Draw(_spriteBatch);
                }


                _spriteBatch.Draw(healthBarTexture, level1ShooterGuards[0].Hitbox, Color.Red * 0.2f);
                _spriteBatch.Draw(healthBarTexture, level1ShooterGuards[0].DrawRect, Color.Red * 0.2f);




                for (int i = 0; i < level1ShooterGuards.Count; i++)
                {
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(level1ShooterGuards[i].DrawRect.Left - 3, level1ShooterGuards[0].DrawRect.Top - 10, level1ShooterGuards[0].MaxHealth * 2, 4), Color.Gray);
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(level1ShooterGuards[i].DrawRect.Left - 3, level1ShooterGuards[0].DrawRect.Top - 10, level1ShooterGuards[0].Health * 2, 4), Color.Lime);
                }

                for (int i = 0; i < level1MeleeGuards.Count; i++)
                {
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(level1MeleeGuards[i].DrawRect.Left - 3, level1MeleeGuards[0].DrawRect.Top - 10, level1MeleeGuards[0].MaxHealth * 2, 4), Color.Gray);
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(level1MeleeGuards[i].DrawRect.Left - 3, level1MeleeGuards[0].DrawRect.Top - 10, level1MeleeGuards[0].Health * 2, 4), Color.Lime);
                }

                



            }

            if (screen == Screen.Level1 && Level1Room == Level1Room.Room3)
            {
                _spriteBatch.DrawString(infoFont, "E to use workbench", new Vector2(400, 50), Color.Black);


                foreach (Rectangle wall in wallsL1R3)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }

                workbenches[0].Draw(_spriteBatch);
            }

            if (screen == Screen.Workbench)
            {


                _spriteBatch.Draw(upgradesTexture, window, Color.White);
                _spriteBatch.DrawString(upgradeFont, $"{player.Damage} => {player.Damage + 1}", new Vector2(135, 480), Color.Black);
                _spriteBatch.DrawString(upgradeFont, $"{player.MaxAmmo} => {player.MaxAmmo + 5}", new Vector2(430, 480), Color.Black);
                _spriteBatch.DrawString(upgradeFont, $"{player.MaxHealth} => {player.MaxHealth + 25}", new Vector2(705, 480), Color.Black);
                _spriteBatch.DrawString(upgradeFont, $"COST: 20", new Vector2(135, 550), Color.Black);
                _spriteBatch.DrawString(upgradeFont, $"COST: 20", new Vector2(430, 550), Color.Black);
                _spriteBatch.DrawString(upgradeFont, $"COST: 20", new Vector2(730, 550), Color.Black);

                _spriteBatch.DrawString(upgradeFont, $"POINTS: {score}", new Vector2(25, 25), Color.Black);
                _spriteBatch.Draw(healthBarTexture, exitRect, Color.Black);
                _spriteBatch.DrawString(upgradeFont, $"X", new Vector2(955, 10), Color.White);


            }

            if (screen != Screen.Title && screen != Screen.Workbench)
            {
                player.Draw(_spriteBatch);
                _spriteBatch.Draw(ammoTexture, new Rectangle(920, 680, 48, 70), Color.White);
                _spriteBatch.DrawString(ammoFont, player.Ammo.ToString(), new Vector2(855, 695), Color.White);
                _spriteBatch.Draw(healthBarTexture, new Rectangle(50, 720, player.MaxHealth * 2, 20), Color.Gray);
                _spriteBatch.Draw(healthBarTexture, new Rectangle(50, 720, player.Health * 2, 20), Color.Lime);
                _spriteBatch.DrawString(reloadingFont, $"HP", new Vector2(55, 720), Color.Black);


                if (player.Reloading)
                {
                    _spriteBatch.DrawString(reloadingFont, "reloading", new Vector2(860, 750), Color.Red);

                }

                _spriteBatch.DrawString(reloadingFont, $"Points: {score}", new Vector2(40, 40), Color.Black);


                _spriteBatch.Draw(crosshairTexture, mouseState.Position.ToVector2(), null, Color.White, 0, new Vector2(crosshairTexture.Width / 2, crosshairTexture.Height / 2), 0.6f, SpriteEffects.None, 0f);


            }

            

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}



