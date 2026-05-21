using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Final_Project_2026
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        MouseState mouseState, prevMouseState;

        KeyboardState keyboardState;

        Player player;

        Texture2D playerTexture, bulletTexture, crosshairTexture, ammoTexture;
        SpriteFont ammoFont, reloadingFont;

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

            player = new Player(new Rectangle(50, 50, 100, 140), new Vector2(50, 50), playerTexture, Color.White, bulletTexture);

            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            playerTexture = Content.Load<Texture2D>("Images/player_gun");
            bulletTexture = Content.Load<Texture2D>("Images/bullet");
            crosshairTexture = Content.Load<Texture2D>("Images/crosshair");
            ammoTexture = Content.Load<Texture2D>("Images/ammo_icon");
            ammoFont = Content.Load<SpriteFont>("Fonts/ammoFont");
            reloadingFont = Content.Load<SpriteFont>("Fonts/reloadingFont");

        }

        protected override void Update(GameTime gameTime)
        {
            prevMouseState = mouseState;

            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            player.Update(keyboardState, mouseState, prevMouseState, gameTime);
             
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            player.Draw(_spriteBatch);

            _spriteBatch.Draw(ammoTexture, new Rectangle(920, 680, 48, 70), Color.White);
            _spriteBatch.DrawString(ammoFont, player._ammo.ToString(), new Vector2(855, 695), Color.White);

            if (player._reloading)
            {
                _spriteBatch.DrawString(reloadingFont, ("reloading"), new Vector2(860, 750), Color.Red);

            }

            _spriteBatch.Draw(crosshairTexture, mouseState.Position.ToVector2(), null, Color.White, 0, new Vector2(crosshairTexture.Width / 2, crosshairTexture.Height / 2), 0.6f, SpriteEffects.None, 0f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}



