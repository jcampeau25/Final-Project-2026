using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_2026
{
    public class Player
    {
        public Rectangle Hitbox;
        public Rectangle DrawRect;
        public Vector2 Speed;
        private Texture2D _texture, _bulletTexture;
        private Color _color;
        private float _rotation;
        public Vector2 Position;
        public Vector2 Direction;
        public int Ammo, MaxAmmo;
        public bool Reloading;
        public float ReloadTimer;
        public int Health, MaxHealth;
        public int Damage;

        public List<Bullet> Bullets;
        

        public Player(Rectangle hitbox, Vector2 position, Texture2D texture, Color color, Texture2D bulletTexture, int maxHealth)
        {
            Hitbox = hitbox;
            DrawRect = new Rectangle(position.ToPoint(), new Point(67, 67));
            Speed = Vector2.Zero;
            _texture = texture;
            _color = color;
            _rotation = 0;
            Health = maxHealth;
            MaxHealth = maxHealth;
            MaxAmmo = 10;
            Ammo = 10;
            Bullets = new List<Bullet>();
            _bulletTexture = bulletTexture;
            Damage = 5;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in Bullets)
            {
                bullet.Draw(spriteBatch);
            }

            spriteBatch.Draw(_texture, new Rectangle(DrawRect.Center, DrawRect.Size), null, _color, _rotation, new Vector2(_texture.Width / 2, _texture.Height / 2), SpriteEffects.None, 1f);
            
        }

        public void Update(KeyboardState keyboardState, MouseState mouseState, MouseState prevMouseState, GameTime gameTime, Rectangle window)
        {
            Speed = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.D))
            {
                Speed.X += 4;
            }

            if (keyboardState.IsKeyDown(Keys.A))
            {
                Speed.X += -4;
            }

            if (keyboardState.IsKeyDown(Keys.W))
            {
                Speed.Y += -4;

            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                Speed.Y += 4;
            }

            if ((keyboardState.IsKeyDown(Keys.R) || Ammo == 0) && Reloading == false && Ammo < MaxAmmo)
            {
                Reloading = true;
            }

            if (Reloading == true)
            {
                ReloadTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                
                if (ReloadTimer >= 2)
                {
                    Ammo = MaxAmmo;
                    ReloadTimer = 0;
                    Reloading = false;
                }
            }

            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && Reloading == false && Ammo >= 0)
            {
                Vector2 direction;

                direction = mouseState.Position.ToVector2() - DrawRect.Center.ToVector2();

                direction.Normalize();

                Bullets.Add(new Bullet(DrawRect.Center.ToVector2(), _bulletTexture, direction, Color.Gray, 700));
                Ammo += -1;
               
            }

            for (int i = 0; i < Bullets.Count; i++)
            {
                Bullets[i].Update(gameTime);

                //if (Bullets[i].Hitbox.Right < 0 || Bullets[i].Hitbox.Left > window.Right || Bullets[i].Hitbox.Top > window.Bottom || Bullets[i].Hitbox.Bottom > window.Top)
                //{
                //    Bullets.Remove(Bullets[i]);
                //}
            }


            DrawRect.Offset(Speed);
            UpdateHitbox();



            Direction = mouseState.Position.ToVector2() - DrawRect.Center.ToVector2();
            _rotation = (float)Math.Atan2(Direction.Y, Direction.X) + MathHelper.PiOver2;

        }
        private void UpdateHitbox()
        {
            Hitbox.X = DrawRect.X + 12;
            Hitbox.Y = DrawRect.Y + 12;
        }
    }
}
