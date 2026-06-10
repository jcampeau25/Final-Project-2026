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
    public class ShooterGuard
    {
        public Rectangle Hitbox;
        public Rectangle DrawRect;
        private Vector2 _speed;
        private Texture2D _texture, _bulletTexture;
        private Color _color;
        public float Rotation;
        public Vector2 Position;
        public Vector2 Direction;
        public int Health, MaxHealth;
        private float _shootTimer;
        private double _fireRate;
        public List<Bullet> Bullets;
        private Random _generator;

        public ShooterGuard(Rectangle hitbox, Vector2 position, Texture2D texture, Color color, Texture2D bulletTexture, int maxHealth)
        {
            Hitbox = hitbox;
            DrawRect = new Rectangle(position.ToPoint(), new Point(50, 50));
            _speed = Vector2.Zero;
            _texture = texture;
            _color = color;
            Rotation = 0;
            Health = maxHealth;
            MaxHealth = maxHealth;
            Bullets = new List<Bullet>();
            _bulletTexture = bulletTexture;
            _shootTimer = 0;
            _generator = new Random();
            _fireRate = _generator.NextDouble() + 1;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in Bullets)
            {
                bullet.Draw(spriteBatch);
            }

            spriteBatch.Draw(_texture, new Rectangle(DrawRect.Center, DrawRect.Size), null, _color, Rotation, new Vector2(_texture.Width / 2, _texture.Height / 2), SpriteEffects.None, 1f);

        }

        public void Update(GameTime gameTime, Player player, Rectangle window)
        {


            Direction = player.DrawRect.Center.ToVector2() - DrawRect.Center.ToVector2();
            Rotation = (float)Math.Atan2(Direction.Y, Direction.X) + (3 * MathHelper.PiOver2);

            _shootTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_shootTimer >= _fireRate)
            {
                Vector2 direction;

                direction = player.DrawRect.Center.ToVector2() - DrawRect.Center.ToVector2();
                direction.Normalize();

                Bullets.Add(new Bullet(DrawRect.Center.ToVector2(), _bulletTexture, direction, Color.Red, 300));

                _shootTimer = 0;
            }

            for (int i = 0; i < Bullets.Count; i ++)
            {
                Bullets[i].Update(gameTime);

                if (Bullets[i].Hitbox.Right < 0 || Bullets[i].Hitbox.Left > window.Right || Bullets[i].Hitbox.Top > window.Bottom || Bullets[i].Hitbox.Bottom < window.Top)
                {
                    Bullets.Remove(Bullets[i]);
                }
            }

        }

        public void ClearBullets()
        {
            Bullets.Clear();
        }

    }
}
