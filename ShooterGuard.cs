using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_2026
{
    internal class ShooterGuard
    {
        public Rectangle _hitbox;
        private Rectangle _drawRect;
        private Vector2 _speed;
        private Texture2D _texture, _bulletTexture;
        private Color _color;
        public float _rotation;
        public Vector2 _position;
        public Vector2 _direction;
        public int _health, _maxHealth;
        private int _shootTimer;
        List<Bullet> bullets;


        public ShooterGuard(Rectangle hitbox, Vector2 position, Texture2D texture, Color color, Texture2D bulletTexture, int maxHealth)
        {
            _hitbox = hitbox;
            _drawRect = new Rectangle(position.ToPoint(), new Point(50, 50));
            _speed = Vector2.Zero;
            _texture = texture;
            _color = color;
            _rotation = 0;
            _health = maxHealth;
            _maxHealth = maxHealth;
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

        public void Update(GameTime gametime, Player player)
        {


            _direction = player._drawRect.Center.ToVector2() - _drawRect.Center.ToVector2();
            _rotation = (float)Math.Atan2(_direction.Y, _direction.X) + (3 * MathHelper.PiOver2);
            
        }

    }
}
