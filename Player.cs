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
        private Rectangle _hitbox;
        private Rectangle _drawRect;
        private Vector2 _speed;
        private Texture2D _texture;
        private Color _color;
        private float _rotation;
        Vector2 _position;
        Vector2 _direction;

        List<Bullet> bullets;
        

        public Player(Rectangle hitbox, Vector2 position, Texture2D texture, Color color)
        {
            _hitbox = hitbox;
            _drawRect = new Rectangle(position.ToPoint(), new Point(50, 50));
            _speed = Vector2.Zero;
            _texture = texture;
            _color = color;
            _rotation = 0;
            bullets = new List<Bullet>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle(_drawRect.Center, _drawRect.Size), null, _color, _rotation, new Vector2(_texture.Width / 2, _texture.Height / 2), SpriteEffects.None, 1f);
        }

        public void Update(KeyboardState keyboardState, MouseState mouseState, MouseState prevMouseState)
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

            if (mouseState.LeftButton == ButtonState.Pressed || prevMouseState.LeftButton == ButtonState.Released)
            {
                //bullets.Add(new Bullet(_drawRect.Center, new ));
            }


            _hitbox.Offset(_speed);
            _drawRect.Offset(_speed);

            _direction = mouseState.Position.ToVector2() - _drawRect.Center.ToVector2();
            _rotation = (float)Math.Atan2(_direction.Y, _direction.X) + MathHelper.PiOver2;

        }
    }
}
