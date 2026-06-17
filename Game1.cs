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
        Game,
        Workbench
    }

    enum Room
    { 
        Room1,
        Room2,
        Room3,
        Room4,
        Room5,
        Room6,
        Room7,
        Room8
    }

    


    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        MouseState mouseState, prevMouseState;

        KeyboardState keyboardState, prevKeyboardState;

        Player player;

        List<ShooterGuard> shooterL1R2;

        List<ShooterGuard> shooterL1R4;

        List<MeleeGuard> meleeL1R5;

        List<ShooterGuard> shooterL1R7;
        List<MeleeGuard> meleeL1R7;

        List<Rectangle> wallsL1R1;
        List<Rectangle>wallsL1R2;
        List<Rectangle> wallsL1R3;
        List<Rectangle> wallsL1R4;
        List<Rectangle> wallsL1R5;
        List<Rectangle> wallsL1R6;
        List<Rectangle> wallsL1R7;
        List<Rectangle> wallsL1R8;



        List<Rectangle> doorL1R5;

        List<Workbench> workbenches;

        Texture2D playerTexture, shooterGuardTexture, meleeGuardTexture, bulletTexture, crosshairTexture,
                  ammoTexture, healthBarTexture, wallTexture, workbenchTexture, healthBoostTexture, keycardTexture;

        Texture2D titleTexture, upgradesTexture;

        SpriteFont ammoFont, reloadingFont, upgradeFont, infoFont;

        int score = 0;

        int upgradeCost = 10;

        Screen screen;

        Room room;
        

        Rectangle window, damageRect, capacityRect, healthRect, exitRect;

        Rectangle healthBoostL1R3, healthBoostL1R6;

        Rectangle playRect, levelRect;

        Rectangle keycard5Rect;

        bool keycard5;
        
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

            keycard5 = false;

            shooterL1R2 = new List<ShooterGuard>();

            shooterL1R4 = new List<ShooterGuard>();

            meleeL1R5 = new List<MeleeGuard>();

            shooterL1R7 = new List<ShooterGuard>();
            meleeL1R7 = new List<MeleeGuard>();

            wallsL1R1 = new List<Rectangle>();
            wallsL1R2 = new List<Rectangle>();
            wallsL1R3 = new List<Rectangle>();
            wallsL1R4 = new List<Rectangle>();
            wallsL1R5 = new List<Rectangle>();
            wallsL1R6 = new List<Rectangle>();
            wallsL1R7 = new List<Rectangle>();

            doorL1R5 = new List<Rectangle>();

            workbenches = new List<Workbench>();

            player = new Player(new Rectangle(50, 50, 43, 43), new Vector2(50, 50), playerTexture, Color.White, bulletTexture, 100);

            shooterL1R2.Add(new ShooterGuard(new Rectangle(500, 500, 50, 50), new Vector2(500, 500), shooterGuardTexture, Color.White, bulletTexture, 25));
            shooterL1R2.Add(new ShooterGuard(new Rectangle(200, 50, 50, 50), new Vector2(200, 50), shooterGuardTexture, Color.White, bulletTexture, 25));

            shooterL1R4.Add(new ShooterGuard(new Rectangle(100, 60, 50, 50), new Vector2(100, 60), shooterGuardTexture, Color.White, bulletTexture, 25));
            shooterL1R4.Add(new ShooterGuard(new Rectangle(600, 700, 50, 50), new Vector2(600, 700), shooterGuardTexture, Color.White, bulletTexture, 25));
            shooterL1R4.Add(new ShooterGuard(new Rectangle(800, 200, 50, 50), new Vector2(800, 200), shooterGuardTexture, Color.White, bulletTexture, 25));
            shooterL1R4.Add(new ShooterGuard(new Rectangle(400, 550, 50, 50), new Vector2(400, 550), shooterGuardTexture, Color.White, bulletTexture, 25));
            shooterL1R4.Add(new ShooterGuard(new Rectangle(500, 40, 50, 50), new Vector2(500, 40), shooterGuardTexture, Color.White, bulletTexture, 25));

            meleeL1R5.Add(new MeleeGuard(new Rectangle(475, 50, 50, 50), new Vector2(475, 50), new Vector2(10, 10), meleeGuardTexture, 25, 300, 50));

            shooterL1R7.Add(new ShooterGuard(new Rectangle(50, 50, 50, 50), new Vector2(50, 50), shooterGuardTexture, Color.White, bulletTexture, 35));
            shooterL1R7.Add(new ShooterGuard(new Rectangle(50, 50, 50, 50), new Vector2(50, 950), shooterGuardTexture, Color.White, bulletTexture, 35));

            meleeL1R5.Add(new MeleeGuard(new Rectangle(475, 50, 50, 50), new Vector2(475, 50), new Vector2(10, 10), meleeGuardTexture, 25, 300, 50));

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
            wallsL1R3.Add(new Rectangle(0, 0, 20, 800));
            wallsL1R3.Add(new Rectangle(980, 0, 20, 300));
            wallsL1R3.Add(new Rectangle(980, 500, 20, 300));

            wallsL1R4.Add(new Rectangle(0, 0, 400, 20));
            wallsL1R4.Add(new Rectangle(600, 0, 400, 20));
            wallsL1R4.Add(new Rectangle(0, 780, 1000, 20));
            wallsL1R4.Add(new Rectangle(980, 0, 20, 800));
            wallsL1R4.Add(new Rectangle(0, 0, 20, 300));
            wallsL1R4.Add(new Rectangle(0, 500, 20, 300));

            wallsL1R5.Add(new Rectangle(0, 0, 1000, 20));
            wallsL1R5.Add(new Rectangle(0, 0, 20, 300));
            wallsL1R5.Add(new Rectangle(0, 500, 20, 300));
            wallsL1R5.Add(new Rectangle(980, 0, 20, 300));
            wallsL1R5.Add(new Rectangle(980, 500, 20, 300));
            wallsL1R5.Add(new Rectangle(0, 780, 400, 20));
            wallsL1R5.Add(new Rectangle(600, 780, 400, 20));

            doorL1R5.Add(new Rectangle(980, 300, 20, 200));

            wallsL1R6.Add(new Rectangle(0, 0, 1000, 20));
            wallsL1R6.Add(new Rectangle(0, 980, 1000, 20));
            wallsL1R6.Add(new Rectangle(0, 0, 20, 300));
            wallsL1R6.Add(new Rectangle(0, 500, 20, 300));
            wallsL1R6.Add(new Rectangle(980, 0, 20, 800));

            wallsL1R7.Add(new Rectangle(0, 0, 400, 20));
            wallsL1R7.Add(new Rectangle(600, 0, 400, 20));
            wallsL1R7.Add(new Rectangle(0, 0, 20, 1000));
            wallsL1R7.Add(new Rectangle(980, 0, 20, 300));
            wallsL1R7.Add(new Rectangle(980, 0, 20, 500));
            wallsL1R7.Add(new Rectangle(0, 780, 1000, 20));



            healthBoostL1R3 = new Rectangle(400, 350, 60, 60);
            healthBoostL1R6 = new Rectangle(60, 60, 60, 60);

            keycard5Rect = new Rectangle(450, 350, 100, 75);

            window = new Rectangle(0, 0, 1000, 800);

            damageRect = new Rectangle(80, 200, 240, 520);
            capacityRect = new Rectangle(380, 200, 240, 520);
            healthRect = new Rectangle(680, 200, 240, 520);
            exitRect = new Rectangle(940, 10, 50, 50);

            playRect = new Rectangle(480, 336, 400, 140);
            levelRect = new Rectangle(480, 518, 400, 140);

            workbenches.Add(new Workbench(new Rectangle(200, 0, 150, 100), workbenchTexture));
            workbenches.Add(new Workbench(new Rectangle(500, 0, 150, 150), workbenchTexture));

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
            healthBoostTexture = Content.Load<Texture2D>("Images/healthboost");
            keycardTexture = Content.Load<Texture2D>("Images/keycard3");

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

            if (screen == Screen.Game)
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

            if (screen != Screen.Title && screen != Screen.Workbench)
            { 
                player.Update(keyboardState, mouseState, prevMouseState, gameTime, window);
            }

            if (screen == Screen.Title)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    if (playRect.Contains(mouseState.Position))
                    {
                        screen = Screen.Game;
                        room = Room.Room1;
                    }
                }
            }

            if (screen == Screen.Game && room == Room.Room1)
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
                    room = Room.Room2;
                    player.DrawRect = new Rectangle(0, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                    player.ClearBullets();

                }

            }

            


            if (screen == Screen.Game && room == Room.Room2)
            {
                foreach (Rectangle wall in wallsL1R2)
                {
                    if (player.Hitbox.Intersects(wall))
                    {
                        player.DrawRect.Offset(-player.Speed);
                    }
                }

                if (player.DrawRect.Right <= 0)
                {
                    room = Room.Room1;
                    player.DrawRect = new Rectangle(950, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                    player.ClearBullets();

                }

                if (player.DrawRect.Bottom <= 0)
                {
                    room = Room.Room3;
                    player.DrawRect = new Rectangle(player.DrawRect.X, 750, player.DrawRect.Width, player.DrawRect.Height);
                    player.ClearBullets();

                }

                foreach (ShooterGuard shooterGuard in shooterL1R2)
                {
                    shooterGuard.Update(gameTime, player, window);

                    for (int i = 0; i < player.Bullets.Count; i++)
                    {

                        if (player.Bullets[i].Hitbox.Intersects(shooterGuard.DrawRect))
                        {
                            shooterGuard.Health -= player.Damage;

                            player.Bullets.Remove(player.Bullets[i]);
                        }

                    }


                    
                }






                for (int i = 0; i < shooterL1R2.Count; i++)
                {

                    for (int j = 0; j < shooterL1R2[i].Bullets.Count; j++)
                    {
                        if (shooterL1R2[i].Bullets[j].Hitbox.Intersects(player.DrawRect))
                        {
                            player.Health -= 20;
                            shooterL1R2[i].Bullets.Remove(shooterL1R2[i].Bullets[j]);
                            j--;
                        }
                    }

                    if (shooterL1R2[i].Health <= 0)
                    {
                        shooterL1R2[i].ClearBullets();
                        shooterL1R2.Remove(shooterL1R2[i]);
                        score += 10;
                        i--;

                    }

                }
            }

            if (screen == Screen.Game && room == Room.Room3)
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
                    room = Room.Room2;
                    player.DrawRect = new Rectangle(player.DrawRect.X, 0, player.DrawRect.Width, player.DrawRect.Height);
                    player.ClearBullets();
                }

                if (player.DrawRect.Left >= 1000)
                {
                    room = Room.Room4;
                    player.DrawRect = new Rectangle(0, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                    player.ClearBullets();
                }

                if (player.DrawRect.Intersects(healthBoostL1R3))
                {
                    player.Health = player.MaxHealth;
                    healthBoostL1R3 = new Rectangle(10000, 10000, 1, 1);
                }


                if (player.Hitbox.Intersects(workbenches[0].Location))
                {
                    if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E))
                    {
                        screen = Screen.Workbench;
                    }
                }
            }


            

            
            


            if (screen == Screen.Game && room == Room.Room4)
            {
                foreach (Rectangle wall in wallsL1R4)
                {
                    if (player.Hitbox.Intersects(wall))
                    {
                        player.DrawRect.Offset(-player.Speed);
                    }
                }

                if (player.DrawRect.Right <= 0)
                {
                    room = Room.Room3;
                    player.DrawRect = new Rectangle(950, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                    player.ClearBullets();
                }

               if (player.DrawRect.Bottom < 0)
               {
                    room = Room.Room5;
                    player.DrawRect = new Rectangle(player.DrawRect.X, 750, player.DrawRect.Width, player.DrawRect.Height);
                    player.ClearBullets();
               }

                foreach (ShooterGuard shooterGuard in shooterL1R4)
                {
                    shooterGuard.Update(gameTime, player, window);

                    for (int i = 0; i < player.Bullets.Count; i++)
                    {

                        if (player.Bullets[i].Hitbox.Intersects(shooterGuard.DrawRect))
                        {
                            shooterGuard.Health -= player.Damage;

                            player.Bullets.Remove(player.Bullets[i]);
                        }

                    }



                }

                for (int i = 0; i < shooterL1R4.Count; i++)
                {

                    for (int j = 0; j < shooterL1R4[i].Bullets.Count; j++)
                    {
                        if (shooterL1R4[i].Bullets[j].Hitbox.Intersects(player.DrawRect))
                        {
                            player.Health -= 20;
                            shooterL1R4[i].Bullets.Remove(shooterL1R4[i].Bullets[j]);
                            j--;
                        }
                    }

                    if (shooterL1R4[i].Health <= 0)
                    {
                        shooterL1R4[i].ClearBullets();
                        shooterL1R4.Remove(shooterL1R4[i]);
                        score += 10;
                        i--;

                    }

                    



                }
            }


            if (screen == Screen.Game && room == Room.Room5)
            {
                foreach (MeleeGuard meleeGuard in meleeL1R5)
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


                for (int i = 0; i < meleeL1R5.Count; i++)
                {
                    if (meleeL1R5[i].Health <= 0)
                    {
                        score += 10;
                        meleeL1R5.Remove(meleeL1R5[i]);
                        i--;
                    }
                }

                foreach (Rectangle wall in wallsL1R5)
                {
                    if (player.Hitbox.Intersects(wall))
                    {
                        player.DrawRect.Offset(-player.Speed);
                    }
                }

                if (player.DrawRect.Right < 0)
                {
                    room = Room.Room7;
                    player.DrawRect = new Rectangle(950, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                    player.ClearBullets();
                }

                if (player.DrawRect.Left > 1000)
                {
                    room = Room.Room6;
                    player.DrawRect = new Rectangle(0, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                    player.ClearBullets();
                }


                if ( meleeL1R5.Count == 0 && player.DrawRect.Intersects(keycard5Rect))
                {
                    keycard5 = true;
                    keycard5Rect = new Rectangle(9000, 9000, 1, 1);
                    doorL1R5.Remove(doorL1R5[0]);
                }




                


            }


            if (screen == Screen.Game && room == Room.Room6)
            {
                foreach (Rectangle wall in wallsL1R6)
                {
                    if (player.Hitbox.Intersects(wall))
                    {
                        player.DrawRect.Offset(-player.Speed);
                    }
                }

                if (player.Hitbox.Intersects(workbenches[1].Location))
                {
                    if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E))
                    {
                        screen = Screen.Workbench;
                    }
                }

                if (player.DrawRect.Right < 0)
                {
                    room = Room.Room5;
                    player.DrawRect = new Rectangle(950, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                }

                if (player.DrawRect.Intersects(healthBoostL1R6))
                {
                    player.Health = player.MaxHealth;
                    healthBoostL1R6 = new Rectangle(10000, 10000, 1, 1);
                }

            }

            if (screen == Screen.Game && room == Room.Room7)
            {
                foreach (Rectangle wall in wallsL1R7)
                {
                    if (player.Hitbox.Intersects(wall))
                    {
                        player.DrawRect.Offset(-player.Speed);
                    }
                }


                foreach (MeleeGuard meleeGuard in meleeL1R7)
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


                for (int i = 0; i < shooterL1R7.Count; i++)
                {

                    for (int j = 0; j < shooterL1R7[i].Bullets.Count; j++)
                    {
                        if (shooterL1R7[i].Bullets[j].Hitbox.Intersects(player.DrawRect))
                        {
                            player.Health -= 20;
                            shooterL1R7[i].Bullets.Remove(shooterL1R7[i].Bullets[j]);
                            j--;
                        }
                    }

                    if (shooterL1R7[i].Health <= 0)
                    {
                        shooterL1R7[i].ClearBullets();
                        shooterL1R7.Remove(shooterL1R4[i]);
                        score += 10;
                        i--;

                    }





                }

                if (player.DrawRect.Left >= 1000)
                {
                    room = Room.Room5;
                    player.DrawRect = new Rectangle(0, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                }

                if (player.DrawRect.Left >= 1000)
                {
                    room = Room.Room8;
                    player.DrawRect = new Rectangle(player.DrawRect.X, 750, player.DrawRect.Width, player.DrawRect.Height);
                }

            }

            if (screen == Screen.Workbench)
           {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    if (damageRect.Contains(mouseState.Position))
                    {
                        if (score >= 20 && player.Damage < 10)
                        {
                            player.Damage += 1;
                            score -= upgradeCost;

                            if (upgradeCost <= 50)
                            {
                                upgradeCost += 5;
                            }
                        }
                    }

                    if (capacityRect.Contains(mouseState.Position))
                    {
                        if (score >= 20 && player.MaxAmmo < 35)
                        {
                            player.MaxAmmo += 5;
                            player.Ammo = player.MaxAmmo;

                            score -= upgradeCost;

                            if (upgradeCost <= 50)
                            {
                                upgradeCost += 5;
                            }
                        }
                    }

                    if (healthRect.Contains(mouseState.Position))
                    {
                        if (score >= 20 && player.MaxHealth < 200)
                        {
                            player.MaxHealth += 20;
                            player.Health += 20;
                            score -= upgradeCost;

                            if (upgradeCost <= 50)
                            {
                                upgradeCost += 5;
                            }
                        }
                    }


                    if (exitRect.Contains(mouseState.Position))
                    {
                        screen = Screen.Game;
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

            if (screen == Screen.Game && room == Room.Room1)
            {
                foreach (Rectangle wall in wallsL1R1)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }

                _spriteBatch.DrawString(infoFont, "Left Click to shoot, R to reload", new Vector2(200, 600), Color.Black);


                _spriteBatch.DrawString(infoFont, "WASD to move", new Vector2(300, 50), Color.Black);
            }



            if (screen == Screen.Game && room == Room.Room2)
            {

                foreach (Rectangle wall in wallsL1R2)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }



                foreach (ShooterGuard shooterGuard in shooterL1R2)
                {
                    shooterGuard.Draw(_spriteBatch);
                }

                






                for (int i = 0; i < shooterL1R2.Count; i++)
                {
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(shooterL1R2[i].DrawRect.Left - 3, shooterL1R2[i].DrawRect.Top - 10, shooterL1R2[i].MaxHealth * 2, 4), Color.Gray);
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(shooterL1R2[i].DrawRect.Left - 3, shooterL1R2[i].DrawRect.Top - 10, shooterL1R2[i].Health * 2, 4), Color.Lime);
                }

           
                



            }

            if (screen == Screen.Game && room == Room.Room3)
            {
                _spriteBatch.DrawString(infoFont, "E to use workbench", new Vector2(400, 50), Color.Black);


                foreach (Rectangle wall in wallsL1R3)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }

                workbenches[0].Draw(_spriteBatch);

                _spriteBatch.Draw(healthBoostTexture, healthBoostL1R3, Color.White);


            }

            if (screen == Screen.Game && room == Room.Room4)
            {

                foreach (Rectangle wall in wallsL1R4)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }

                foreach (ShooterGuard shooterGuard in shooterL1R4)
                {
                    shooterGuard.Draw(_spriteBatch);
                }

                for (int i = 0; i < shooterL1R4.Count; i++)
                {
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(shooterL1R4[i].DrawRect.Left - 3, shooterL1R4[i].DrawRect.Top - 10, shooterL1R4[i].MaxHealth * 2, 4), Color.Gray);
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(shooterL1R4[i].DrawRect.Left - 3, shooterL1R4[i].DrawRect.Top - 10, shooterL1R4[i].Health * 2, 4), Color.Lime);
                }



            }

            if (screen == Screen.Game && room == Room.Room5)
            {
                foreach (Rectangle wall in wallsL1R5)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }

                foreach (Rectangle door in doorL1R5)
                {
                    _spriteBatch.Draw(healthBarTexture, door, Color.Red);
                }


                for (int i = 0; i < meleeL1R5.Count; i++)
                {
                    meleeL1R5[i].Draw(_spriteBatch);

                    _spriteBatch.Draw(healthBarTexture, new Rectangle(meleeL1R5[i].DrawRect.Left - 3, meleeL1R5[i].DrawRect.Top - 10, meleeL1R5[i].MaxHealth * 2, 4), Color.Gray);
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(meleeL1R5[i].DrawRect.Left - 3, meleeL1R5[i].DrawRect.Top - 10, meleeL1R5[i].Health * 2, 4), Color.Lime);
                }

                if (meleeL1R5.Count == 0)
                {
                    _spriteBatch.Draw(keycardTexture, keycard5Rect, Color.White);
                }

            }



            if (screen == Screen.Game && room == Room.Room6)
            {
                foreach (Rectangle wall in wallsL1R6)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }

                workbenches[1].Draw(_spriteBatch);

                _spriteBatch.Draw(healthBoostTexture, healthBoostL1R6, Color.White);


            }


            if (screen == Screen.Game && room == Room.Room7)
            {
                foreach (Rectangle wall in wallsL1R7)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }


                for (int i = 0; i < meleeL1R7.Count; i++)
                {
                    meleeL1R7[i].Draw(_spriteBatch);

                    _spriteBatch.Draw(healthBarTexture, new Rectangle(meleeL1R7[i].DrawRect.Left - 3, meleeL1R7[i].DrawRect.Top - 10, meleeL1R7[i].MaxHealth * 2, 4), Color.Gray);
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(meleeL1R7[i].DrawRect.Left - 3, meleeL1R7[i].DrawRect.Top - 10, meleeL1R7[i].Health * 2, 4), Color.Lime);
                }


                for (int i = 0; i < shooterL1R7.Count; i++)
                {
                    shooterL1R7[i].Draw(_spriteBatch);

                    _spriteBatch.Draw(healthBarTexture, new Rectangle(shooterL1R7[i].DrawRect.Left - 3, shooterL1R7[i].DrawRect.Top - 10, shooterL1R7[i].MaxHealth * 2, 4), Color.Gray);
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(shooterL1R7[i].DrawRect.Left - 3, shooterL1R7[i].DrawRect.Top - 10, shooterL1R7[i].Health * 2, 4), Color.Lime);
                }
            }


            if (screen == Screen.Workbench)
            {


                _spriteBatch.Draw(upgradesTexture, window, Color.White);

                if (player.Damage < 10)
                {
                    _spriteBatch.DrawString(upgradeFont, $"COST: {upgradeCost}", new Vector2(135, 550), Color.Black);
                    _spriteBatch.DrawString(upgradeFont, $"{player.Damage} => {player.Damage + 1}", new Vector2(135, 480), Color.Black);
                }
                else
                {
                    _spriteBatch.DrawString(upgradeFont, $"MAXED", new Vector2(140, 480), Color.Black);
                }

                if (player.MaxAmmo < 35)
                {
                    _spriteBatch.DrawString(upgradeFont, $"COST: {upgradeCost}", new Vector2(430, 550), Color.Black);
                    _spriteBatch.DrawString(upgradeFont, $"{player.MaxAmmo} => {player.MaxAmmo + 5}", new Vector2(430, 480), Color.Black);
                }
                else
                {
                    _spriteBatch.DrawString(upgradeFont, $"MAXED", new Vector2(435, 480), Color.Black);
                }

                if (player.MaxHealth < 200)
                {
                    _spriteBatch.DrawString(upgradeFont, $"COST:  {upgradeCost}", new Vector2(740, 550), Color.Black);
                    _spriteBatch.DrawString(upgradeFont, $"{player.MaxHealth} => {player.MaxHealth + 25}", new Vector2(705, 480), Color.Black);
                }
                else
                {
                    _spriteBatch.DrawString(upgradeFont, $"MAXED", new Vector2(740, 480), Color.Black);
                }


                
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



