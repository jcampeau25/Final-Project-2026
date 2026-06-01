using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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

        List<Workbench> workbenches;

        Texture2D playerTexture, shooterGuardTexture, meleeGuardTexture, bulletTexture, crosshairTexture,
                  ammoTexture, healthBarTexture, wallTexture, workbenchTexture;
        SpriteFont ammoFont, reloadingFont;

        int score = 0;

        Screen screen;

        Level1Room Level1Room;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            level1ShooterGuards = new List<ShooterGuard>();
            level1MeleeGuards = new List<MeleeGuard>();
            workbenches = new List<Workbench>();

            player = new Player(new Rectangle(50, 50, 43, 43), new Vector2(50, 50), playerTexture, Color.White, bulletTexture, 100);

            level1ShooterGuards.Add(new ShooterGuard(new Rectangle(500, 500, 50, 50), new Vector2(500, 500), shooterGuardTexture, Color.White, bulletTexture, 25));
            level1MeleeGuards.Add(new MeleeGuard(new Rectangle(600, 200, 50, 50), new Vector2(600, 200), new Vector2(5,5), meleeGuardTexture, 25, 5));




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
            
            
        }

        protected override void Update(GameTime gameTime)
        {
            prevMouseState = mouseState;
            prevKeyboardState = keyboardState;

            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            player.Draw(_spriteBatch);

            workbenches[0].Draw(_spriteBatch);


            foreach (ShooterGuard shooterGuard1 in level1ShooterGuards)
            {
                shooterGuard1.Draw(_spriteBatch);
            }

            foreach (MeleeGuard meleeGuard in level1MeleeGuards)
            {
                meleeGuard.Draw(_spriteBatch);
            }

            _spriteBatch.Draw(healthBarTexture, player.Hitbox, Color.Red * 0.2f);
            _spriteBatch.Draw(healthBarTexture, player.DrawRect, Color.Red * 0.2f);


            _spriteBatch.Draw(healthBarTexture, level1ShooterGuards[0].Hitbox, Color.Red * 0.2f);
            _spriteBatch.Draw(healthBarTexture, level1ShooterGuards[0].DrawRect, Color.Red * 0.2f);


            _spriteBatch.Draw(ammoTexture, new Rectangle(920, 680, 48, 70), Color.White);
            _spriteBatch.DrawString(ammoFont, player.Ammo.ToString(), new Vector2(855, 695), Color.White);
            _spriteBatch.Draw(healthBarTexture, new Rectangle(50, 720, player.MaxHealth * 2, 20), Color.Gray);
            _spriteBatch.Draw(healthBarTexture, new Rectangle(50, 720, player.Health * 2, 20), Color.Lime);

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

            if (player.Reloading)
            {
                _spriteBatch.DrawString(reloadingFont, ("reloading"), new Vector2(860, 750), Color.Red);

            }



            _spriteBatch.Draw(crosshairTexture, mouseState.Position.ToVector2(), null, Color.White, 0, new Vector2(crosshairTexture.Width / 2, crosshairTexture.Height / 2), 0.6f, SpriteEffects.None, 0f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}



