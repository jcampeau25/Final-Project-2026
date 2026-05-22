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
        public Rectangle _hitbox;
        public Rectangle _drawRect;
        private Vector2 _speed;
        private Texture2D _texture, _bulletTexture;
        private Color _color;
        private float _rotation;
        public Vector2 _position;
        public Vector2 _direction;
        public int _ammo, _maxAmmo;
        public bool _reloading;
        public float _reloadTimer;
        public int _health, _maxHealth;

        List<Bullet> bullets;
        

        public Player(Rectangle hitbox, Vector2 position, Texture2D texture, Color color, Texture2D bulletTexture, int maxHealth)
        {
            _hitbox = hitbox;
            _drawRect = new Rectangle(position.ToPoint(), new Point(67, 67));
            _speed = Vector2.Zero;
            _texture = texture;
            _color = color;
            _rotation = 0;
            _health = maxHealth;
            _maxHealth = maxHealth;
            _maxAmmo = 20;
            _ammo = 20;
            bullets = new List<Bullet>();
            _bulletTexture = bulletTexture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }

            spriteBatch.Draw(_texture, new Rectangle(_drawRect.Center, _drawRect.Size), null, _color, _rotation, new Vector2(_texture.Width / 2, _texture.Height / 2), SpriteEffects.None, 1f);
            
        }

        public void Update(KeyboardState keyboardState, MouseState mouseState, MouseState prevMouseState, GameTime gameTime)
        {
            _speed = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.D))
            {
                _speed.X += 4;
            }

            if (keyboardState.IsKeyDown(Keys.A))
            {
                _speed.X += -4;
            }

            if (keyboardState.IsKeyDown(Keys.W))
            {
                _speed.Y += -4;

            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                _speed.Y += 4;
            }

            if ((keyboardState.IsKeyDown(Keys.R) || _ammo == 0) && _reloading == false && _ammo <= _maxAmmo)
            {
                _reloading = true;
            }

            if (_reloading == true)
            {
                _reloadTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                
                if (_reloadTimer >= 2)
                {
                    _ammo = _maxAmmo;
                    _reloadTimer = 0;
                    _reloading = false;
                }
            }

            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released && _reloading == false && _ammo >= 0)
            {
                Vector2 direction;

                direction = mouseState.Position.ToVector2() - _drawRect.Center.ToVector2();

                direction.Normalize();


                bullets.Add(new Bullet(_drawRect.Center.ToVector2(), _bulletTexture, direction, 700));
                _ammo += -1;
               
            }

            foreach (Bullet bullet in bullets)
            {
                bullet.Update(gameTime);
            }

            _hitbox.Offset(_speed);
            _drawRect.Offset(_speed);

            _direction = mouseState.Position.ToVector2() - _drawRect.Center.ToVector2();
            _rotation = (float)Math.Atan2(_direction.Y, _direction.X) + MathHelper.PiOver2;

        }
    }
}
