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
    public class MeleeGuard
    {
        public Rectangle Hitbox;
        public Rectangle DrawRect;
        private Vector2 _speed;
        private Texture2D _texture;
        private Color _color;
        public float Rotation;
        public Vector2 Position;
        public Vector2 Direction;
        public int Health, MaxHealth;




        public MeleeGuard(Rectangle hitbox, Vector2 position, Vector2 direction, Texture2D texture, int maxHealth, float speed)
        {
            Hitbox = hitbox;
            _texture = texture;
            DrawRect = new Rectangle(position.ToPoint(), new Point(50, 50));
            _speed = new Vector2(direction.X * speed, direction.Y * speed);
            _color = Color.White;
            Rotation = 0;
            Health = maxHealth;
            MaxHealth = maxHealth;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle(DrawRect.Center, DrawRect.Size), null, _color, Rotation, new Vector2(_texture.Width / 2, _texture.Height / 2), SpriteEffects.None, 1f);
        }

        public void Update(GameTime gameTime, Player player)
        {

            Direction = player.DrawRect.Center.ToVector2() - DrawRect.Center.ToVector2();
            Rotation = (float)Math.Atan2(Direction.Y, Direction.X) + (3 * MathHelper.PiOver2);

            Vector2 direction;


            direction = player.DrawRect.Center.ToVector2() - DrawRect.Center.ToVector2();
            direction.Normalize();


            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position += _speed * dt;
        }

    }




}
