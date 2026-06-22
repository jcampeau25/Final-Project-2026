using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        Workbench,
        Info,
        Dead,
        Escaped
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
        Room8,
        Room9,
        Room10
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

        List<ShooterGuard> shooterL1R8;

        List<MeleeGuard> meleeL1R8;

        List<ShooterGuard> warden;

        List<Rectangle> wallsL1R1;
        List<Rectangle> wallsL1R2;
        List<Rectangle> wallsL1R3;
        List<Rectangle> wallsL1R4;
        List<Rectangle> wallsL1R5;
        List<Rectangle> wallsL1R6;
        List<Rectangle> wallsL1R7;
        List<Rectangle> wallsL1R8;
        List<Rectangle> wallsL1R9;
        List<Rectangle> wallsL1R10;


        List<Rectangle> doorL1R5;
        List<Rectangle> doorL1R8;
        List<Rectangle> doorL1R10;

        List<Workbench> workbenches;

        Texture2D playerTexture, shooterGuardTexture, meleeGuardTexture, bulletTexture, crosshairTexture,
                  ammoTexture, healthBarTexture, wallTexture, workbenchTexture, healthBoostTexture, keycardTexture;

        Texture2D titleTexture, upgradesTexture, infoTexture, escapedTexture, deathTexture;

        SpriteFont ammoFont, reloadingFont, upgradeFont, infoFont;

        int score = 0;

        int upgradeCost = 10;

        Screen screen;

        Room room, respawnRoom;

        SoundEffect gunshotSound, guardSound, themeMusic, reloadSound, upgradeSound, healthSound;
        SoundEffectInstance themeMusicInstance;

        Rectangle window, damageRect, capacityRect, healthRect, exitRect;

        Rectangle healthBoostL1R3, healthBoostL1R6, healthBoostL1R9;

        Rectangle playRect, infoRect, returnRect, respawnRect, gameEndRect;

        Rectangle keycard5Rect, keycard8Rect, keycard10Rect;

        Vector2 checkpoint;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            themeMusicInstance.Play();

            screen = Screen.Title;


            shooterL1R2 = new List<ShooterGuard>();

            shooterL1R4 = new List<ShooterGuard>();

            meleeL1R5 = new List<MeleeGuard>();

            shooterL1R7 = new List<ShooterGuard>();
            meleeL1R7 = new List<MeleeGuard>();

            shooterL1R8 = new List<ShooterGuard>();
            meleeL1R8 = new List<MeleeGuard>();

            warden = new List<ShooterGuard>();

            wallsL1R1 = new List<Rectangle>();
            wallsL1R2 = new List<Rectangle>();
            wallsL1R3 = new List<Rectangle>();
            wallsL1R4 = new List<Rectangle>();
            wallsL1R5 = new List<Rectangle>();
            wallsL1R6 = new List<Rectangle>();
            wallsL1R7 = new List<Rectangle>();
            wallsL1R8 = new List<Rectangle>();
            wallsL1R9 = new List<Rectangle>();
            wallsL1R10 = new List<Rectangle>();

            doorL1R5 = new List<Rectangle>();
            doorL1R8 = new List<Rectangle>();
            doorL1R10 =  new List<Rectangle>();

            workbenches = new List<Workbench>();

            player = new Player(new Rectangle(50, 50, 43, 43), new Vector2(50, 50), playerTexture, Color.White, bulletTexture, 100, gunshotSound, reloadSound);

            shooterL1R2.Add(new ShooterGuard(new Rectangle(500, 500, 50, 50), new Vector2(500, 500), shooterGuardTexture, Color.White, bulletTexture, 25, guardSound, gunshotSound));
            shooterL1R2.Add(new ShooterGuard(new Rectangle(200, 50, 50, 50), new Vector2(200, 50), shooterGuardTexture, Color.White, bulletTexture, 25, guardSound, gunshotSound));

            shooterL1R4.Add(new ShooterGuard(new Rectangle(100, 60, 50, 50), new Vector2(100, 60), shooterGuardTexture, Color.White, bulletTexture, 25, guardSound, gunshotSound));
            shooterL1R4.Add(new ShooterGuard(new Rectangle(600, 700, 50, 50), new Vector2(600, 700), shooterGuardTexture, Color.White, bulletTexture, 25, guardSound, gunshotSound));
            shooterL1R4.Add(new ShooterGuard(new Rectangle(800, 200, 50, 50), new Vector2(800, 200), shooterGuardTexture, Color.White, bulletTexture, 25, guardSound, gunshotSound));
            shooterL1R4.Add(new ShooterGuard(new Rectangle(400, 550, 50, 50), new Vector2(400, 550), shooterGuardTexture, Color.White, bulletTexture, 25, guardSound, gunshotSound));
            shooterL1R4.Add(new ShooterGuard(new Rectangle(500, 40, 50, 50), new Vector2(500, 40), shooterGuardTexture, Color.White, bulletTexture, 25, guardSound, gunshotSound));

            meleeL1R5.Add(new MeleeGuard(new Rectangle(475, 50, 50, 50), new Vector2(475, 50), new Vector2(10, 10), meleeGuardTexture, 25, 300, 50, guardSound));

            shooterL1R7.Add(new ShooterGuard(new Rectangle(50, 50, 50, 50), new Vector2(50, 150), shooterGuardTexture, Color.White, bulletTexture, 35, guardSound, guardSound));
            shooterL1R7.Add(new ShooterGuard(new Rectangle(50, 950, 50, 50), new Vector2(50, 650), shooterGuardTexture, Color.White, bulletTexture, 35, guardSound, gunshotSound));

            meleeL1R7.Add(new MeleeGuard(new Rectangle(475, 50, 50, 50), new Vector2(475, 50), new Vector2(10, 10), meleeGuardTexture, 25, 300, 50, guardSound));

            shooterL1R8.Add(new ShooterGuard(new Rectangle(170, 140, 50, 50), new Vector2(170, 140), shooterGuardTexture, Color.White, bulletTexture, 35, guardSound, gunshotSound));
            shooterL1R8.Add(new ShooterGuard(new Rectangle(260, 160, 50, 50), new Vector2(260, 160), shooterGuardTexture, Color.White, bulletTexture, 35, guardSound, gunshotSound));
            shooterL1R8.Add(new ShooterGuard(new Rectangle(170, 140, 50, 50), new Vector2(830, 140), shooterGuardTexture, Color.White, bulletTexture, 35, guardSound, gunshotSound));
            shooterL1R8.Add(new ShooterGuard(new Rectangle(260, 160, 50, 50), new Vector2(740, 160), shooterGuardTexture, Color.White, bulletTexture, 35, guardSound, gunshotSound));

            meleeL1R8.Add(new MeleeGuard(new Rectangle(100, 750, 50, 50), new Vector2(100, 750), new Vector2(10, 10), meleeGuardTexture, 25, 300, 50, guardSound));
            meleeL1R8.Add(new MeleeGuard(new Rectangle(900, 750, 50, 50), new Vector2(900, 750), new Vector2(10, 10), meleeGuardTexture, 25, 300, 50, guardSound));

            warden.Add(new ShooterGuard(new Rectangle(450, 350, 100, 100), new Vector2(450, 350), shooterGuardTexture, Color.White, bulletTexture, 600, guardSound, gunshotSound));
            warden[0].FireRate = 0.5;
            warden[0].DrawRect = new Rectangle(new Vector2(450, 350).ToPoint(), new Point(100, 100));


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
            wallsL1R7.Add(new Rectangle(980, 500, 20, 300));
            wallsL1R7.Add(new Rectangle(0, 780, 1000, 20));

            wallsL1R8.Add(new Rectangle(0, 0, 20, 800));
            wallsL1R8.Add(new Rectangle(980, 0, 20, 800));
            wallsL1R8.Add(new Rectangle(0, 0, 400, 20));
            wallsL1R8.Add(new Rectangle(600, 0, 400, 20));
            wallsL1R8.Add(new Rectangle(0, 780, 400, 20));
            wallsL1R8.Add(new Rectangle(600, 780, 400, 20));

            doorL1R8.Add(new Rectangle(400, 0, 200, 20));

            wallsL1R9.Add(new Rectangle(0, 0, 1000, 20));
            wallsL1R9.Add(new Rectangle(0, 780, 400, 20));
            wallsL1R9.Add(new Rectangle(600, 780, 400, 20));
            wallsL1R9.Add(new Rectangle(0, 0, 20, 800));
            wallsL1R9.Add(new Rectangle(980, 0, 20, 300));
            wallsL1R9.Add(new Rectangle(980, 500, 20, 300));

            wallsL1R10.Add(new Rectangle(0, 0, 20, 300));
            wallsL1R10.Add(new Rectangle(0, 500, 20, 300));
            wallsL1R10.Add(new Rectangle(0, 0, 1000, 20));
            wallsL1R10.Add(new Rectangle(0, 780, 1000, 20));
            wallsL1R10.Add(new Rectangle(980, 0, 20, 300));
            wallsL1R10.Add(new Rectangle(980, 500, 20, 300));

            doorL1R10.Add(new Rectangle(980, 300, 20, 200));
            doorL1R10.Add(new Rectangle(0, 300, 20, 200));

            healthBoostL1R3 = new Rectangle(400, 350, 60, 60);
            healthBoostL1R6 = new Rectangle(60, 60, 60, 60);
            healthBoostL1R9 = new Rectangle(570, 370, 60, 60);

            keycard5Rect = new Rectangle(450, 350, 100, 75);
            keycard8Rect = new Rectangle(450, 350, 100, 75);
            keycard10Rect = new Rectangle(450, 350, 100, 75);

            window = new Rectangle(0, 0, 1000, 800);

            damageRect = new Rectangle(80, 200, 240, 520);
            capacityRect = new Rectangle(380, 200, 240, 520);
            healthRect = new Rectangle(680, 200, 240, 520);
            exitRect = new Rectangle(940, 10, 50, 50);
            gameEndRect = new Rectangle(50, 205, 280, 95);

            playRect = new Rectangle(480, 336, 400, 140);
            infoRect = new Rectangle(480, 518, 400, 140);
            returnRect = new Rectangle(380, 520, 240, 150);
            respawnRect = new Rectangle(260, 450, 480, 165);

            workbenches.Add(new Workbench(new Rectangle(200, 0, 150, 100), workbenchTexture));
            workbenches.Add(new Workbench(new Rectangle(500, 0, 150, 150), workbenchTexture));
            workbenches.Add(new Workbench(new Rectangle(425, 0, 150, 150), workbenchTexture));

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

            guardSound = Content.Load<SoundEffect>("Sounds/guardDead");
            gunshotSound = Content.Load<SoundEffect>("Sounds/gunshot");
            reloadSound = Content.Load<SoundEffect>("Sounds/reload");
            upgradeSound = Content.Load<SoundEffect>("Sounds/upgrade");
            healthSound = Content.Load<SoundEffect>("Sounds/heal");
            themeMusic = Content.Load<SoundEffect>("Sounds/CJ3 Music");

            themeMusicInstance = themeMusic.CreateInstance();
            themeMusicInstance.IsLooped = true;
            themeMusicInstance.Volume = (float)0.25;

            ammoFont = Content.Load<SpriteFont>("Fonts/ammoFont");
            reloadingFont = Content.Load<SpriteFont>("Fonts/reloadingFont");
            upgradeFont = Content.Load<SpriteFont>("Fonts/upgradeFont");
            infoFont = Content.Load<SpriteFont>("Fonts/infoFont");

            titleTexture = Content.Load<Texture2D>("Images/COLTONS JAILHOUSE");
            infoTexture = Content.Load<Texture2D>("Images/InfoScreen");
            escapedTexture = Content.Load<Texture2D>("Images/Escaped");
            deathTexture = Content.Load<Texture2D>("Images/deathScreen");
            upgradesTexture = Content.Load<Texture2D>("Images/Upgrades");


        }

        protected override void Update(GameTime gameTime)
        {
            prevMouseState = mouseState;
            prevKeyboardState = keyboardState;

            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

            this.Window.Title = $"Colton's Jailhouse 3";

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


            

            if (player.Health >= player.MaxHealth)
            {
                player.Health = player.MaxHealth;
            }

            if (player.Health <= 0)
            {
                screen = Screen.Dead;
            }

            // TODO: Add your update logic here

            if (screen == Screen.Game)
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

                    if (infoRect.Contains(mouseState.Position))
                    {
                        screen = Screen.Info;
                    }
                }
            }

            if (screen == Screen.Info)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    if (returnRect.Contains(mouseState.Position))
                    {
                        screen = Screen.Title;
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
                        guardSound.Play();
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
                    healthSound.Play();
                    player.Health = player.MaxHealth;
                    healthBoostL1R3 = new Rectangle(10000, 10000, 1, 1);
                }


                if (player.Hitbox.Intersects(workbenches[0].Location))
                {
                    if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E))
                    {
                        checkpoint = new Vector2(600, 450);
                        respawnRoom = Room.Room3;
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
                        guardSound.Play();
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
                        guardSound.Play();
                        score += 15;
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

                if (player.DrawRect.Top > 800)
                {
                    room = Room.Room4;
                    player.DrawRect = new Rectangle(0, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                    player.ClearBullets();
                }

                if ( meleeL1R5.Count == 0 && player.DrawRect.Intersects(keycard5Rect))
                {
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
                        checkpoint = new Vector2(600, 450);
                        respawnRoom = Room.Room6;
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
                    healthSound.Play();
                    player.Health = player.MaxHealth;
                    healthBoostL1R6 = new Rectangle(9000, 9000, 1, 1);
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


                for (int i = 0; i < meleeL1R7.Count; i++)
                {
                    if (meleeL1R7[i].Health <= 0)
                    {
                        guardSound.Play();
                        score += 10;
                        meleeL1R7.Remove(meleeL1R7[i]);
                        i--;
                    }
                }

                foreach (ShooterGuard shooterGuard in shooterL1R7)
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
                        guardSound.Play();
                        shooterL1R7[i].ClearBullets();
                        shooterL1R7.Remove(shooterL1R7[i]);
                        score += 10;
                        i--;

                    }





                }

                if (player.DrawRect.Left >= 1000)
                {
                    room = Room.Room5;
                    player.DrawRect = new Rectangle(0, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                }

                if (player.DrawRect.Top <= 0)
                {
                    room = Room.Room8;
                    player.DrawRect = new Rectangle(player.DrawRect.X, 750, player.DrawRect.Width, player.DrawRect.Height);
                }

            }

            if (screen == Screen.Game && room == Room.Room8)
            {
                foreach (Rectangle wall in wallsL1R8)
                {
                    if (player.Hitbox.Intersects(wall))
                    {
                        player.DrawRect.Offset(-player.Speed);
                    }


                }


                foreach (MeleeGuard meleeGuard in meleeL1R8)
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


                for (int i = 0; i < meleeL1R8.Count; i++)
                {
                    if (meleeL1R8[i].Health <= 0)
                    {
                        guardSound.Play();
                        score += 10;
                        meleeL1R8.Remove(meleeL1R8[i]);
                        i--;
                    }
                }

                foreach (ShooterGuard shooterGuard in shooterL1R8)
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

                for (int i = 0; i < shooterL1R8.Count; i++)
                {

                    for (int j = 0; j < shooterL1R8[i].Bullets.Count; j++)
                    {
                        if (shooterL1R8[i].Bullets[j].Hitbox.Intersects(player.DrawRect))
                        {
                            player.Health -= 20;
                            shooterL1R8[i].Bullets.Remove(shooterL1R8[i].Bullets[j]);
                            j--;
                        }
                    }

                    if (shooterL1R8[i].Health <= 0)
                    {
                        guardSound.Play();
                        shooterL1R8[i].ClearBullets();
                        shooterL1R8.Remove(shooterL1R8[i]);
                        score += 10;
                        i--;

                    }


                    

                }


                if (meleeL1R8.Count == 0 && shooterL1R8.Count == 0 && player.DrawRect.Intersects(keycard8Rect))
                {
                    keycard8Rect = new Rectangle(9000, 9000, 1, 1);
                    doorL1R8.Remove(doorL1R8[0]);
                }


                if (player.DrawRect.Bottom <= 0)
                {
                    room = Room.Room9;
                    player.DrawRect = new Rectangle(player.DrawRect.X, 750, player.DrawRect.Width, player.DrawRect.Height);
                }
            }

            if (screen == Screen.Game && room == Room.Room9)
            {
                foreach (Rectangle wall in wallsL1R9)
                {
                    if (player.Hitbox.Intersects(wall))
                    {
                        player.DrawRect.Offset(-player.Speed);
                    }


                }



                if (player.DrawRect.Intersects(healthBoostL1R9))
                {
                    healthSound.Play();
                    player.Health = player.MaxHealth;
                    healthBoostL1R9 = new Rectangle(9000, 9000, 1, 1);
                }


                if (player.Hitbox.Intersects(workbenches[2].Location))
                {
                    if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E))
                    {
                        checkpoint = new Vector2(600, 450);
                        respawnRoom = Room.Room9;
                        screen = Screen.Workbench;
                    }
                }

                if (player.DrawRect.Left >= 1000)
                {
                    room = Room.Room10;
                    player.DrawRect = new Rectangle(50, player.DrawRect.Y, player.DrawRect.Width, player.DrawRect.Height);
                }
            }

            if (screen == Screen.Game && room == Room.Room10)
            {
                foreach (Rectangle wall in wallsL1R10)
                {
                    if (player.Hitbox.Intersects(wall))
                    {
                        player.DrawRect.Offset(-player.Speed);
                    }


                }

                foreach (Rectangle door in doorL1R10)
                {
                    if (player.Hitbox.Intersects(door))
                    {
                        player.DrawRect.Offset(-player.Speed);
                    }


                }

                foreach (ShooterGuard shooterGuard in warden)
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

                for (int i = 0; i < warden.Count; i++)
                {

                    for (int j = 0; j < warden[i].Bullets.Count; j++)
                    {
                        if (warden[i].Bullets[j].Hitbox.Intersects(player.DrawRect))
                        {
                            player.Health -= 200;
                            warden[i].Bullets.Remove(warden[i].Bullets[j]);
                            j--;
                        }
                    }

                    if (warden[i].Health <= 0)
                    {
                        guardSound.Play();
                        warden[i].ClearBullets();
                        warden.Remove(warden[i]);
                        score += 10;
                        i--;

                    }
                }

                if (warden.Count == 0 && player.DrawRect.Intersects(keycard10Rect))
                {
                    keycard10Rect = new Rectangle(9000, 9000, 1, 1);

                    for (int i = 0; i < doorL1R10.Count;i++)
                    {
                        doorL1R10.Remove(doorL1R10[i]);
                        i--;
                    }

                }

                if (player.DrawRect.Left >= 1000)
                {
                    screen = Screen.Escaped;
                }

            }


            if (screen == Screen.Workbench)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    if (damageRect.Contains(mouseState.Position))
                    {
                        if (score >= upgradeCost && player.Damage < 10)
                        {
                            upgradeSound.Play();
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
                        if (score >= upgradeCost && player.MaxAmmo < 35)
                        {
                            upgradeSound.Play();
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
                        if (score >= upgradeCost && player.MaxHealth < 200)
                        {
                            upgradeSound.Play();
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

            if (screen == Screen.Dead)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    if (respawnRect.Contains(mouseState.Position))
                    {
                        player.Health = player.MaxHealth;
                        player.Position = checkpoint;
                        room = respawnRoom;
                        screen = Screen.Game;
                        room = respawnRoom;
                    }
                }
            }

            if (screen == Screen.Escaped)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    if (gameEndRect.Contains(mouseState.Position))
                    {
                        Exit();
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


                foreach (ShooterGuard shooterGuard in shooterL1R7)
                {
                    shooterGuard.Draw(_spriteBatch);
                }

                for (int i = 0; i < shooterL1R7.Count; i++)
                {
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(shooterL1R7[i].DrawRect.Left - 3, shooterL1R7[i].DrawRect.Top - 10, shooterL1R7[i].MaxHealth * 2, 4), Color.Gray);
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(shooterL1R7[i].DrawRect.Left - 3, shooterL1R7[i].DrawRect.Top - 10, shooterL1R7[i].Health * 2, 4), Color.Lime);
                }
            }

            if (screen == Screen.Game && room == Room.Room8)
            {
                foreach (Rectangle wall in wallsL1R8)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }

                foreach (Rectangle door in doorL1R8)
                {
                    _spriteBatch.Draw(healthBarTexture, door, Color.Red);
                }

                for (int i = 0; i < meleeL1R8.Count; i++)
                {
                    meleeL1R8[i].Draw(_spriteBatch);

                    _spriteBatch.Draw(healthBarTexture, new Rectangle(meleeL1R8[i].DrawRect.Left - 3, meleeL1R8[i].DrawRect.Top - 10, meleeL1R8[i].MaxHealth * 2, 4), Color.Gray);
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(meleeL1R8[i].DrawRect.Left - 3, meleeL1R8[i].DrawRect.Top - 10, meleeL1R8[i].Health * 2, 4), Color.Lime);
                }


                foreach (ShooterGuard shooterGuard in shooterL1R8)
                {
                    shooterGuard.Draw(_spriteBatch);
                }

                for (int i = 0; i < shooterL1R8.Count; i++)
                {
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(shooterL1R8[i].DrawRect.Left - 3, shooterL1R8[i].DrawRect.Top - 10, shooterL1R8[i].MaxHealth * 2, 4), Color.Gray);
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(shooterL1R8[i].DrawRect.Left - 3, shooterL1R8[i].DrawRect.Top - 10, shooterL1R8[i].Health * 2, 4), Color.Lime);
                }

                if (meleeL1R8.Count == 0 && shooterL1R8.Count == 0)
                {
                    _spriteBatch.Draw(keycardTexture, keycard8Rect, Color.White);
                }

            }

            if (screen == Screen.Game && room == Room.Room9)
            {
                foreach (Rectangle wall in wallsL1R9)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }

                workbenches[2].Draw(_spriteBatch);

                _spriteBatch.Draw(healthBoostTexture, healthBoostL1R9, Color.White);
            }

            if (screen == Screen.Game && room == Room.Room10)
            {
                foreach (Rectangle wall in wallsL1R10)
                {
                    _spriteBatch.Draw(wallTexture, wall, Color.White);
                }

                foreach (Rectangle door in doorL1R10)
                {
                    _spriteBatch.Draw(healthBarTexture, door, Color.Red);
                }
            
                foreach (ShooterGuard shooterGuard in warden)
                {
                    shooterGuard.Draw(_spriteBatch);

                }

                for (int i = 0; i < warden.Count; i++)
                {
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(200, 50, warden[i].MaxHealth, 20), Color.Gray);
                    _spriteBatch.Draw(healthBarTexture, new Rectangle(200, 50, warden[i].Health, 20), Color.Lime);
                }

                if (warden.Count == 0)
                {
                    _spriteBatch.Draw(keycardTexture, keycard10Rect, Color.White);
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

            if (screen == Screen.Game)
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

            
            if (screen == Screen.Info)
            {
                _spriteBatch.Draw(infoTexture, window, Color.White);
            }


            if (screen == Screen.Escaped)
            {
                _spriteBatch.Draw(escapedTexture, window, Color.White);

            }

            if (screen == Screen.Dead)
            {
                _spriteBatch.Draw(deathTexture, window, Color.White);

            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}



